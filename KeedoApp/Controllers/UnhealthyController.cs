using KeedoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class UnhealthyController : Controller
    {
        HttpClient httpClient;
        string baseAddress;
        public UnhealthyController()
        {
            baseAddress = "http://localhost:9293/SpringMVC/servlet/UnhealthyWords";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        // GET: Unhealthy
        public ActionResult UnhealthyWords()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "/get-all-unhealthy").Result;
            IEnumerable<UnhealthyWord> words;

            if (httpResponseMessage.IsSuccessStatusCode)
            {

                words = httpResponseMessage.Content.ReadAsAsync<IEnumerable<UnhealthyWord>>().Result;
            }
            else
            {
                words = null;
            }

            return View(words);
        }



        // GET: Unhealthy/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unhealthy/Create
        [HttpPost]
        public ActionResult Create(UnhealthyWord unhealthy)
        {

            var postTask = httpClient.PostAsJsonAsync<UnhealthyWord>(baseAddress + "/add", unhealthy);
            postTask.Wait();

            var result = postTask.Result;


                return RedirectToAction("UnhealthyWords");
           
        }

        // GET: Unhealthy/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Unhealthy/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UnhealthyWord unhealthy)
        {
            //HTTP POST
            var putTask = httpClient.PutAsJsonAsync<UnhealthyWord>(baseAddress + "/update/" + id.ToString(), unhealthy);
            putTask.Wait();

            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("UnhealthyWords");
            }
            return View();
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //HTTP POST
            var putTask = httpClient.DeleteAsync(baseAddress + "/delete/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("UnhealthyWords");
            }
            return View();
        }
    }
}