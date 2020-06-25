using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DevToolkit.Helpers
{
    public static class WebClient
    {
        private const string DEFAULT_USER_AGENT = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.4 (KHTML, like Gecko) Chrome/22.0.1229.94 Safari/537.4 AP.Common.Helper.WebClient";

        private static async Task<HttpResponseMessage> Get(string url, string userAgent = null, string authorization = null)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue(string.IsNullOrEmpty(userAgent) ? DEFAULT_USER_AGENT : userAgent)));
                if (!string.IsNullOrEmpty(authorization))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

                response = await client.GetAsync(url);
            }

            return response != null ? response : null;
        }

        private static HttpResponseMessage GetSync(string url, string userAgent = null, string authorization = null)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue(string.IsNullOrEmpty(userAgent) ? DEFAULT_USER_AGENT : userAgent)));
                if (!string.IsNullOrEmpty(authorization))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

                response = client.GetAsync(url).Result;
            }

            return response != null ? response : null;
        }

        private static async Task<HttpResponseMessage> Post(string url, object payload, string authorization = null, TimeSpan? timeout = null)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrEmpty(authorization))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

                client.Timeout = timeout == null ? TimeSpan.FromMinutes(1) : timeout.Value;

                var serialized = JsonConvert.SerializeObject(payload);
                var content = new StringContent(serialized, Encoding.UTF8, "application/json");

                response = await client.PostAsync(url, content);
            }

            return response != null ? response : null;
        }

        private static HttpResponseMessage PostSync(string url, object payload, string authorization = null, TimeSpan? timeout = null)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrEmpty(authorization))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

                client.Timeout = timeout == null ? TimeSpan.FromMinutes(1) : timeout.Value;

                var serialized = JsonConvert.SerializeObject(payload);
                var content = new StringContent(serialized, Encoding.UTF8, "application/json");

                response = client.PostAsync(url, content).Result;
            }

            return response != null ? response : null;
        }

        private static async Task<HttpResponseMessage> Patch(string url, object payload, string authorization = null, TimeSpan? timeout = null)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var serialized = JsonConvert.SerializeObject(payload);
                var content = new StringContent(serialized, Encoding.UTF8, "application/json");
                if (!string.IsNullOrEmpty(authorization))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

                client.Timeout = timeout == null ? TimeSpan.FromMinutes(1) : timeout.Value;

                response = await client.PatchAsync(url, content);
            }

            return response != null ? response : null;
        }

        private static HttpResponseMessage PatchSync(string url, object payload, string authorization = null, TimeSpan? timeout = null)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var serialized = JsonConvert.SerializeObject(payload);
                var content = new StringContent(serialized, Encoding.UTF8, "application/json");
                if (!string.IsNullOrEmpty(authorization))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

                client.Timeout = timeout == null ? TimeSpan.FromMinutes(1) : timeout.Value;

                response = client.PatchAsync(url, content).Result;
            }

            return response != null ? response : null;
        }

        private static async Task<HttpResponseMessage> Delete(string url, string authorization = null, TimeSpan? timeout = null)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(authorization))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

                client.Timeout = timeout == null ? TimeSpan.FromMinutes(1) : timeout.Value;

                response = await client.DeleteAsync(url);
            }

            return response != null ? response : null;
        }

        private static HttpResponseMessage DeleteSync(string url, string authorization = null, TimeSpan? timeout = null)
        {
            HttpResponseMessage response;

            using (HttpClient client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(authorization))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);

                client.Timeout = timeout == null ? TimeSpan.FromMinutes(1) : timeout.Value;

                response = client.DeleteAsync(url).Result;
            }

            return response != null ? response : null;
        }

        /// <summary>
        /// Async post request that returns an object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="data"></param>
        /// <param name="authorization"></param>
        /// <param name="timeout"></param>
        /// <exception cref="ArgumentNullException">Throws when result of httpCall is null.</exception>
        /// <returns></returns>
        public static async Task<T> Post<T>(string endpoint, object payload, string authorization = null, TimeSpan? timeout = null)
        {
            T result = default(T);

            using (HttpResponseMessage responseMessage = await Post(endpoint, payload, authorization, timeout))
            {
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    HttpContent httpContent = responseMessage.Content;

                    if (httpContent == null)
                        throw new ArgumentNullException(nameof(httpContent));

                    string apiResult = httpContent.ReadAsStringAsync().Result;

                    if (string.IsNullOrWhiteSpace(apiResult))
                        throw new ArgumentNullException(nameof(apiResult));

                    result = JsonConvert.DeserializeObject<T>(apiResult);

                    if (result == null)
                        throw new ArgumentNullException(nameof(result));
                }
            }

            return result;
        }

        /// <summary>
        /// Async get request that returns an object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="data"></param>
        /// <param name="authorization"></param>
        /// <param name="timeout"></param>
        /// <exception cref="ArgumentNullException">Throws when result of httpCall is null.</exception>
        /// <returns></returns>
        public static async Task<T> Get<T>(string url, string userAgent = null, string authorization = null)
        {
            T result = default(T);

            using (HttpResponseMessage responseMessage = await Get(url, userAgent, authorization))
            {
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    HttpContent httpContent = responseMessage.Content;

                    if (httpContent == null)
                        throw new ArgumentNullException(nameof(httpContent));

                    string apiResult = httpContent.ReadAsStringAsync().Result;

                    if (string.IsNullOrWhiteSpace(apiResult))
                        throw new ArgumentNullException(nameof(apiResult));

                    result = JsonConvert.DeserializeObject<T>(apiResult);

                    if (result == null)
                        throw new ArgumentNullException(nameof(result));
                }
            }

            return result;
        }

        /// <summary>
        /// Async patch request that returns an object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="data"></param>
        /// <param name="authorization"></param>
        /// <param name="timeout"></param>
        /// <exception cref="ArgumentNullException">Throws when result of httpCall is null.</exception>
        /// <returns></returns>
        public static async Task<T> Patch<T>(string endpoint, object payload, string authorization = null, TimeSpan? timeout = null)
        {
            T result = default(T);

            using (HttpResponseMessage responseMessage = await Patch(endpoint, payload, authorization, timeout))
            {
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    HttpContent httpContent = responseMessage.Content;

                    if (httpContent == null)
                        throw new ArgumentNullException(nameof(httpContent));

                    string apiResult = httpContent.ReadAsStringAsync().Result;

                    if (string.IsNullOrWhiteSpace(apiResult))
                        throw new ArgumentNullException(nameof(apiResult));

                    result = JsonConvert.DeserializeObject<T>(apiResult);

                    if (result == null)
                        throw new ArgumentNullException(nameof(result));
                }
            }

            return result;
        }

        /// <summary>
        /// Async delete request that returns an object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="data"></param>
        /// <param name="authorization"></param>
        /// <param name="timeout"></param>
        /// <exception cref="ArgumentNullException">Throws when result of httpCall is null.</exception>
        /// <returns></returns>
        public static async Task<T> Delete<T>(string endpoint, string authorization = null, TimeSpan? timeout = null)
        {
            T result = default(T);

            using (HttpResponseMessage responseMessage = await Delete(endpoint, authorization, timeout))
            {
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    HttpContent httpContent = responseMessage.Content;

                    if (httpContent == null)
                        throw new ArgumentNullException(nameof(httpContent));

                    string apiResult = httpContent.ReadAsStringAsync().Result;

                    if (string.IsNullOrWhiteSpace(apiResult))
                        throw new ArgumentNullException(nameof(apiResult));

                    result = JsonConvert.DeserializeObject<T>(apiResult);

                    if (result == null)
                        throw new ArgumentNullException(nameof(result));
                }
            }

            return result;
        }

        /// <summary>
        /// Sync post request that returns an object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="data"></param>
        /// <param name="authorization"></param>
        /// <param name="timeout"></param>
        /// <exception cref="ArgumentNullException">Throws when result of httpCall is null.</exception>
        /// <returns></returns>
        public static T PostSync<T>(string endpoint, object payload, string authorization = null, TimeSpan? timeout = null)
        {
            T result = default(T);

            using (HttpResponseMessage responseMessage = PostSync(endpoint, payload, authorization, timeout))
            {
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    HttpContent httpContent = responseMessage.Content;

                    if (httpContent == null)
                        throw new ArgumentNullException(nameof(httpContent));

                    string apiResult = httpContent.ReadAsStringAsync().Result;

                    if (string.IsNullOrWhiteSpace(apiResult))
                        throw new ArgumentNullException(nameof(apiResult));

                    result = JsonConvert.DeserializeObject<T>(apiResult);

                    if (result == null)
                        throw new ArgumentNullException(nameof(result));
                }
            }

            return result;
        }

        /// <summary>
        /// Sync get request that returns an object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="data"></param>
        /// <param name="authorization"></param>
        /// <param name="timeout"></param>
        /// <exception cref="ArgumentNullException">Throws when result of httpCall is null.</exception>
        /// <returns></returns>
        public static T GetSync<T>(string url, string userAgent = null, string authorization = null)
        {
            T result = default(T);

            using (HttpResponseMessage responseMessage = GetSync(url, userAgent, authorization))
            {
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    HttpContent httpContent = responseMessage.Content;

                    if (httpContent == null)
                        throw new ArgumentNullException(nameof(httpContent));

                    string apiResult = httpContent.ReadAsStringAsync().Result;

                    if (string.IsNullOrWhiteSpace(apiResult))
                        throw new ArgumentNullException(nameof(apiResult));

                    result = JsonConvert.DeserializeObject<T>(apiResult);

                    if (result == null)
                        throw new ArgumentNullException(nameof(result));
                }
            }

            return result;
        }

        /// <summary>
        /// Sync patch request that returns an object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="data"></param>
        /// <param name="authorization"></param>
        /// <param name="timeout"></param>
        /// <exception cref="ArgumentNullException">Throws when result of httpCall is null.</exception>
        /// <returns></returns>
        public static T PatchSync<T>(string endpoint, object payload, string authorization = null, TimeSpan? timeout = null)
        {
            T result = default(T);

            using (HttpResponseMessage responseMessage = PatchSync(endpoint, payload, authorization, timeout))
            {
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    HttpContent httpContent = responseMessage.Content;

                    if (httpContent == null)
                        throw new ArgumentNullException(nameof(httpContent));

                    string apiResult = httpContent.ReadAsStringAsync().Result;

                    if (string.IsNullOrWhiteSpace(apiResult))
                        throw new ArgumentNullException(nameof(apiResult));

                    result = JsonConvert.DeserializeObject<T>(apiResult);

                    if (result == null)
                        throw new ArgumentNullException(nameof(result));
                }
            }

            return result;
        }

        /// <summary>
        /// Sync delete request that returns an object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="endpoint"></param>
        /// <param name="data"></param>
        /// <param name="authorization"></param>
        /// <param name="timeout"></param>
        /// <exception cref="ArgumentNullException">Throws when result of httpCall is null.</exception>
        /// <returns></returns>
        public static T DeleteSync<T>(string endpoint, string authorization = null, TimeSpan? timeout = null)
        {
            T result = default(T);

            using (HttpResponseMessage responseMessage = DeleteSync(endpoint, authorization, timeout))
            {
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    HttpContent httpContent = responseMessage.Content;

                    if (httpContent == null)
                        throw new ArgumentNullException(nameof(httpContent));

                    string apiResult = httpContent.ReadAsStringAsync().Result;

                    if (string.IsNullOrWhiteSpace(apiResult))
                        throw new ArgumentNullException(nameof(apiResult));

                    result = JsonConvert.DeserializeObject<T>(apiResult);

                    if (result == null)
                        throw new ArgumentNullException(nameof(result));
                }
            }

            return result;
        }

    }
}
