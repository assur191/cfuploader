using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace CFUploader
{
    public static class SendRest
    {
        public static string SendJson(string json)
        {
            var _client = new RestClient("http://10.0.10.10//");
            string TrackJson = json;
            string jsonResponse = "";

            RestRequest request = new RestRequest("temp_track", Method.POST);
            request.AddParameter("text/json", json, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            //_client.ExecuteAsync(request, response =>
            //{
            //    Debug.WriteLine(response.Content);   
            //    jsonResponse = response.Content;
            //});

            IRestResponse response = _client.Execute(request);
            string content = response.Content; // raw content as string

            return content;
        }

    // code from here: http://dotnetcodr.com/2013/01/10/how-to-post-a-multipart-http-message-to-a-web-service-in-c-and-handle-it-with-java/
    public static void SendFilesToServer(Dictionary<string, string> fileFullPaths)
        {
            HttpClient httpClient = new HttpClient();

            foreach (KeyValuePair<string, string> entry in fileFullPaths)
            {
                FileInfo fi = new FileInfo(entry.Value);
                string fileName = fi.Name;
                byte[] fileContents = File.ReadAllBytes(fi.FullName);
                Uri webService = new Uri(@"http://10.0.10.10//temp_track_save_image/" + entry.Key);
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, webService);
                requestMessage.Headers.ExpectContinue = false;

                MultipartFormDataContent multiPartContent = new MultipartFormDataContent("----MyGreatBoundary");
                ByteArrayContent byteArrayContent = new ByteArrayContent(fileContents);
                byteArrayContent.Headers.Add("Content-Type", "application/octet-stream");                
                multiPartContent.Add(byteArrayContent, "album_cover", fileName);                
                requestMessage.Content = multiPartContent;

                try
                {
                    Task<HttpResponseMessage> httpRequest = httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
                    HttpResponseMessage httpResponse = httpRequest.Result;
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    HttpContent responseContent = httpResponse.Content;

                    if (responseContent != null)
                    {
                        Task<String> stringContentsTask = responseContent.ReadAsStringAsync();
                        String stringContents = stringContentsTask.Result;
                        Debug.WriteLine(stringContents);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                } 
            }
        }
        
    }
}
