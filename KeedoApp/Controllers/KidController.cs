using KeedoApp.Extensions;
using KeedoApp.Models;
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
    public class KidController : Controller
    {
        // GET: Kid
        public ActionResult Index()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("kid/getAll").Result;

            IEnumerable<Kid> kids;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                kids = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Kid>>().Result;
                foreach (Kid kid in kids)
                {
                    HttpResponseMessage httpResponseMessage2 = client.GetAsync("kid/daycare/testA/" + kid.idKid).Result;
                    if (httpResponseMessage2.Content.ReadAsStringAsync().Result.ToString().Equals("1"))
                    {
                        kid.affect = "Affected";
                    }
                    else
                    {
                        kid.affect = "Not affected";
                    }
                }

            }
            else
            {
                kids = null;
            }
            return View(kids);
        }

        [HttpPost]
        public ActionResult Index(String filtre)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("kid/getAll").Result;

            IEnumerable<Kid> kids;
            kids = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Kid>>().Result;
            if (!String.IsNullOrEmpty(filtre))
            {
                kids = kids.Where(p => p.firstName.ToString().Contains(filtre)).ToList();
            }

            foreach (Kid kid in kids)
            {
                HttpResponseMessage httpResponseMessage2 = client.GetAsync("kid/daycare/testA/" + kid.idKid).Result;
                if (httpResponseMessage2.Content.ReadAsStringAsync().Result.ToString().Equals("1"))
                {
                    kid.affect = "Affected";
                }
                else
                {
                    kid.affect = "Not affected";
                }
            }
            return View(kids);
        }
        // GET: Kid/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/kid/get/" + id).Result;

            Kid kid;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                kid = httpResponseMessage.Content.ReadAsAsync<Kid>().Result;
            }
            else
            {
                kid = null;
            }
            return View(kid);
        }

        // GET: Kid/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kid/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Kid kid)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsJsonAsync("SpringMVC/servlet/kid/add", kid);

            if (response.IsSuccessStatusCode)
            {
                if (response.Content.ReadAsStringAsync().Result.ToString().Equals("1"))
                {
                    this.AddNotification("Wrong date !!", NotificationType.WARNING);
                }
                else
                {
                    this.AddNotification("Kid added successfully !", NotificationType.SUCCESS);
                    return RedirectToAction("Index");
                }
            }

            return View(kid);
        }

        // GET: Kid/Edit/5
        public ActionResult Edit(int id)
        {
            Kid kid = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/kid/");
                //HTTP GET
                var _AccessToken = Session["AccessToken"];
                client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

                var responseTask = client.GetAsync("get/" + id);
                // responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Kid>();
                    readTask.Wait();

                    kid = readTask.Result;
                }
            }
            return View(kid);
        }

        // POST: Kid/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Kid kid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/kid/");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<Kid>("up/" + id, kid);

                var _AccessToken = Session["AccessToken"];
                client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    this.AddNotification("Kid edited successfully !", NotificationType.SUCCESS);
                    return RedirectToAction("Index");
                }
            }
            return View(kid);
        }

        // GET: Kid/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/kid/get/" + id).Result;

            Kid kid;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                kid = httpResponseMessage.Content.ReadAsAsync<Kid>().Result;
            }
            else
            {
                kid = null;
            }
            return View(kid);
        }

        // POST: Kid/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var putTask = client.DeleteAsync("SpringMVC/servlet/kid/del/" + id);
            putTask.Wait();
            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {
                this.AddNotification("Kid deleted successfully !", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Affect(int idk)
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
            ViewBag.idk = idk;
            return View(daycares);
        }

        public ActionResult Affect2(int idk, int idD)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage httpResponseMessage = client.GetAsync("kid/daycare/aff/" + idk + "/" + idD).Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                if (httpResponseMessage.Content.ReadAsStringAsync().Result.ToString().Equals("1"))
                {
                    this.AddNotification("Kid already exists !", NotificationType.ERROR);
                    return RedirectToAction("Affect", new { idk = idk });
                }
                else if (httpResponseMessage.Content.ReadAsStringAsync().Result.ToString().Equals("2"))
                {
                    this.AddNotification("Kid affected to daycare successfully !", NotificationType.SUCCESS);
                    return RedirectToAction("Index");
                }
                else
                {
                    this.AddNotification("Daycare saturated !", NotificationType.ERROR);
                    return RedirectToAction("Affect", new { idk = idk });
                }

            }

            return RedirectToAction("Index");
        }

        public ActionResult Disaffect(int idk)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            HttpResponseMessage httpResponseMessageK = client.GetAsync("kid/get/" + idk).Result;
            Kid kid;
            //if (httpResponseMessageK.IsSuccessStatusCode)
            //{
            kid = httpResponseMessageK.Content.ReadAsAsync<Kid>().Result;
            // }
            int idD = kid.Daycare.idDaycare;
            System.Diagnostics.Debug.WriteLine("idD::: " + idD);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("kid/daycare/del/" + idk + "/" + idD).Result;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                this.AddNotification("Kid disaffected successfully !", NotificationType.SUCCESS);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        public ActionResult SortName()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");

            var _AccessToken = Session["AccessToken"];
            client.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("kid/Asc").Result;

            IEnumerable<Kid> kids;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                kids = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Kid>>().Result;
                foreach (Kid kid in kids)
                {
                    HttpResponseMessage httpResponseMessage2 = client.GetAsync("kid/daycare/testA/" + kid.idKid).Result;
                    if (httpResponseMessage2.Content.ReadAsStringAsync().Result.ToString().Equals("1"))
                    {
                        kid.affect = "Affected";
                    }
                    else
                    {
                        kid.affect = "Not affected";
                    }
                }

            }
            else
            {
                kids = null;
            }
            return View(kids);
        }
    }

}
