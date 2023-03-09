using OpenQA.Selenium.Remote;
using RestSharp;
using ScoobTestFramework.Driver;
using ScoobTestFramework.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScoobTestFramework.Extensions
{
    public class APIExtension
    {
        private TestSettings testSettings;

        public APIExtension()
        {
            testSettings = TestSettings.ReadConfig();
        }

        public RestResponse? SendRequest(string path, Method method)
        {
            RestClient client = new RestClient(testSettings.APIUrl);
            RestRequest request;

            if (method == Method.Get)
            {
                request = new RestRequest(path, method);
            }
            else
                return null;
            
            return client.Execute(request);
        }

        public string SendRequestGetContent(string path, Method method)
        {

            RestClient client = new RestClient(testSettings.ApplicationUrl);

            RestRequest request = new RestRequest(path, method);

            RestResponse response  =  client.Execute(request);

            return response.Content;
        }

        public HttpStatusCode SendRequestGetStatusCode(string path, Method method)
        {

            RestClient client = new RestClient(testSettings.ApplicationUrl);

            RestRequest request = new RestRequest(path, method);

            RestResponse response = client.Execute(request);

            return response.StatusCode;
        }
    }
}
