using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;

namespace CFUploader
{
    public static class SendRest
    {
        //private static RestClient _client;
        //public static List<string> TrackJson { get; set; }
        //public static string RestResponse { get; set; }

        public static void SendJson(string json)
        {
            var _client = new RestClient("http://10.0.10.10//");
            string TrackJson = json;

            RestRequest request = new RestRequest("temp_track", Method.POST);
            //request.RequestFormat = DataFormat.Json; // adds to POST or URL querystring based on Method   
            request.AddParameter("text/json", json, ParameterType.RequestBody);
            //request.AddBody(new { json });
            request.RequestFormat = DataFormat.Json;

            // easily add HTTP Headers
            //request.AddHeader("Content-Type", "application/json");
            string test = "";

            _client.ExecuteAsync(request, response =>
            {
                Console.WriteLine(response.Content);
            });
        }
        
    }
}
