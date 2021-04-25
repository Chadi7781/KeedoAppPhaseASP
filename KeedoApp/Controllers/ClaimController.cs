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
            HttpResponseMessage httpResponseMessage2 = httpClient.GetAsync(baseAddress + "count-claims").Result;

            IEnumerable<Claim> claims;
            //var  nbClaim;
       
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
            ClaimStatus skiped,processing,resolved;
           
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                claim = httpResponseMessage.Content.ReadAsAsync<Claim>().Result;
            }
            else
            {
                claim = null;
            }

            ViewBag.skiped = ClaimStatus.Skiped;
            ViewBag.processing = ClaimStatus.Processing;
            ViewBag.resolved = ClaimStatus.Resolved;

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


            Claim claim = null;
            var responseTask = httpClient.GetAsync(baseAddress + "claims/retrieve-claim-details/" + id);
            // responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Claim>();
                readTask.Wait();

                claim = readTask.Result;
            }
           
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Kindergartens/retrieve-all-kindergartens").Result;
            IEnumerable<Kindergarden> kindergardens;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                kindergardens = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Kindergarden>>().Result;
            }
            else
            {
                kindergardens = null;
            }

            ViewBag.kindergardenFk = new SelectList(kindergardens, "id", "name");


            return View(claim);
        }

        // POST: Claim/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Claim claim)
        {
            var putTask = httpClient.PutAsJsonAsync<Claim>(baseAddress + "claims/update-claim/" + id.ToString(), claim);
            putTask.Wait();

            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
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




        // GET: Claim/Edit/5
        public ActionResult ClaimProcessing(int id)
        {
            Claim claim = null;
            var responseTask = httpClient.GetAsync(baseAddress + "claims/retrieve-claim-details/" + id);
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Claim>();
                readTask.Wait();
                claim = readTask.Result;
            }
            return View(claim);
        }

        // POST: Claim/Edit/5
        [HttpPost]
        public ActionResult ClaimProcessing(int id, Claim claim)
        {
            var putTask = httpClient.PutAsJsonAsync<Claim>(baseAddress + "claims/process-claim/" + id.ToString(), claim);
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
