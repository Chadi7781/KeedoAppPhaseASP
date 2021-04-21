using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class LoginInscriptionController : Controller
    {
        HttpClient httpClient;
        string baseAddress;

        public LoginInscriptionController () {

            baseAddress = "http://localhost:8080/SpringMVC/servlet/User/Access";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        // GET: LoginInscription
        public ActionResult Index()
        {
            return View();
        }

        // GET: LoginInscription/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginInscription/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginInscription/Create
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

        // GET: LoginInscription/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginInscription/Edit/5
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

        // GET: LoginInscription/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginInscription/Delete/5
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
