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
    public class KidController : Controller
    {
        // GET: Kid
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/kid/getAll").Result;

            IEnumerable<Kid> kids;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                kids = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Kid>>().Result;


            }
            else
            {
                kids = null;
            }
            return View(kids);
        }

        // GET: Kid/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage httpResponseMessage = client.GetAsync("SpringMVC/servlet/kid/get/"+id).Result;

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
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsJsonAsync("SpringMVC/servlet/kid/add", kid);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(kid);
        }

        // GET: Kid/Edit/5
        public ActionResult Edit(int id)
        {
            Kid kid=null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/kid/");
                //HTTP GET
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
                var putTask = client.PutAsJsonAsync<Kid>("up/"+id, kid);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

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

            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var putTask = client.DeleteAsync("SpringMVC/servlet/kid/del/" + id);
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
