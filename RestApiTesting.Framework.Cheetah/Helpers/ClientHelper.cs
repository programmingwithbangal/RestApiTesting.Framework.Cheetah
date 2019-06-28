using System;
using System.Dynamic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestApiTesting.Framework.Cheetah.Constants;

namespace RestApiTesting.Framework.Cheetah.Helpers
{
    public class ClientHelper
    {
        public static HttpClient GetClient(Uri uri)
        {
            var httpClientHandler = new HttpClientHandler();

            var proxy = new HttpClient(httpClientHandler)
            {
                    BaseAddress = uri
            };

            return proxy;
        }

        public static Task<HttpResponseMessage> GetResponse(string uri, string requestType, HttpClient client, ExpandoObject model)
        {
            HttpRequestMessage request;

            switch (requestType)
            {
                case RequestType.Get:
                    request = new HttpRequestMessage(HttpMethod.Get, uri);
                    break;
                case RequestType.Delete:
                    request = new HttpRequestMessage(HttpMethod.Delete, uri);
                    break;
                case RequestType.Post:
                    request = new HttpRequestMessage(HttpMethod.Post, uri);
                    break;
                case RequestType.Put:
                    request = new HttpRequestMessage(HttpMethod.Put, uri);
                    break;
                case RequestType.Patch:
                    request = new HttpRequestMessage(new HttpMethod("PATCH"), uri);
                    break;
                default:
                    throw new NotImplementedException($"Request type: {requestType} is not implemented.");
            }

            if (model != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, MimeTypes.ApplicationJson);
            }

            return client.SendAsync(request);
        }
    }
}