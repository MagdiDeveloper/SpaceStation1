using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Connections
{
    public static class RestConnection
    {
        public static T Post<T>(string serviceUrl, object data, string authorizationToken = null) where T : class
        {
            T resp = null;
            using (var client = new HttpClient())
            {
                try
                {
                    if (!string.IsNullOrEmpty(authorizationToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorizationToken);
                    }

                    StringContent sc = BuildStringContent(data, client);
                    HttpResponseMessage response = client.PostAsync(serviceUrl, sc).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        resp = JsonConvert.DeserializeObject<T>(content);
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    // write to logger
                }
            }
            return resp;
        }

        public static T Get<T>(string serviceUrl, string authorizationToken = null) where T : class
        {
            T resp = null;
            using (var client = new HttpClient())
            {
                try
                {
                    if (!string.IsNullOrEmpty(authorizationToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authorizationToken);
                    }
                    HttpResponseMessage response = client.GetAsync(serviceUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
                        resp = JsonConvert.DeserializeObject<T>(content);
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    // write to logger
                }
            }
            return resp;
        }

        private static StringContent BuildStringContent(object data, HttpClient client)

        {
            string req = JsonConvert.SerializeObject(data);
            return new StringContent(req, Encoding.UTF8, "application/json");

        }
    }
}
