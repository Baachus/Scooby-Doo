using Newtonsoft.Json;
using RestSharp;
using ScoobTestFramework.Settings;
using ScoobyRelationship.Data;
using System.Net;

namespace ScoobTestFramework.Extensions
{
    public class APIExtension
    {
        private TestSettings testSettings;

        public APIExtension()
        {
            testSettings = TestSettings.ReadConfig();
        }

        public RestResponse? SendRequest(string path, Method method, ScoobRelation scoobRelation=null)
        {
            RestClient client = new RestClient(testSettings.APIUrl);
            RestRequest request;

            try
            {
                request = new RestRequest(path, method);

                if (method == Method.Post || method==Method.Put)
                {
                    request.AddParameter("application/json", scoobRelation, ParameterType.RequestBody);
                    request.RequestFormat = DataFormat.Json;
                }
                
                return client.Execute(request);
            }
            catch (Exception ex) 
            { 
                return null; 
            }
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
