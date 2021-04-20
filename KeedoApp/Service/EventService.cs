using KeedoApp.Helper;
using KeedoApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Service
{
    public class EventService
    {

        //Singleton instance 
        ConfigureHttpClient ConfigureHttpClient = ConfigureHttpClient.GetInstance();

        //singleton instance httpclient and set Uri
        HttpClient client = ConfigureHttpClient.httpClientGetInstance();

        //URL

        string springMvcUrl = ConfigureHttpClient.initiliazeHttpClient("SpringMVC/servlet");





        public HttpResponseMessage addEvent(FormCollection formCollection)
        {


            MultipartFormDataContent m = new MultipartFormDataContent();
            // var strPostData = JsonConvert.SerializeObject(formCollection["evJson"], new IsoDateTimeConverter());

            // m.Add(new StringContent(strPostData),"evJson");
            //m.Add(new StringContent(formCollection["image"]),"image");
            ///  string image = HttpContext.Current.Request["image"];
            ///string json = HttpContext.Current.Request["evJson"];
            ///   if (Directory.Exists(DirectoryPath))
          
                var filestream = new FileStream("C:/Users/Lenovo/Desktop/" + formCollection["image"], FileMode.Open);
            var fileName = System.IO.Path.GetFileName(formCollection["image"]);

            var stringContent = new StringContent(JsonConvert.SerializeObject(formCollection["evJson"]));
            System.Diagnostics.Debug.WriteLine(">>>>>>>>>>>" + stringContent);
            m.Add(stringContent, "evJson");

            
            m.Add(new StreamContent(filestream), "image", fileName);

            var response = client.PostAsync(springMvcUrl + "/event/add-event",
                m).ContinueWith(p => p.Result.EnsureSuccessStatusCode());

            if (response.IsCompleted)
                return response.Result;
            else
                return response.Result;

        }




    }

}



