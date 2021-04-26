using KeedoApp.Helper;
using KeedoApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class HistoryController : Controller
    {



        //Singleton instance 
        ConfigureHttpClient ConfigureHttpClient = ConfigureHttpClient.GetInstance();

        //singleton instance httpclient and set Uri(http://localhost:8084);
        HttpClient client = ConfigureHttpClient.httpClientGetInstance();

        //URL

        string springMvcUrl = ConfigureHttpClient.initiliazeHttpClient("SpringMVC/servlet");
        // GET: History
        public ActionResult History()
        {
            HttpResponseMessage httpResponseMessage1 = client.GetAsync(springMvcUrl + "/notification/displayNotifications").Result;
            HttpResponseMessage httpResponseMessage2 = client.GetAsync(springMvcUrl + "/donation/event/displayDonations").Result;
            HttpResponseMessage httpResponseMessage3 = client.GetAsync(springMvcUrl + "/event/retrieve-all-Participations").Result;

            if (httpResponseMessage1.IsSuccessStatusCode)
            {
                ViewBag.notifications = httpResponseMessage1.Content.ReadAsAsync<IEnumerable<Notification>>().Result;
              
                //ViewBag.participants = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Participants>>().Result;

            }
            if (httpResponseMessage2.IsSuccessStatusCode)
            {
                //          var desrializeDonations = JsonConvert.DeserializeObject<dynamic>(httpResponseMessage2.Content.ReadAsStringAsync().Result.ToString());


                ViewBag.donations = httpResponseMessage2.Content.ReadAsAsync<IEnumerable<Donation>>().Result;

            }
            if (httpResponseMessage3.IsSuccessStatusCode)
            {
                //          var desrializeDonations = JsonConvert.DeserializeObject<dynamic>(httpResponseMessage2.Content.ReadAsStringAsync().Result.ToString());


                ViewBag.participants = httpResponseMessage3.Content.ReadAsAsync<IEnumerable<Participation>>().Result;

            }

            return View();
        }

        // GET: History/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: History/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: History/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: History/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: History/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: History/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: History/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
