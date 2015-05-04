#region

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

#endregion

namespace Agilefantasy
{
    /// <summary>
    /// Represents an Agilefant Session
    /// </summary>
    public class AgilefantSession
    {
        private const string LOGIN_URL = "http://agilefant.cosc.canterbury.ac.nz:8080/agilefant302/j_spring_security_check";
        private const string AGILEFANT_URL = "http://agilefant.cosc.canterbury.ac.nz:8080/agilefant302/";

        internal HttpClientHandler Handler { get; private set; }
        internal CookieContainer CookieContainer { get { return Handler.CookieContainer; } }

        private readonly HttpClient _httpClient;

        private AgilefantSession(HttpClientHandler handler)
        {
            this.Handler = handler;
            _httpClient = new HttpClient(handler);
        }

        /// <summary>
        /// Gets some a response from agilefant
        /// </summary>
        /// <param name="query">The query. This is appended to http://agilefant.cosc.canterbury.ac.nz:8080/agilefant302/</param>
        /// <returns>The response</returns>
        public Task<HttpResponseMessage> Get(string query)
        {
            return _httpClient.GetAsync(AGILEFANT_URL + query);
        }

        /// <summary>
        /// Posts some httpcontent to Agilefant
        /// </summary>
        /// <param name="query">The query. This is appended to http://agilefant.cosc.canterbury.ac.nz:8080/agilefant302/</param>
        /// <param name="content">The content to post</param>
        /// <returns>The response</returns>
        public Task<HttpResponseMessage> Post(string query, HttpContent content)
        {
            return _httpClient.PostAsync(AGILEFANT_URL + query, content);
        }

        /// <summary>
        /// Posts a blank string to the specified url. Useful
        /// for empty post request
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>The url</returns>
        public Task<HttpResponseMessage> Post(string query)
        {
            return Post(query, new StringContent(""));
        }

        /// <summary>
        /// Logs in and creates a new Agilefant session. Throws an exception
        /// if unable to login or a WebException is something net related goes wrong
        /// </summary>
        /// <param name="username">The username to log in with</param>
        /// <param name="password">The password to log in with</param>
        /// <returns>The agilefant session</returns>
        public static async Task<AgilefantSession> Login(string username, string password)
        {
            var handler = new HttpClientHandler();
            handler.AllowAutoRedirect = true;
            handler.UseCookies = true;
            var client = new HttpClient(handler);
            var data = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                {"j_username", username},
                {"j_password", password}
            });

            var response = await client.PostAsync(new Uri(LOGIN_URL), data);
            //Will throw an exception if the request failed
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            if (content.Contains("Invalid username or password, please try again."))
            {
                throw new Exception("Invalid username or password, please try again.");
            }

            return new AgilefantSession(handler);
        }
    }
}