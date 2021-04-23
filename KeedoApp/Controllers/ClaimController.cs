using KeedoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using tn.esprit.pi.entities;

namespace KeedoApp.Controllers
{
    public class ClaimController : Controller
    {

        HttpClient httpClient;
        string baseAddress;

        public ClaimController()
        {
            baseAddress = "http://localhost:8082/SpringMVC/servlet/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Claim
        public ActionResult Index()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Claims/retrieve-all-claims").Result;

            IEnumerable<Claim> claims;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                claims = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Claim>>().Result;
            }
            else
            {
                claims = null;

            }




            return View(claims);
        }

        // GET: Claim/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "claims/retrieve-claim-details/" + id.ToString()).Result;

            Claim claim;
           
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                claim = httpResponseMessage.Content.ReadAsAsync<Claim>().Result;
            }
            else
            {
                claim = null;
            }
           

            return View(claim);
        }

        // GET: Claim/Create
        public ActionResult Create()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Kindergartens/retrieve-all-kindergartens").Result;

            IEnumerable<Kindergarden> kindergardens;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.kindergardens = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Kindergarden>>().Result;
            }
            else
            {
                ViewBag.kindergardens = null;

            }



            return View();
        }

        // POST: Claim/Create
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

        // GET: Claim/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Claim/Edit/5
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

        // GET: Claim/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Claim/Delete/5
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
