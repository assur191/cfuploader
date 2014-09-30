using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CFUploader
{
    public class Listener
    {
        Thread listenThread1;
        HttpListener listener;
        IAsyncResult result;

        public Listener()
        {
            listener = new HttpListener();
            listener.Prefixes.Add("http://+:8083/");
            //listener.Prefixes.Add("http://127.0.0.1:9000/");
            listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;

            listener.Start();
            this.listenThread1 = new Thread(new ParameterizedThreadStart(startlistener));
            listenThread1.Start();
        }

        private void startlistener(object s)
        {
            while (true)
            {
                ////blocks until a client has connected to the server
                ProcessRequest();
            }
        }

        private void ProcessRequest()
        {
            result = listener.BeginGetContext(ListenerCallback, listener);
            result.AsyncWaitHandle.WaitOne();
        }

        private void ListenerCallback(IAsyncResult result)
        {
            var context = listener.EndGetContext(result);
            Thread.Sleep(1000);
            var data_text = new StreamReader(context.Request.InputStream,
            context.Request.ContentEncoding).ReadToEnd();

            //functions used to decode json encoded data.
            var data1 = Uri.UnescapeDataString(data_text);
            string da = Regex.Unescape(data_text);         
            Dictionary<string, string> unserialized = JsonConvert.DeserializeObject<Dictionary<string, string>>(data_text);

            foreach (KeyValuePair<string, string> entry in unserialized) 
            {
                Debug.WriteLine("key: " + entry.Key + " value: " + entry.Value);
            }

            //var cleaned_data = System.Web.HttpUtility.UrlDecode(data_text);

            context.Response.StatusCode = 200;
            context.Response.StatusDescription = "OK";
            //context.Response.AddHeader("result", "result");

            //use this line to get your custom header data in the request.
            var headerText = context.Request.Headers;
            

            //use this line to send your response in a custom header
            //context.Response.Headers["mycustomResponseHeader"] = headerText;

            //MessageBox.Show(cleaned_data);
            context.Response.Close();
        }
    }
}
