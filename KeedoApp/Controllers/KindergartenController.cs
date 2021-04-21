using KeedoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers.Kindergarten
{
    public class KindergartenController : Controller
    
    
    {

        HttpClient httpClient;
        string baseAddress;

        public KindergartenController()
        {
            baseAddress = "http://localhost:8082/SpringMVC/servlet/";
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Kindergarten
        public ActionResult Index()
        {
           // Session["AccessToken"]= "Bearer eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJhZG1pbiIsImlhdCI6MTYxODI2NjEyNiwiZXhwIjoxNjE5MTMwMTI2fQ.JjxadD-vCeyuBGMk4HpG2NebXyqxOkO8rbbuPNVMKLGYiJDLfeiUbhA-ucs3ir1LPeC9YJnZ1AgLB3kq6SJuCQ";
            
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress+"Kindergartens/retrieve-all-kindergartens").Result;

            IEnumerable<Kindergarden> kindergardens;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                kindergardens = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Kindergarden>>().Result;
            }
            else
            {
                kindergardens = null;

            }
            


            return View(kindergardens);

        }

        // GET: Kindergarten/Details/5
       


        [HttpGet]
        public ActionResult Details(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "Kindergartens/retrieve-kindergarten-details/" + id.ToString()).Result;
            Kindergarden kindergarden;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                kindergarden = httpResponseMessage.Content.ReadAsAsync<Kindergarden>().Result;
            }
            else
            {
                kindergarden = null;
            }

            return View(kindergarden);
        }
        // GET: Kindergarten/Create
        public ActionResult Create()
        {


            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress+"SpringMVC/servlet/User/Service/findall").Result;

            IEnumerable<User> directors;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.directors = httpResponseMessage.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
            else
            {
                ViewBag.directors = null;

            }



            return View();
        }

        // POST: Kindergarten/Create
        [HttpPost]
        public ActionResult Create(Kindergarden kindergarden ,int director)        {

            try
            {
                
                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress+"SpringMVC/servlet/User/Service/findall").Result;

                var APIResponse = httpClient.PostAsJsonAsync<Kindergarden>(baseAddress + "/Kindergartens/add-kindergarden/" + director.ToString(), kindergarden).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                var jsonreponse = APIResponse.Result.Content.ReadAsAsync<String>().Result;
                ViewBag.SuccessMessage = jsonreponse;


                IEnumerable<User> directors;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    ViewBag.directors = httpResponseMessage.Content.ReadAsAsync<IEnumerable<User>>().Result;
                }
                else
                {
                    ViewBag.directors = null;

                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
                       
           
            }

        // GET: Kindergarten/Edit/5
        public ActionResult Edit(int id)
        {
           
            return View();

        }

        // POST: Kindergarten/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Kindergarden kindergarden)
        {
           

            var putTask = httpClient.PutAsJsonAsync<Kindergarden>(baseAddress + "Kindergartens/update-kindergarten/" + id.ToString(), kindergarden);
            putTask.Wait();

            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }




        // GET: Kindergarten/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kindergarten/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
      
                //HTTP POST
                var putTask = httpClient.DeleteAsync(baseAddress+"Kindergartens/remove-kindergarten/" + id.ToString());
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
