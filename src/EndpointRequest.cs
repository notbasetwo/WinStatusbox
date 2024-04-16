using Microsoft.JScript;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WinStatusbox
{
    internal class EndpointRequest
    {

        private readonly string ApiKey;
        private readonly string EndpointURL;
        private readonly string EndpointIdentifier;
        public string Body;
        public string Path;

        public EndpointRequest(String path, String body)
        {
            this.ApiKey = ConfigurationSettings.AppSettings.Get("ApiKey");
            this.EndpointURL = ConfigurationSettings.AppSettings.Get("EndpointURL");
            this.EndpointIdentifier = ConfigurationSettings.AppSettings.Get("EndpointID");
            this.Body = body;
            this.Path = path;

        }
        

        public void MakeRequest()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(EndpointURL + "/" + this.Path);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", ApiKey);
            httpClient.DefaultRequestHeaders.Add("X-Endpoint-Id", EndpointIdentifier);
            var content = new StringContent(Body);
            var response = httpClient.PostAsync("", content).Result; 
            
            EndpointResponse responder = new EndpointResponse(response);

        }

    }
}
