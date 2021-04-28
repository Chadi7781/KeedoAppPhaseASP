using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class RequestFollowController : Controller
    {


        HttpClient httpClient;
        string baseAddress;

        public RequestFollowController()
        {
            baseAddress = "http://localhost:8082/SpringMVC/servlet/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: RequestFollow
        public ActionResult Index()
        {
            

            return View();
        }

        // GET: RequestFollow/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RequestFollow/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RequestFollow/Create
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

        // GET: RequestFollow/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RequestFollow/Edit/5
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

        // GET: RequestFollow/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RequestFollow/Delete/5
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
