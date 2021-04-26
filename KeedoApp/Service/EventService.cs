using KeedoApp.Helper;
using KeedoApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
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






        /**************Display Event By Id (Detail)**************/

        public Event getEventById(int id)
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/event/retrieve-Event-ById/" + id.ToString()).Result;
            Event events = null;

            if (httpResponseMessage.IsSuccessStatusCode)
            {


                events = httpResponseMessage.Content.ReadAsAsync<Event>().Result;


            }
            else
            {
                events = null;
            }
            return events;
        }



        /***************Add Event ***************************/


        public HttpResponseMessage addEvent(FormCollection formCollection)
        {


            MultipartFormDataContent m = new MultipartFormDataContent();
            // var strPostData = JsonConvert.SerializeObject(formCollection["evJson"], new IsoDateTimeConverter());

            // m.Add(new StringContent(strPostData),"evJson");
            //m.Add(new StringContent(formCollection["image"]),"image");
            ///  string image = HttpContext.Current.Request["image"];
            ///string json = HttpContext.Current.Request["evJson"];
            ///   if (Directory.Exists(DirectoryPath))
            ///   


            //Desrialize 

            var list = new Dictionary<string, string>();
            list.Add("evJson", formCollection["evJson"]);
            string toJson = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);

            var filestream = new FileStream("C:/Users/Lenovo/Desktop/" + formCollection["image"], FileMode.Open);
            var fileName = System.IO.Path.GetFileName(formCollection["image"]);

            //  Newtonsoft.Json.Linq.JObject json = JObject.Parse(formCollection["evJson"]);

            var stringContent = new StringContent(formCollection["evJson"]);
            stringContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            System.Diagnostics.Debug.WriteLine(">>>>>>>>>>>" + stringContent);






            //Convert JSON into Model




            m.Add(stringContent, "evJson");


            m.Add(new StreamContent(filestream), "image", fileName);

            var response = client.PostAsync(springMvcUrl + "/event/add-event",
                m).ContinueWith(p => p.Result.EnsureSuccessStatusCode());

            System.Diagnostics.Debug.WriteLine("api == " + response.Result);
            if (response.IsCompleted)
                return response.Result;
            else
                return response.Result;

        }



        /*****************Delete Event ****************************/
        public bool deleteEventById(int id)
        {
            try
            {
                var APIResponse = client.DeleteAsync(springMvcUrl + "/event/delete-event/" + id.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }



        /*********************Update Event*************************/

        public bool Update(Event e, int id)
        {
            try
            {
                var APIResponse = client.PutAsJsonAsync<Event>(springMvcUrl + "/event/update-event/" + id, e);

                APIResponse.Wait();
                var result = APIResponse.Result;
                System.Diagnostics.Debug.WriteLine(APIResponse.Result);
                if (result.IsSuccessStatusCode)
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
        }



        /**************************Affecter Event Category*******************************/
        [HttpPost]
        public bool AffecterEventCategory(string category, int id)
        {

            client.PutAsync("event/affecter-category-event/" + category + "/" + id, null).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return true;
        }
    }



}
