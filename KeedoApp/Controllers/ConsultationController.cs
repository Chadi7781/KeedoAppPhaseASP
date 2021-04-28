
using KeedoApp.Extensions;
using KeedoApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class ConsultationController : Controller
    {

        // GET: Consultation
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("consult/getAll").Result;

            IEnumerable<Consultation> consultations;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                consultations = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Consultation>>().Result;

            }
            else
            {
                consultations = null;
            }
            return View(consultations);
        }

        // GET: Consultation/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("consult/get/" + id).Result;

            Consultation consult;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                consult = httpResponseMessage.Content.ReadAsAsync<Consultation>().Result;
            }
            else
            {
                consult = null;
            }
            return View(consult);
        }

        // GET: Consultation/Create
        public ActionResult Create()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("kid/getAll").Result;
            HttpResponseMessage httpResponseMessage2 = client.GetAsync("consult/getDoctors").Result;
            IEnumerable<User> doctors;
            IEnumerable<Kid> kids;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                kids = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Kid>>().Result;
            }
            else
            {
                kids = null;
            }
            if (httpResponseMessage2.IsSuccessStatusCode)
            {
                doctors = httpResponseMessage2.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
            else
            {
                doctors = null;
            }
            ViewBag.kidFk = new SelectList(kids, "idKid", "FirstNameLastName");
            ViewBag.doctorFk = new SelectList(doctors, "idUser", "ReturnFirstLast");

            return View();
        }

        // POST: Consultation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Consultation consultation)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsJsonAsync("SpringMVC/servlet/consult/add/" + consultation.kidFk + "/" + consultation.doctorFk, consultation);
            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ReadAsStringAsync().Result.ToString().Equals("1"))
                {
                    this.AddNotification("Wrong date !!", NotificationType.WARNING);
                }
                else if (response.Content.ReadAsStringAsync().Result.ToString().Equals("2"))
                {
                    this.AddNotification("Consultation added successfully !", NotificationType.SUCCESS);
                    return RedirectToAction("Index");
                }
                else
                {
                    this.AddNotification("Doctor not available for this date !!", NotificationType.WARNING);
                }

            }

            //--------

            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/kid/getAll").Result;
            HttpResponseMessage httpResponseMessage2 = client.GetAsync("SpringMVC/servlet/consult/getDoctors").Result;
            IEnumerable<User> doctors;
            IEnumerable<Kid> kids;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                kids = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Kid>>().Result;
            }
            else
            {
                kids = null;
            }
            if (httpResponseMessage2.IsSuccessStatusCode)
            {
                doctors = httpResponseMessage2.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
            else
            {
                doctors = null;
            }
            ViewBag.kidFk = new SelectList(kids, "idKid", "FirstNameLastName");
            ViewBag.doctorFk = new SelectList(doctors, "idUser", "ReturnFirstLast");

            return View(consultation);
        }


        // GET: Consultation/Edit/5
        public ActionResult Edit(int id)
        {
            Consultation consult = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

                var _AccessToken = Session["AccessToken"];
                client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

                //HTTP GET
                var responseTask = client.GetAsync("consult/get/" + id);
                // responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Consultation>();
                    readTask.Wait();

                    consult = readTask.Result;
                }
                //------------
                HttpResponseMessage httpResponseMessage = client.GetAsync("kid/getAll").Result;
                HttpResponseMessage httpResponseMessage2 = client.GetAsync("consult/getDoctors").Result;
                IEnumerable<User> doctors;
                IEnumerable<Kid> kids;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    kids = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Kid>>().Result;
                }
                else
                {
                    kids = null;
                }
                if (httpResponseMessage2.IsSuccessStatusCode)
                {
                    doctors = httpResponseMessage2.Content.ReadAsAsync<IEnumerable<User>>().Result;
                }
                else
                {
                    doctors = null;
                }
                ViewBag.kidFk = new SelectList(kids, "idKid", "FirstNameLastName");
                ViewBag.doctorFk = new SelectList(doctors, "idUser", "ReturnFirstLast");

            }
            return View(consult);
        }

        // POST: Consultation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Consultation consult)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

                var _AccessToken = Session["AccessToken"];
                client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Consultation>("consult/up/" + id, consult);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    this.AddNotification("Consultation updated successfully !", NotificationType.SUCCESS);
                    return RedirectToAction("Index");
                }
                //------------
                HttpResponseMessage httpResponseMessage = client.GetAsync("kid/getAll").Result;
                HttpResponseMessage httpResponseMessage2 = client.GetAsync("consult/getDoctors").Result;
                IEnumerable<User> doctors;
                IEnumerable<Kid> kids;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    kids = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Kid>>().Result;
                }
                else
                {
                    kids = null;
                }
                if (httpResponseMessage2.IsSuccessStatusCode)
                {
                    doctors = httpResponseMessage2.Content.ReadAsAsync<IEnumerable<User>>().Result;
                }
                else
                {
                    doctors = null;
                }
                ViewBag.kidFk = new SelectList(kids, "idKid", "FirstNameLastName");
                ViewBag.doctorFk = new SelectList(doctors, "idUser", "ReturnFirstLast");
            }
            return View(consult);
        }

        // GET: Consultation/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("consult/get/" + id).Result;

            Consultation consult;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                consult = httpResponseMessage.Content.ReadAsAsync<Consultation>().Result;
            }
            else
            {
                consult = null;
            }

            return View(consult);
        }

        // POST: Consultation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var putTask = client.DeleteAsync("consult/del/" + id);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                this.AddNotification("Consultation deleted successfully !", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult ToDay()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("consult/getAll/ToDay").Result;

            IEnumerable<Consultation> consultations;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                consultations = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Consultation>>().Result;
                return View(consultations);
            }
            else
            {
                ViewBag.message = "there is no consultation for today !";
                consultations = null;
            }
            return View(consultations);
        }
    }
}
