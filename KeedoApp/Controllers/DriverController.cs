using KeedoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class DriverController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public DriverController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/driver";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        // GET: Driver
        public ActionResult Driver(string searchString)
        {


            IEnumerable<Driver> driver;
            HttpResponseMessage httpResponseMessage;
            if (String.IsNullOrEmpty(searchString))
            {
                System.Diagnostics.Debug.WriteLine("entered Driver");

                httpResponseMessage = httpClient.GetAsync(baseAddress + "/showDriver").Result;


                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    driver = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Driver>>().Result;
                }
                else
                {
                    driver = null;
                }

                return View(driver);
            }
            else
            {
                httpResponseMessage = httpClient.GetAsync(baseAddress + "/DriverSearch/?pattern=" + searchString).Result;
                if (httpResponseMessage.IsSuccessStatusCode)
                {

                    driver = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Driver>>().Result;
                }
                else
                {
                    driver = null;
                }

                return View(driver);



            }

                /*
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9293");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/driver/showDriver").Result;

                IEnumerable<Driver> drivers;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    drivers = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Driver>>().Result;


                }
                else
                {
                    drivers = null;
                }


                return View(drivers);*/
            }

        // GET: Driver/Details/5
        public ActionResult Details(int idDriver)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "/showbyid/" + idDriver.ToString()).Result;
            Driver driver;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                driver = httpResponseMessage.Content.ReadAsAsync<Driver>().Result;
            }
            else
            {
                driver = null;
            }

            return View(driver);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }


        [HttpPost]
        public ActionResult Create(Driver driver)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9293");
            client.PostAsJsonAsync<Driver>("SpringMVC/servlet/driver/saveDriver", driver).
                ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            return RedirectToAction("Driver");

        }




        public ActionResult Edit(int idDriver)
        {
            return View();
        }

        // POST: Driver/Edit/5
        [HttpPost]
        public ActionResult Edit(Driver driver)
        {
            //HTTP POST
            var putTask = httpClient.PutAsJsonAsync<Driver>("updatedriver", driver);
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Driver");
            }
            return View(driver);

        }

        // GET: Driver/Delete/5
        public ActionResult Delete(int idDriver)
        {
            return View();
        }

        // POST: Driver/Delete/5
        [HttpPost]
        public ActionResult Delete(int idDriver, FormCollection collection)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:9293/SpringMVC/servlet/driver/");

                //HTTP POST
                var putTask = client.DeleteAsync("deleteDriver/" + idDriver.ToString());
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Driver");
                }
            }
            return View();

        }
    }

    }

