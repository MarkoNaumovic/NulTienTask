using ApiTestProject.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiTestProject.Helpers
{
    public class Api<T>
    {
        public WeatherDTO CreateGetRequest(string endpoint)
        {
            var data = new ApiHelper<WeatherDTO>();
            var url = data.SetUrl(endpoint);
            var request = data.SetGetRequest();
            var response = data.GetResponse(url,(RestRequest)request);
            WeatherDTO content = data.GetContent<WeatherDTO>(response);
            return content;
            
        }
    }
}
