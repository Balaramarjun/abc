using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TestsReport.Classes;

namespace TestsReport.Helpers
{
    public class RestAPI
    {
        // Creatd the API key on 8-Aug-2021. This key is vaild for one year and expires on 9-Aug-2022
        // You will get unthorized access error once the token expires in line #122
        // URL to create the new key https://dev.azure.com/AnthologyInc-01/_usersSettings/tokens
        private const string API_KEY = "alr7yjzrgvvzt7vcv2t7amdlgox2q7u7mw4gctqivobqe4ua7nfa";

        private static string pipeline = string.Empty;
        //private static string baseAddress = "https://dev.azure.com/AnthologyInc-01/Student/";
        private static string urlDefintionId = "_apis/build/definitions";        
        private static string urlBuildId = "_apis/build/latest/";
        private static string urlToBuild = "_build/results";
        public static async Task<Build> GetBuildInformation(string pipelineName, int buildId, string buildNumber, string baseAddress)
        {
            Build build = new Build();
            try
            {
                pipeline = pipelineName;
                build.Name = pipelineName;
                build.DefinitionId = await GetBuildDefinitionId(baseAddress);
                dynamic obj = await GetBuildId(build.DefinitionId, buildId, buildNumber, baseAddress);
                build.Id = obj.Id;
                build.BuildNumber = buildNumber; // obj.Name;
                build.Url = GetBuildUrl(build.Id, baseAddress);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return build;
        }

        private static string GetBuildUrl(int buildId, string baseAddress)
        {
            StringBuilder str = new StringBuilder();
            str = str.Append(baseAddress).Append(urlToBuild)
                .Append($"?buildId={buildId}").Append("&view=ms.vss-test-web.build-test-results-tab");
            return str.ToString();
        }
        private static async Task<int> GetBuildDefinitionId(string baseAddress)
        {
            int id;
            StringBuilder str = new StringBuilder();
            str = str.Append(baseAddress).Append(urlDefintionId)
                .Append($"?name={pipeline}&api-version=6.0");
            string result = await RestApi(str.ToString(), baseAddress);       
            try
            {
                JObject json = ParseJson(result);
                id = json["value"][0]["id"].ToObject<int>();
            }
            catch (JsonReaderException ex)
            {
                throw ex;
            }
            return id;
        }

        private static async Task<object> GetBuildId(int definitionId, int buildId, string buildNumber, string baseAddress)
        {
            int id;
            string name = string.Empty;
            StringBuilder str = new StringBuilder();
            str = str.Append(baseAddress).Append(urlBuildId)
                .Append($"{definitionId}?api-version=6.0-preview.1");
            string result = await RestApi(str.ToString(), baseAddress);        
            try
            {
                JObject json = ParseJson(result);
                id = buildId; // json["id"].ToObject<int>();
                name = buildNumber; // json["buildNumber"].ToObject<string>();
            }
            catch (JsonReaderException ex)
            {
                throw ex;
            }
            return new { Id = id, Name = name };
        }

        private static JObject ParseJson(string json)
        {
            JObject jsonObj = new JObject();
            try
            {
                jsonObj = JObject.Parse(json); 
            }
            catch (JsonReaderException ex)
            {
                throw ex;
            }
            return jsonObj;
        }

        private static async Task<string> RestApi(string url, string baseAddress)
        {
            //encode your personal access token                   
            string credentials = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", "", API_KEY)));

            string result = null;

            //use the httpclient
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{baseAddress}");  //url of your organization
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

                //connect to the REST endpoint            
                HttpResponseMessage response = client.GetAsync(url).Result;

                //check to see if we have a successful response
                if (response.IsSuccessStatusCode)
                {
                    //set the viewmodel from the content in the response
                    //viewModel = response.Content.ReadAsAsync<ListOfProjectsResponse.Projects>().Result;
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            return result;

        }
    }
}
