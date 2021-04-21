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
    public class FeedbackController : Controller
    {
        HttpClient httpClient;
        string baseAddress;

        public FeedbackController()
        {
            baseAddress = "http://localhost:8082/SpringMVC/servlet/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



        // GET: Feedback
        public ActionResult Index()
        {
       
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress+"retrieve-all-feedbacks").Result;

            IEnumerable<Feedback> feedbacks;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                feedbacks = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Feedback>>().Result;
            }
            else
            {
                feedbacks = null;

            }



            return View(feedbacks);
        }



        // GET: Feedback/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Feedbacks/retrieve-feedback-details/" + id.ToString()).Result;
            Feedback feedback;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                feedback = httpResponseMessage.Content.ReadAsAsync<Feedback>().Result;
            }
            else
            {
                feedback = null;
            }

            return View(feedback);
        }



        // GET: Feedback/Create
        public ActionResult Create()
        {
          
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress+"meetings/get-all-meeting").Result;

            IEnumerable<Meeting> meetings;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.meetings = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Meeting>>().Result;
            }
            else
            {
                ViewBag.meetings = null;

            }



            return View();
        }

        // POST: Feedback/Create
        [HttpPost]
        public ActionResult Create(Feedback feedback , int idMeeting)
        {
            try
            {
          
                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress+"meetings/get-all-meeting").Result;

                var APIResponse = httpClient.PostAsJsonAsync<Feedback>(baseAddress + "/Feedbacks/new-feedback-of/" + idMeeting.ToString(), feedback).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                var jsonreponse = APIResponse.Result.Content.ReadAsAsync<String>().Result;
                ViewBag.SuccessMessage = jsonreponse;


                IEnumerable<Meeting> meetings;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    ViewBag.meetings = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Meeting>>().Result;
                }
                else
                {
                    ViewBag.meetings = null;

                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");


        }
        // GET: Feedback/Edit/5
        public ActionResult Edit(int id)
        {
           
            
            return View();
        }


        //
        // POST: /Products/Edit/5

        [HttpPost]
        public ActionResult Edit(int id,Feedback feedback)
        {

            var putTask = httpClient.PutAsJsonAsync<Feedback>(baseAddress + "Feedbacks/update-feedback/" + id.ToString(), feedback);
            putTask.Wait();

            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }

      
     
        // GET: Feedback/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Feedback/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
           
                //HTTP POST
                var putTask = httpClient.DeleteAsync(baseAddress+"/Feedbacks/delete-feedback/" + id.ToString());
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            
            return View();
        }


        // GET: Feedback
        public ActionResult FeedbackQuestions(int id)
        {

            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Questions/retrieve-feedback-questions/"+id.ToString()).Result;

            IEnumerable<Question> questions;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                questions = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Question>>().Result;
            }
            else
            {
                questions = null;

            }



            return View(questions);
        }
    }
}
