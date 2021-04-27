using KeedoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class HomeController : Controller
    {


        HttpClient httpClient;
        string baseAddress;

        public HomeController()
        {
            baseAddress = "http://localhost:8082/SpringMVC/servlet/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        //Client


        public ActionResult IndexClient()
        {

            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Kindergartens/retrieve-all-kindergartens").Result;
            HttpResponseMessage httpResponseMessage2 = httpClient.GetAsync(baseAddress + "kid/static/nb").Result;
            HttpResponseMessage httpResponseMessage3 = httpClient.GetAsync(baseAddress + "daycare/nb").Result;

            IEnumerable<Kindergarden>  kindergartens;
            int kids;
            int daycares;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.kindergartens = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Kindergarden>>().Result;
            }
            else
            {
                ViewBag.kindergartens = null;

            }
            if (httpResponseMessage2.IsSuccessStatusCode)
            {

                ViewBag.kids = httpResponseMessage2.Content.ReadAsAsync<int>().Result;
            }
            else
            {
                ViewBag.kids = null;
            }

            if (httpResponseMessage3.IsSuccessStatusCode)
            {

                ViewBag.daycares = httpResponseMessage3.Content.ReadAsAsync<int>().Result;
            }
            else
            {
                ViewBag.daycares = null;
            }


            return View("IndexClient");
        }
        //Admin
        public ActionResult Index()
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "claims/count-claims").Result;
            HttpResponseMessage httpResponseMessage2 = httpClient.GetAsync(baseAddress + "Kindergartens/count-kindergartens").Result;
            HttpResponseMessage httpResponseMessage3 = httpClient.GetAsync(baseAddress + "count-feedbacks").Result;

            int claimNB,kindergartens,feedbacks;

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.claimNB = httpResponseMessage.Content.ReadAsAsync<int>().Result;
            }
            else
            {
                ViewBag.claimNB = null;

            }

            if (httpResponseMessage2.IsSuccessStatusCode)
            {
                ViewBag.kindergartens = httpResponseMessage2.Content.ReadAsAsync<int>().Result;
            }
            else
            {
                ViewBag.kindergartens = null;

            }
            if (httpResponseMessage3.IsSuccessStatusCode)
            {
                ViewBag.feedbacks = httpResponseMessage3.Content.ReadAsAsync<int>().Result;
            }
            else
            {
                ViewBag.feedbacks = null;

            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}