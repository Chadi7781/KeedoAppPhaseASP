using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class UserController : Controller
    {
        HttpClient httpClient;
        string baseAddress;

        public UserController()
        {
            baseAddress = "http://localhost:8080/SpringMVC/servlet/User/Service";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = Session["AccessToken"];
            var _AccessToken = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJGaXJzdHVzZSIsImlhdCI6MTYxODA4Mjg5NSwiZXhwIjoxNjE4OTQ2ODk1fQ.0idJvRoG6nKjb0sMevkxwl99PdbQtfD8JXOzoaqssjxI55saals2JpH9nYcnWhs3ndtrfOcaRvgNBKY1LUh-rQ";
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer "+_AccessToken));
        }

        // GET: User
        public ActionResult GestionUtilisateur()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "/findall").Result;
            //IEnumerable<Models.User> users;
            if (httpResponseMessage.IsSuccessStatusCode) {
                ViewBag.users = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.User>>().Result;
            }
            else {
                ViewBag.users = "erreur";
            }
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
