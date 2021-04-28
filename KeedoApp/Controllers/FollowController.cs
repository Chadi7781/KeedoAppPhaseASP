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
    public class FollowController : Controller
    {

        HttpClient httpClient;
        string baseAddress;

        public FollowController()
        {
            baseAddress = "http://localhost:8082/SpringMVC/servlet/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        // GET: Follow
        public ActionResult Index()
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Follow/ownfollowers").Result;

            int follows;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.follows = httpResponseMessage.Content.ReadAsAsync<int>().Result;
            }
            else
            {
                ViewBag.follows = null;

            }

            return View();
        }

        // GET: Follow/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Follow/Create
        public ActionResult Follow()
        {


            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Follow(int id, Follow follow)
        {

            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));


            HttpResponseMessage httpResponseMessage1 = httpClient.GetAsync(baseAddress + "/userbyid/" + id).Result;
            User user;
            if (httpResponseMessage1.IsSuccessStatusCode)
            {

                user = httpResponseMessage1.Content.ReadAsAsync<User>().Result;
            }
            else
            {
                user = null;
            }
            var response = await httpClient.PostAsJsonAsync(baseAddress + "Follow/" + id, follow);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(follow);

        }

        // GET: Follow/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Follow/Edit/5
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

        // GET: Follow/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Follow/Delete/5
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
