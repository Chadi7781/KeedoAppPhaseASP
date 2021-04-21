using KeedoApp.LoginObject;
using KeedoApp.Models;
using Newtonsoft.Json;
using reCAPTCHA.MVC;
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
        public ActionResult GestionUtilisateur(string searchString)
        {
            
            HttpResponseMessage httpResponseMessage;
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            if (String.IsNullOrEmpty(searchString))
            {
                System.Diagnostics.Debug.WriteLine("entered Index");

                httpResponseMessage = httpClient.GetAsync(baseAddress + "/findall").Result;


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
            else
            {
                httpResponseMessage = httpClient.GetAsync(baseAddress + "/findUserSearch/?pattern=" + searchString).Result;
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
        }

        //httpResponseMessage = httpClient.GetAsync(baseAddress + "/findall").Result;
        //    if (httpResponseMessage.IsSuccessStatusCode) {
        //    ViewBag.users = httpResponseMessage.Content.ReadAsAsync<IEnumerable<Models.User>>().Result;
        //  }
        // else {
        //   ViewBag.users = "erreur";
        //  }
        // return View();
        // }



        [CaptchaValidator]
        public ActionResult login(LoginObject.Login login, bool captchaValid) {
            baseAddress = "http://localhost:8080/SpringMVC/servlet/User/Access";
            if (ModelState.IsValid && !login.username.Equals("") && !login.password.Equals(""))
            {
                var APIResponse = httpClient.PostAsJsonAsync<LoginObject.Login>(baseAddress + "/login", login).ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());

                var jsonreponse = APIResponse.Result.Content.ReadAsAsync<LoginObject.jwtResponse>().Result;
                String resultat = jsonreponse.AccessToken;
                if (jsonreponse.Roles.Length > 0)
                {
                    Session["AccessToken"] = jsonreponse.AccessToken;
                    Session["Role"] = jsonreponse.role;
                    Session["User"] = jsonreponse.username;
                    return RedirectToAction("GestionUtilisateur");
                }
                ViewBag.resultat = resultat;
                
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
                   
                    
                    var jsonreponse = APIResponse.Result.Content.ReadAsAsync<String>().Result;
                    
                    
                    ViewBag.SuccessMessage = jsonreponse;
                }
            }

            catch
            {
                return View();
            }
            return View();
        }


        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }



        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            //HTTP POST
            var putTask = httpClient.PutAsJsonAsync<User>(baseAddress + "/updateUserr/" + id.ToString(), user);
            putTask.Wait();

            var result = putTask.Result;

            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionUtilisateur");
            }
            return View();

        }


        // POST: User/Edit/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "/userbyid/" + id.ToString()).Result;
            User user;
            if (httpResponseMessage.IsSuccessStatusCode)
            {

                user = httpResponseMessage.Content.ReadAsAsync<User>().Result;
            }
            else
            {
                user = null;
            }

            return View(user);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //HTTP POST
            var putTask = httpClient.DeleteAsync(baseAddress + "/deleteUserById/" + id.ToString());
            putTask.Wait();

            var result = putTask.Result;
            if (result.IsSuccessStatusCode)
            {

                return RedirectToAction("GestionUtilisateur");
            }
            System.Diagnostics.Debug.WriteLine("entered here" + result);
            return View();
        }

        public ActionResult Forgotpassword(String username)
        {
            if (username != null)
            {
                baseAddress = "http://localhost:8080/SpringMVC/servlet/User/Access";
                var APIResponse = httpClient.PostAsJsonAsync(baseAddress + "/forgot/" + username, "").ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("Reset");
            }
            return View();

        }

        public ActionResult Reset(LoginObject.Login reset)
        {
            if (!reset.username.Equals("") && !reset.password.Equals(""))
            {
                baseAddress = "http://localhost:8080/SpringMVC/servlet/User/Access";
                var APIResponse = httpClient.PostAsJsonAsync(baseAddress + "/reset/" + reset.username + "/" + reset.password, "").ContinueWith(postTask => postTask.Result.EnsureSuccessStatusCode());
                return RedirectToAction("login");
            }
            return View();
        }

        public ActionResult ActiverUser(int id)
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            var APIResponse = httpClient.PutAsJsonAsync(baseAddress + "/activateUser/" + id,"");
            APIResponse.Wait();

            var result = APIResponse.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("GestionUtilisateur");
            }
            return View();
        }

        public ActionResult DesactiverUser(int id)
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            var APIResponse = httpClient.PutAsJsonAsync(baseAddress + "/desactivateUser/" + id.ToString(), id.ToString());
            APIResponse.Wait();

            var result = APIResponse.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("GestionUtilisateur");
            }
            return View();
        }

       public ActionResult AfficherActivate()
        {
            var _AccessToken = Session["AccessToken"];
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer " + _AccessToken));
            HttpResponseMessage httpResponseMessage = httpClient.GetAsync(baseAddress + "findActivatedUser/").Result;
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
        // GET: Role
        public ActionResult Index()
        {
            return View();
        } 



    }
}
