using RestSharp;
using System.IO;
using ApiTestProject.Helpers;
using Newtonsoft.Json;

namespace ApiTestProject.Helpers
{
    public class ApiHelper<T>:BaseUrl
    {
        public RestClient restClient;
        public RestRequest restRequest;
        public RestResponse restResponse;

        public RestClient SetUrl(string endpoint)
        {
            var url = Path.Combine(ApiUrl, endpoint);
            var restClient = new RestClient(url);
            return restClient;
        }
        public IRestRequest SetGetRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            return restRequest;
        }

        public Get GetContent<Get>(IRestResponse response)
        {
            var content = response.Content;
            Get get = JsonConvert.DeserializeObject<Get>(content);
            return get;
        }
     
        public IRestResponse GetResponse(RestClient client, RestRequest request)
        {
            return client.Execute(request);
        }
    }
}
