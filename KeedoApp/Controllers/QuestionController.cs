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
    public class QuestionController : Controller
    {

        HttpClient httpClient;
        string baseAddress;
      
        public QuestionController()
        {
            baseAddress = "http://localhost:8082/SpringMVC/servlet/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Question
        public ActionResult Index()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Questions/retrieve-all-questions").Result;

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

        // GET: Question/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {

            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Questions/retrieve-question-details/" + id.ToString()).Result;
            Question question;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                question = httpResponseMessage.Content.ReadAsAsync<Question>().Result;

            }
            else
            {
                question = null;
            }

            return View(question);
        }

        // GET: Question/Create
        public ActionResult Create()
        {


            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "retrieve-all-feedbacks").Result;
            
            IEnumerable<Feedback> feedbacks;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                feedbacks = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Feedback>>().Result;
            }
            else
            {
                feedbacks = null;

            }


            ViewBag.feedbackFk = new SelectList(feedbacks, "idFeedback", "title");

            return View();
        }

        // POST: Question/Create
        [HttpPost]
        public async Task<ActionResult>  Create(Question question)
        {
        

                var response = await httpClient.PostAsJsonAsync(baseAddress+"Questions/new-question-of/" + question.feedbackFk, question);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "retrieve-all-feedbacks").Result;
                IEnumerable<Feedback> feedbacks;
              
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    feedbacks = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Feedback>>().Result;
                }
                else
                {
                    feedbacks = null;
                }

                ViewBag.feedbackFk = new SelectList(feedbacks, "idFeedback", "title");

                return View(question);

            }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            Question question = null;



            var responseTask = httpClient.GetAsync(baseAddress+ "Questions/retrieve-question-details/" + id);
                // responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Question>();
                    readTask.Wait();

                question = readTask.Result;
                }
            //------------
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "retrieve-all-feedbacks").Result;
            IEnumerable<Feedback> feedbacks;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                feedbacks = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Feedback>>().Result;
                }
                else
                {
                feedbacks = null;
                }

            ViewBag.feedbackFk = new SelectList(feedbacks, "idFeedback", "title");


            return View(question);
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Question question)
        {
            var putTask = httpClient.PutAsJsonAsync<Question>(baseAddress + "Questions/update-question/" + id.ToString(), question);
            putTask.Wait();

            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }
       
        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var putTask = httpClient.DeleteAsync(baseAddress + "Questions/delete-question/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
