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
    public class ResponseController : Controller
    {


        HttpClient httpClient;
        string baseAddress;

        public ResponseController()
        {
            baseAddress = "http://localhost:8082/SpringMVC/servlet/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Response
        public ActionResult Index()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Responses/retrieve-all-responses").Result;

            IEnumerable<Response> responses;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                responses = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Response>>().Result;
            }
            else
            {
                responses = null;

            }

            return View(responses);
        }

        // GET: Response/Details/5
        public ActionResult Details(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Responses/retrieve-response/" + id.ToString()).Result;
            Response response;
           

      
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                response = httpResponseMessage.Content.ReadAsAsync<Response>().Result;
            }
            else
            {
                response = null;
            }
           /*
            ViewBag.satisfaction = QuestionType.Satisfaction;
            ViewBag.rating = QuestionType.Stars;
            ViewBag.text = QuestionType.Text;
           */

            return View(response);
        }

        // GET: Response/Create
        public ActionResult Create(  )
        {



            return View();
        }

        // POST: Response/Create
        [HttpPost]
        public ActionResult Create(int id, Response response)
        {
            var postTask = httpClient.PostAsJsonAsync<Response>(baseAddress + "Responses/responseTo/" + id.ToString(), response);
            postTask.Wait();

            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();

        }

        // GET: Response/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Response/Edit/5
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

        // GET: Response/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Response/Delete/5
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
