using KeedoApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;


namespace KeedoApp.Controllers
{
    public class RoleController : Controller
    {
        HttpClient httpClient;
        string baseAddress;

        public RoleController()
        {
            baseAddress = "http://localhost:8080/SpringMVC/servlet/Role/";

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var _AccessToken = 

        }

        // GET: User
        public ActionResult GestionRole()
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));

            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "findall").Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.roles = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.Role>>().Result;
            }
            else
            {
                ViewBag.roles = "erreur";
            }
            return View();
        }
        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult CreateRole(Role role)
        {
            var postTask = httpClient.PostAsJsonAsync<Role>(baseAddress + "createRole", role);
            postTask.Wait();

            var result = postTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionRole");
            }
            return View();
        }
        // GET: Post/Create
        public ActionResult CreateRole()
        {
            return View();
        }
        // GET: Role/Edit/5
        // GET: Post/Edit/5
        public ActionResult EditRole(int id)
        {
            return View();
        }



        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult EditRole(int id, Role role)
        {
            //HTTP POST
            var putTask = httpClient.PutAsJsonAsync<Role>(baseAddress + "updateRolee/" + id.ToString(), role);
            putTask.Wait();

            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionRole");
            }
            return View();

        }

        public ActionResult DeleteRole(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteRole(int id, FormCollection collection)
        {
            //HTTP POST
            var putTask = httpClient.DeleteAsync(baseAddress + "deleteRoleById/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionRole");
            }
            System.Diagnostics.Debug.WriteLine("entered here" + result);
            return View();
        }
    }
}
