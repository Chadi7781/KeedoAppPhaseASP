using KeedoApp.Models;
using Newtonsoft.Json;
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
        }

        // GET: User
        public ActionResult GestionUtilisateur()
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "/findall").Result;
            if (httpResponseMessage.IsSuccessStatusCode) {
                ViewBag.users = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.User>>().Result;
            }
            else {
                ViewBag.users = "erreur";
            }
            return View();
        }
        public ActionResult login(LoginObject.Login login) {
            baseAddress = "http://localhost:8080/SpringMVC/servlet/User/Access";
            if (!login.username.Equals("") && !login.password.Equals(""))
            {
                var APIResponse = httpClient.PostAsJsonAsync<LoginObject.Login>(baseAddress + "/login", login).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                var jsonreponse = APIResponse.Result.Content.ReadAsAsync<LoginObject.jwtResponse>().Result;
                Session["AccessToken"] = jsonreponse.AccessToken;
                Session["Role"] = jsonreponse.role;
                Session["User"] = jsonreponse.username;
            }
                return View();
        }

        public ActionResult create (User user)
        {
            try
            {
                if (ViewBag.roles == null) { 
                baseAddress = "http://localhost:8080/SpringMVC/servlet/Role";
                HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "/findall").Result;
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    ViewBag.roles = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.Role>>().Result;
                }
                }
                if (!(user.firstName.Equals("") && user.lastName.Equals("") && user.Login.Equals("") && user.Password.Equals(""))) 
                {
                    baseAddress = "http://localhost:8080/SpringMVC/servlet/User/Access";
                    var APIResponse = httpClient.PostAsJsonAsync<User>(baseAddress + "/signup", user).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                   
                    
                    var jsonreponse = APIResponse.Result.Content.ReadAsAsync<String>().Result;.
                    
                    
                    ViewBag.SuccessMessage = jsonreponse;
                }
            }

            catch
            {
                return View();
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpGet]
        public ActionResult userbyid(int id)
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "/userbyid/{"+ id + "}").Result;
            //IEnumerable<Models.User> users;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                ViewBag.users = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.User>>().Result;
            }
            else
            {
                ViewBag.users = "erreur";
            }
            return View();
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
