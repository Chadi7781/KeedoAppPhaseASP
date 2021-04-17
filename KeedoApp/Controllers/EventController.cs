using KeedoApp.Helper;
using KeedoApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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



        public ActionResult create(Event events)
        {
            return View();

        }



        [HttpGet]
        public ActionResult Detail(int id)
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(springMvcUrl + "/event/retrieve-Event-ById/" + id.ToString()).Result;
            Event events;
           
            if (httpResponseMessage.IsSuccessStatusCode)
            {
          

                events = httpResponseMessage.Content.ReadAsAsync<Event>().Result;
                DateTime myDate2 = DateTime.Now;

                TimeSpan myDateResult;

                myDateResult =  events.Hour.TimeOfDay;

                double seconds = myDateResult.TotalSeconds;
                ViewBag.time = myDateResult;
 

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
