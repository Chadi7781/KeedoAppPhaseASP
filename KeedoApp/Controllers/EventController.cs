using KeedoApp.Helper;
using KeedoApp.Models;
using KeedoApp.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class EventController : Controller
    {





        //Singleton instance 
        ConfigureHttpClient ConfigureHttpClient = ConfigureHttpClient.GetInstance();

        //singleton instance httpclient and set Uri(http://localhost:8084);
        HttpClient client = ConfigureHttpClient.httpClientGetInstance();

        //URL

        string springMvcUrl = ConfigureHttpClient.initiliazeHttpClient("SpringMVC/servlet");



        //Event Service
        EventService eventService = new EventService();



        // GET: Event
        public ActionResult ManageEvent()
        {
            IEnumerable<Event> events;

            try
            {
                HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/event/displayAllevents").Result;
                var method = client.GetAsync(springMvcUrl + "/event/displayEventsByCollAmount").Result.Content.ReadAsStringAsync().Result.ToString();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (httpResponseMessage.IsSuccessStatusCode)
                {

                    //recuperation 1 er json affichage events
                    ViewBag.events = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Event>>().Result;
                    //recuperation 2 eme json collamount

                    var deserial = JsonConvert.DeserializeObject<dynamic>(method);
                    var collAmount = deserial[0].CollAmount;
                    var Average = deserial[0].Average;
                    var topEventName = deserial[0].TopEvent;
                    ViewBag.collAmount = collAmount;
                    ViewBag.Average = Average;//@ViewBag.Average
                    ViewBag.topEventName = topEventName;

                }

                else
                {
                    ViewBag.events = null;
                }
                return View();
            }
            catch
            {
                return View("Error");
            }

        }




        [HttpGet]
        public ActionResult CreateEventModal()
        {
            return PartialView("_CreateEvent");
        }


        [HttpPost]
        public JsonResult CreateEvent(FormCollection formCollection)
        {
            var response = false;


            eventService.addEvent(formCollection);
              response = true;
        
            
            return new JsonResult { Data = new { response = response
    }
};


        }






        [HttpGet]
        public ActionResult Detail(int id)
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/event/retrieve-Event-ById/" + id.ToString()).Result;
            Event events;

            if (httpResponseMessage.IsSuccessStatusCode)
            {


                events = httpResponseMessage.Content.ReadAsAsync<Event>().Result;

                string imageDataURL = string.Format("data:image/png;base64,{0}", events.Image);
                if (imageDataURL == null)
                    ViewBag.ImageData = "Image null";
                else
                    ViewBag.ImageData = imageDataURL;

            }
            else
            {
                events = null;
            }
            return PartialView("_DetailEvent", events);
        }


        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //HTTP POST
            var putTask = client.DeleteAsync(springMvcUrl + "/delete-event/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("ManageEvent");
            }
            System.Diagnostics.Debug.WriteLine("entered here" + result);
            return View();
        }

    }
}
