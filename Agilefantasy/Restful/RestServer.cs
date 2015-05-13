using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Http;

namespace Agilefantasy.Restful
{
    public class RestServer
    {
        private readonly int _port;
        private TcpListener _listener;
        private bool _isActive;
        private readonly List<RestfulUrlHandler> _handlers;
        private Thread _listenThread;

        public RestServer(int port)
        {
            _port = port;
            _handlers = new List<RestfulUrlHandler>();
        }

        public void AddHandler(RestfulUrlHandler handler)
        {
            _handlers.Add(handler);
        }

        public void RemoveHandler(RestfulUrlHandler handler)
        {
            _handlers.Remove(handler);
        }

        public void RemoveHandler(int index)
        {
            _handlers.RemoveAt(index);
        }

        public RestfulUrlHandler this[int index]
        {
            get { return _handlers[index]; }
            set { _handlers[index] = value; }
        }

        public static RestServer operator +(RestServer e, RestfulUrlHandler f)
        {
            e.AddHandler(f);
            return e;
        }

        private void Listen()
        {
            _listener = new TcpListener(IPAddress.Any, _port);
            _listener.Start();
            while (_isActive)
            {
                var s = _listener.AcceptTcpClient();
                var processor = new HttpProcessor(s, HandleRequest);
                var thread = new Thread(processor.ProcessInput);
                thread.Start();
                Thread.Sleep(1);
            }
        }

        private void HandleRequest(HttpProcessor p, string postData)
        {
            if (_handlers.Any(restfulUrlHandler => restfulUrlHandler.Execute(p.HttpUrl, postData)))
            {
                p.WriteSuccess();
                return;
            }
            p.WriteFailure();
        }

        public void Start()
        {
            if (_listenThread != null && _isActive)
            {
                throw new InvalidOperationException("Cannot start the server while it is already running.");
            }
            _isActive = true;
            _listenThread = new Thread(Listen);
            _listenThread.Start();
        }

        public void Stop()
        {
            _listenThread.Abort();
            _listenThread.Join();
            _isActive = false;
        }
    }

    public class RestfulUrlHandler
    {
        private readonly Regex _urlRegex;
        private readonly Func<string, string, string> _callback;

        public RestfulUrlHandler(string urlRegex, Func<string,string,string> callback)
        {
            _urlRegex = new Regex("^" + urlRegex + "$", RegexOptions.Compiled);
            _callback = callback;
        }

        public bool Execute(string url, string postData = "")
        {
            if (!_urlRegex.IsMatch(url)) return false;
            _callback.Invoke(url, postData);
            return true;
        }
    }

    public class HttpProcessor
    {
        private readonly TcpClient _socket;
        private readonly Action<HttpProcessor, string> _requestHandler;
        private Stream _inputStream;
        private StreamWriter _outputStream;

        public HttpMethod HttpMethod { get; private set; }
        public string HttpUrl { get; private set; }
        public string HttpVersion { get; private set; }
        public Hashtable HttpHeaders { get; private set; }

        private const int MaxPostSize = 10485760;
        private const int BufSize = 4096;

        public HttpProcessor(TcpClient tcpClient, Action<HttpProcessor, string> handleRequest)
        {
            _requestHandler = handleRequest;
            _socket = tcpClient;
            HttpHeaders = new Hashtable();
        }

        private string InputReadLine()
        {
            var data = "";
            while (true)
            {
                var nextChar = _inputStream.ReadByte();
                if (nextChar == '\n')
                {
                    break;
                }
                if (nextChar == '\r')
                {
                    continue;
                }
                if (nextChar == -1)
                {
                    Thread.Sleep(1);
                    continue;
                }
                ;
                data += Convert.ToChar(nextChar);
            }
            return data;
        }

        public void ProcessInput()
        {
            _inputStream = new BufferedStream(_socket.GetStream());
            _outputStream = new StreamWriter(new BufferedStream(_socket.GetStream()));

            try
            {
                ParseRequest();
                ReadHeaders();
                string postData = null;
                if (HttpMethod == HttpMethod.Post)
                {
                    postData = GetPostData();
                }
                _requestHandler.Invoke(this, postData);
            }
            catch (Exception)
            {
                WriteFailure();
                _outputStream.Flush();
                _socket.Close();
                throw;
            }
            _outputStream.Flush();
            _inputStream = null;
            _outputStream = null;
            _socket.Close();
        }

        private void ParseRequest()
        {
            var request = InputReadLine();
            var tokens = request.Split(' ');
            if (tokens.Length != 3)
            {
                throw new Exception("invalid http request line");
            }

            HttpMethod = (HttpMethod) Enum.Parse(typeof (HttpMethod), tokens[0].ToUpper());
            HttpUrl = tokens[1];
            HttpVersion = tokens[2];
        }

        private void ReadHeaders()
        {
            string line;
            while ((line = InputReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }

                var separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception("invalid http header line: " + line);
                }
                var name = line.Substring(0, separator);
                var pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' '))
                {
                    pos++; // strip any spaces
                }

                var value = line.Substring(pos, line.Length - pos);
                Console.WriteLine("header: {0}:{1}", name, value);
                HttpHeaders[name] = value;
            }
        }

        private string GetPostData()
        {
            var ms = new MemoryStream();
            if (HttpHeaders.ContainsKey("Content-Length"))
            {
                var contentLen = Convert.ToInt32(HttpHeaders["Content-Length"]);
                if (contentLen > MaxPostSize)
                {
                    throw new Exception(string.Format("POST Content-Length({0}) too big!", contentLen));
                }
                var buf = new byte[BufSize];
                var toRead = contentLen;
                while (toRead > 0)
                {
                    Console.WriteLine("starting Read, to_read={0}", toRead);

                    int numread = this._inputStream.Read(buf, 0, Math.Min(BufSize, toRead));
                    Console.WriteLine("read finished, numread={0}", numread);
                    if (numread == 0)
                    {
                        if (toRead == 0)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("client disconnected during post");
                        }
                    }
                    toRead -= numread;
                    ms.Write(buf, 0, numread);
                }
                ms.Seek(0, SeekOrigin.Begin);
            }
            Console.WriteLine("get post data end");
            var reader = new StreamReader(ms);
            var data = reader.ReadToEnd();
            reader.Close();
            return data;
        }

        public void WriteSuccess(string response = null, string contentType = null)
        {
            WriteResponse("200 OK", response, contentType);
        }

        public void WriteAuthRequired()
        {
            WriteResponse("401 Not Authorized", "<b>401, Thou must login before slaying dragons.</b>");
        }

        public void WriteFailure()
        {
            WriteResponse("404 File not found", "<b>404, I cannot find what you are looking for.</b>");
        }

        public void WriteResponse(string status, string response = null, string contentType = null)
        {
            _outputStream.WriteLine("HTTP/1.0 " + status);
            _outputStream.WriteLine("Connection: close");
            if (!string.IsNullOrWhiteSpace(response))
            {
                contentType = string.IsNullOrWhiteSpace(contentType) ? "text/html" : contentType;
                _outputStream.WriteLine("Content-Type: " + contentType);
                _outputStream.WriteLine("Content-Length: " + response.Length);
            }
            _outputStream.WriteLine("");
            if (!string.IsNullOrWhiteSpace(response))
            {
                _outputStream.WriteLine(response);
            }
        }
    }
}
