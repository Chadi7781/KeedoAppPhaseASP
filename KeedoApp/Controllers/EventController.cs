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



        public IEnumerable<string> bestEventsParticipants()
        {
            IEnumerable<string> eventsPart = null;

            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/event/displayBestEventsByParticipations").Result;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.eventsPart = httpResponseMessage.Content.ReadAsAsync<IEnumerable<string>>().Result;

            }
            else
                ViewBag.eventsPart = null;

            return eventsPart;
        }



        // GET: Event
        public ActionResult ManageEvent()
        {
            IEnumerable<Event> events;

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


        [HttpGet]
        public ActionResult DetailEvent(int id)

        {
            Event e = eventService.getEventById(id);
            if (e != null)
            {
                ViewBag.ImageUrl = "error";
                var str = System.Text.Encoding.UTF8.GetString(e.Image);

                ViewBag.ImageUrl = "https://localhost:44330/Upload/" + str;
                return PartialView("_DetailEvent", e);

            }
            return View();

        }


        //Add Event Controller
        [HttpPost]
        public JsonResult CreateEvent(FormCollection formCollection)
        {
            var response = false;

            string folderPath = Server.MapPath("~/Upload/");  //Create a Folder in your Root directory on your solution.
            string fileName = formCollection["image"];
            string imagePath = folderPath + fileName;
            byte[] imageArray = System.IO.File.ReadAllBytes(formCollection["image"]);

            string base64ImageRepresentation = Convert.ToBase64String(imageArray);

            string base64StringData = "data:image/png;base64," + base64ImageRepresentation; // Your base 64 string data
            string cleandata = base64StringData.Replace("data:image/png;base64,", "");
            byte[] data = System.Convert.FromBase64String(cleandata);
            MemoryStream ms = new MemoryStream(data);
            System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
            img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg); 





            eventService.addEvent(formCollection);
                response = true;

                return new JsonResult
                {
                    Data = new
                    {
                        response = response
                    }
                };


            }





        //Get Create Event partial view

        [HttpGet]
        public ActionResult CreateEventModal()
        {
            return PartialView("_CreateEvent");
        }

        //Get Create Event partial view

        [HttpGet]
        public ActionResult UpdateEventModal(int id)
        {
            Event e = eventService.getEventById(id);
            if (e != null)
            {
                // string imageBase64Data = Convert.ToBase64String(e.Image);
                string imageDataURL = string.Format("data:image/png;base64,{0}", e.Image);
                if (imageDataURL == null)
                    //System.Diagnostics.Debug.WriteLine("Image null");
                    ViewBag.ImageData = "error";
                else
                    ViewBag.ImageData = imageDataURL;
                return PartialView("_UpdateEvent", e);

            }
            return View();
        }

        //Delete Event
        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {
            var status = false;


            if (eventService.deleteEventById(id))
            {

                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }



        //Update Event
        [HttpPost]
        public JsonResult Edit(Event Event)
        {


            int idEvent = Event.IdEvenement;

            var response = false;
            if (eventService.Update(Event, idEvent))
            {
                response = true;
            }
            return new JsonResult { Data = new { response = response } };
        }


        //Update Event
        [HttpPost]
        public JsonResult Affecter(string category, int id)
        {


            var response = false;
            if (eventService.AffecterEventCategory(category, id))
            {
                response = true;
            }
            return new JsonResult { Data = new { response = response } };
        }
    }
}

