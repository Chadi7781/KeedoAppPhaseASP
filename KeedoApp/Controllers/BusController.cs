using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using KeedoApp.Models;
using System.Threading.Tasks;

namespace KeedoApp.Controllers
{
    public class BusController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public BusController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/bus";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
       
        // GET: Bus
        public ActionResult Bus(string searchString)
        {


            IEnumerable<Bus> bus;
            HttpResponseMessage httpResponseMessage;
            if (String.IsNullOrEmpty(searchString))
            {
                System.Diagnostics.Debug.WriteLine("entered Bus");

                httpResponseMessage = httpClient.GetAsync(baseAddress + "/showBus").Result;


                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    bus = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Bus>>().Result;
                }
                else
                {
                    bus = null;
                }

                return View(bus);
            }
            else
            {
                httpResponseMessage = httpClient.GetAsync(baseAddress + "/BusSearch/?pattern=" + searchString).Result;
                if (httpResponseMessage.IsSuccessStatusCode)
                {

                    bus = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Bus>>().Result;
                }
                else
                {
                    bus = null;
                }

                return View(bus);



            }



            /*
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9293/SpringMVC/servlet/bus/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("showBus").Result;

            IEnumerable<Bus> bus;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                bus = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Bus>>().Result;


            }
            else
            {
                bus = null;
            }


            return View(bus);*/



        }

        // GET: Bus/Details/5
        public ActionResult Details(int idBus)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "/showbyid/" + idBus.ToString()).Result;
            Bus bus;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                bus = httpResponseMessage.Content.ReadAsAsync<Bus>().Result;
            }
            else
            {
                bus = null;
            }

            return View(bus);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Bus/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Bus bus, int idDriver)
        {


            string Baseurl = "http://localhost:9293/SpringMVC/servlet/bus/";

            using (var pb = new HttpClient())
            {
                pb.BaseAddress = new Uri(Baseurl);
                pb.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Add("X-Miva-API-Authorization", "MIVA xxxxxxxxxxxxxxxxxxxxxx");
                var response = await pb.PostAsJsonAsync("saveBus/" + idDriver.ToString(), bus);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Bus");
                }
            }
            return View(bus);


            /* HttpClient client = new HttpClient();
             client.BaseAddress = new Uri("http://localhost:9293");
             client.PostAsJsonAsync<Bus>("SpringMVC/servlet/bus/saveBus", bus).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

             return RedirectToAction("Bus");
         }*/

        }
        // GET: Bus/Edit/5
        public ActionResult Edit(int idBus)
         {

            return View();
        }

        // POST: Bus/Edit/5
        [HttpPost]
        public ActionResult Edit(int idBus, Bus bus)
        {
              //HTTP POST
            var putTask = httpClient.PutAsJsonAsync<Bus>(baseAddress + "/updateBus/" + idBus.ToString(), bus);
            putTask.Wait();

            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Bus");
            }
            return View(bus);

        }

        // GET: Bus/Delete/5
        public ActionResult Delete(int idBus)
        {
            return View();
        }

        // POST: Bus/Delete/5
        [HttpPost]
        public ActionResult Delete(int idBus, FormCollection collection)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9293/SpringMVC/servlet/bus/");

                //HTTP POST
                var putTask = client.DeleteAsync("deleteBus/" + idBus.ToString());
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Bus");
                }
            }
            return View();
        }
        }
    }

