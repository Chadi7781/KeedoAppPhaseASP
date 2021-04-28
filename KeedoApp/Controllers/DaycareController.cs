using KeedoApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using tn.esprit.pi.entities;

namespace KeedoApp.Controllers
{
    public class DaycareController : Controller
    {
        // GET: Daycare
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("daycare/getAll").Result;

            IEnumerable<Daycare> daycares;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                daycares = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Daycare>>().Result;

            }
            else
            {
                daycares = null;
            }
            return View(daycares);
        }

        // GET: Daycare/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");
            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("daycare/get/" + id).Result;

            Daycare daycare;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                daycare = httpResponseMessage.Content.ReadAsAsync<Daycare>().Result;
            }
            else
            {
                daycare = null;
            }
            return View(daycare);
        }

        // GET: Daycare/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Daycare/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Daycare daycare)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            var response = await client.PostAsJsonAsync("daycare/add", daycare);
            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ReadAsStringAsync().Result.ToString().Equals("1"))
                {
                    this.AddNotification("Can't add daycare because date begin is after the date end !!", NotificationType.ERROR);
                }
                else
                {
                    this.AddNotification("Daycare added successfully !", NotificationType.SUCCESS);
                    return RedirectToAction("Index");
                }

            }
            return View(daycare);
        }

        // GET: Daycare/Edit/5
        public ActionResult Edit(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");
            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("daycare/get/" + id).Result;

            Daycare daycare;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                daycare = httpResponseMessage.Content.ReadAsAsync<Daycare>().Result;
            }
            else
            {
                daycare = null;
            }
            return View(daycare);
        }

        // POST: Daycare/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Daycare daycare)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");
                var _AccessToken = Session["AccessToken"];
                client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Daycare>("daycare/update/" + id, daycare);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    this.AddNotification("Dayacre updated successfully !", NotificationType.SUCCESS);
                    return RedirectToAction("Index");
                }
            }
            return View(daycare);
        }

        // GET: Daycare/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");
            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("daycare/get/" + id).Result;

            Daycare daycare;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                daycare = httpResponseMessage.Content.ReadAsAsync<Daycare>().Result;
            }
            else
            {
                daycare = null;
            }
            return View(daycare);
        }

        // POST: Daycare/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");
            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var putTask = client.DeleteAsync("daycare/del/" + id);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                this.AddNotification("Daycare deleted successfully !", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
