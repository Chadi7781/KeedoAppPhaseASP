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
            HttpResponseMessage httpResponseMessage2 = httpClient.GetAsync(baseAddress + "Questions/retrieve-feedback-questions/" + id.ToString()).Result;
            Feedback feedback;
            IEnumerable<Question> questions;

            QuestionType questionType;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                feedback = httpResponseMessage.Content.ReadAsAsync<Feedback>().Result;
            }
            else
            {
                feedback = null;
            }
            if (httpResponseMessage2.IsSuccessStatusCode)
            {
                ViewBag.questions = httpResponseMessage2.Content.ReadAsAsync<IEnumerable<Question>>().Result;
            }
            else
            {  ViewBag.questions = null;
            }

            ViewBag.satisfaction = QuestionType.Satisfaction;
            ViewBag.rating = QuestionType.Stars;
            ViewBag.text = QuestionType.Text;


            return View(feedback);
        }



        // GET: Feedback/Create
        public ActionResult Create()
        {
          
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress+ "finished-meetings").Result;

            IEnumerable<Meeting> meetings;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                 meetings = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Meeting>>().Result;
            }
            else
            {
                 meetings = null;

            }

            ViewBag.meetingFK = new SelectList(meetings, "idMeeting", "typeMeeting");


            return View();
        }

        // POST: Feedback/Create
        [HttpPost]
        public async Task<ActionResult> Create(Feedback feedback )
        {

            var response = await httpClient.PostAsJsonAsync(baseAddress + "Feedbacks/new-feedback-of/" + feedback.meetingFk, feedback);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "finished-meetings").Result;
            IEnumerable<Meeting> meetings;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                meetings = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Meeting>>().Result;
            }
            else
            {
                meetings = null;
            }

            ViewBag.meetingFk = new SelectList(meetings, "idMeeting", "typeMeeting");

            return View(feedback);



        }
        // GET: Feedback/Edit/5
        public ActionResult Edit(int id)
        {


            Feedback feedback = null;



            var responseTask = httpClient.GetAsync(baseAddress + "Feedbacks/retrieve-feedback-details/" + id);
            // responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Feedback>();
                readTask.Wait();

                feedback = readTask.Result;
            }
            //------------
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "finished-meetings").Result;
            IEnumerable<Meeting> meetings;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                meetings = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Meeting>>().Result;
            }
            else
            {
                meetings = null;
            }

            ViewBag.meetingFK = new SelectList(meetings, "idMeeting", "description");


            return View(feedback);
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
                var putTask = httpClient.DeleteAsync(baseAddress+"Feedbacks/delete-feedback/" + id.ToString());
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
