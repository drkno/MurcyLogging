using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

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

        private void HandleRequest(HttpProcessor processor)
        {
            if (_handlers.Any(restfulUrlHandler => restfulUrlHandler.Execute(processor)))
            {
                if (!processor.ResponseWritten) processor.WriteSuccess();
                return;
            }
            processor.WriteFailure();
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
            _isActive = false;
            _listenThread.Abort();
            _listenThread.Join();
        }
    }

    public class RestfulUrlHandler
    {
        private readonly Regex _urlRegex;
        private readonly Action<HttpProcessor> _callback;

        public RestfulUrlHandler(string urlRegex, Action<HttpProcessor> callback)
        {
            _urlRegex = new Regex("^" + urlRegex + "$", RegexOptions.Compiled);
            _callback = callback;
        }

        public bool Execute(HttpProcessor processor)
        {
            if (!_urlRegex.IsMatch(processor.HttpUrl)) return false;
            _callback.Invoke(processor);
            return true;
        }
    }

    public class HttpProcessor
    {
        private readonly TcpClient _socket;
        private readonly Action<HttpProcessor> _requestHandler;
        private Stream _inputStream;
        private StreamWriter _outputStream;

        public HttpMethod HttpMethod { get; private set; }
        public string HttpUrl { get; private set; }
        public string HttpVersion { get; private set; }
        public Hashtable HttpHeaders { get; private set; }
        public Hashtable HttpResponseHeaders { get; private set; }
        public Hashtable HttpCookies { get; private set; }
        public Hashtable HttpResponseSetCookies { get; private set; }
        public string HttpPostData { get; private set; }
        public bool ResponseWritten { get; private set; }

        private const int MaxPostSize = 10485760;
        private const int BufSize = 4096;

        public HttpProcessor(TcpClient tcpClient, Action<HttpProcessor> handleRequest)
        {
            _requestHandler = handleRequest;
            _socket = tcpClient;
            HttpHeaders = new Hashtable();
            HttpResponseHeaders = new Hashtable();
            HttpCookies = new Hashtable();
            HttpResponseSetCookies = new Hashtable();
        }

        public string DecodeAuthenticationHeader()
        {
            var authString = (string) HttpHeaders["Authorization"];
            var data = Convert.FromBase64String(authString.Split(' ')[1]);
            return Encoding.UTF8.GetString(data);
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
                    GetPostData();
                }
                _requestHandler.Invoke(this);
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

            switch (tokens[0].ToLower())
            {
                case "get": HttpMethod = HttpMethod.Get; break;
                case "post": HttpMethod = HttpMethod.Post; break;
                case "put": HttpMethod = HttpMethod.Put; break;
                case "head": HttpMethod = HttpMethod.Head; break;
                case "delete": HttpMethod = HttpMethod.Delete; break;
                case "trace": HttpMethod = HttpMethod.Trace; break;
                case "options": HttpMethod = HttpMethod.Options; break;
                default: goto case "trace";
            }

            HttpUrl = tokens[1];
            HttpVersion = tokens[2];

            ReadCookies();
        }

        private void ReadCookies()
        {
            var cookie = (string)HttpHeaders["Cookie"];
            if (cookie == null) return;
            var cookies = cookie.Split(new []{"; ", ";"}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var spl in cookies.Select(s => s.Split('=')))
            {
                HttpCookies[spl[0].Trim()] = spl[1].Trim();
            }
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
                    throw new Exception("Invalid HTTP header: \"" + line + "\"");
                }
                var name = line.Substring(0, separator);
                var value = line.Substring(separator + 1).Trim();
                HttpHeaders[name] = value;
            }
        }

        private void GetPostData()
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
                    var numread = _inputStream.Read(buf, 0, Math.Min(BufSize, toRead));
                    if (numread == 0)
                    {
                        if (toRead == 0)
                        {
                            break;
                        }
                        throw new Exception("Client disconnected while reading POST data.");
                    }
                    toRead -= numread;
                    ms.Write(buf, 0, numread);
                }
                ms.Seek(0, SeekOrigin.Begin);
            }

            var reader = new StreamReader(ms);
            HttpPostData = reader.ReadToEnd();
            reader.Close();
        }

        public void WriteSuccess(string response = null, string contentType = null)
        {
            WriteResponse("200 OK", response, contentType);
        }

        public void WriteAuthRequired(bool basicAuthentication = true, string errorMessage = "<b>401, Thou must login before slaying dragons.</b>")
        {
            HttpResponseHeaders["WWW-Authenticate"] = "Basic realm=\"Login Required\"";
            WriteResponse("401 Not Authorized", errorMessage);
        }

        public void WriteFailure(string errorMessage = "<b>404, I cannot find what you are looking for.</b>")
        {
            WriteResponse("404 File Not Found", errorMessage);
        }

        public void WriteResponse(string status, string response = null, string contentType = null)
        {
            if (ResponseWritten) throw new Exception("Cannot send new response after response has been written.");
            ResponseWritten = true;
            _outputStream.WriteLine("HTTP/1.0 " + status);
            _outputStream.WriteLine("Connection: close");
            if (!string.IsNullOrWhiteSpace(response))
            {
                contentType = string.IsNullOrWhiteSpace(contentType) ? "text/html" : contentType;
                _outputStream.WriteLine("Content-Type: " + contentType);
                _outputStream.WriteLine("Content-Length: " + response.Length);
            }
            foreach (var header in HttpResponseHeaders.Keys)
            {
                _outputStream.WriteLine(header + ": " + HttpResponseHeaders[header]);
            }
            foreach (var cookie in HttpResponseSetCookies.Keys)
            {
                _outputStream.WriteLine("Set-Cookie: " + cookie + "=" + HttpResponseSetCookies[cookie]);
            }
            _outputStream.WriteLine("");
            if (!string.IsNullOrWhiteSpace(response))
            {
                _outputStream.WriteLine(response);
            }
        }
    }
}
