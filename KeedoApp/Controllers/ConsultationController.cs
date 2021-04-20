using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
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
using Event = Google.Apis.Calendar.v3.Data.Event;

namespace KeedoApp.Controllers
{
    public class ConsultationController : Controller
    {
        static List<Event> DB =
             new List<Event>() {
                new Google.Apis.Calendar.v3.Data.Event(){
                    Id = "eventid" + 1,
                    Summary = "Google I/O 2015",
                    Location = "800 Howard St., San Francisco, CA 94103",
                    Description = "A chance to hear more about Google's developer products.",
                    Start = new EventDateTime()
                    {
                        DateTime = new DateTime(2019, 01, 13, 15, 30, 0),
                        TimeZone = "America/Los_Angeles",
                    },
                    End = new EventDateTime()
                    {
                        DateTime = new DateTime(2019, 01, 14, 15, 30, 0),
                        TimeZone = "America/Los_Angeles",
                    },
                     Recurrence = new List<string> { "RRULE:FREQ=DAILY;COUNT=2" },
                    Attendees = new List<EventAttendee>
                    {
                        new EventAttendee() { Email = "lpage@example.com"},
                        new EventAttendee() { Email = "sbrin@example.com"}
                    }
                }
             };
        // GET: Consultation
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

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
            ViewBag.kidFk = new SelectList( kids, "idKid", "FirstNameLastName");
            ViewBag.doctorFk = new SelectList(doctors, "idUser", "FirstNameLastName");

            return View();
        }

        // POST: Consultation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Consultation consultation)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsJsonAsync("SpringMVC/servlet/consult/add/"+consultation.kidFk+"/"+consultation.doctorFk, consultation);
            if (response.IsSuccessStatusCode)
             {
                 return RedirectToAction("Index");
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
            ViewBag.doctorFk = new SelectList(doctors, "idUser", "FirstNameLastName");
           
            return View(consultation);
        }

     
        // GET: Consultation/Edit/5
        public ActionResult Edit(int id)
        {
            Consultation consult = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");
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
                ViewBag.doctorFk = new SelectList(doctors, "idUser", "FirstNameLastName");

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

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Consultation>("consult/up/" + id, consult);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

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
                ViewBag.doctorFk = new SelectList(doctors, "idUser", "FirstNameLastName");
            }
            return View(consult);
        }

        // GET: Consultation/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

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
            client.BaseAddress = new Uri("http://localhost:8080");

            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var putTask = client.DeleteAsync("SpringMVC/servlet/consult/del/" + id);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }

        public void calendar()
        {
            string jsonFile = "Credentials-calendar-yasmin.json";
            string calendarId = @"xxxxxxxxxxxxx@group.calendar.google.com";

            string[] Scopes = { CalendarService.Scope.Calendar };

            ServiceAccountCredential credential;

            using (var stream =
                new FileStream(jsonFile, FileMode.Open, FileAccess.Read))
            {
                var confg = Google.Apis.Json.NewtonsoftJsonSerializer.Instance.Deserialize<JsonCredentialParameters>(stream);
                credential = new ServiceAccountCredential(
                   new ServiceAccountCredential.Initializer(confg.ClientEmail)
                   {
                       Scopes = Scopes
                   }.FromPrivateKey(confg.PrivateKey));
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Calendar API Sample",
            });

            var calendar = service.Calendars.Get(calendarId).Execute();
            Console.WriteLine("Calendar Name :");
            Console.WriteLine(calendar.Summary);

            Console.WriteLine("click for more .. ");
            Console.Read();


            // Define parameters of request.
            EventsResource.ListRequest listRequest = service.Events.List(calendarId);
            listRequest.TimeMin = DateTime.Now;
            listRequest.ShowDeleted = false;
            listRequest.SingleEvents = true;
            listRequest.MaxResults = 10;
            listRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = listRequest.Execute();
            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
            Console.WriteLine("click for more .. ");
            Console.Read();

            var myevent = DB.Find(x => x.Id == "eventid" + 1);

            var InsertRequest = service.Events.Insert(myevent, calendarId);

            try
            {
                InsertRequest.Execute();
            }
            catch (Exception)
            {
                try
                {
                    service.Events.Update(myevent, calendarId, myevent.Id).Execute();
                    Console.WriteLine("Insert/Update new Event ");
                    Console.Read();

                }
                catch (Exception)
                {
                    Console.WriteLine("can't Insert/Update new Event ");

                }
            }
        }
    }
}
