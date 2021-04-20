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
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/message/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Followers
            HttpResponseMessage httpResponseMessage = client.GetAsync("followers/3").Result;
            IEnumerable<User> followers;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                followers = httpResponseMessage.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
            else
            {
                followers = null;
            }

           // ViewBag.Followers = followers;
            return View(followers);
        }

        public ActionResult Index2(int id, String name)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/message/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Followers
            HttpResponseMessage httpResponseMessage = client.GetAsync("followers/3").Result;
            IEnumerable<User> followers;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                followers = httpResponseMessage.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
            else
            {
                followers = null;
            }
            ViewBag.Followers = followers;
            //Messages
            HttpResponseMessage httpResponseMessage2 = client.GetAsync("checkMsg/"+ id).Result;

            IEnumerable<Message> messages;
            if (httpResponseMessage2.IsSuccessStatusCode)
            {
                messages = httpResponseMessage2.Content.ReadAsAsync<IEnumerable<Message>>().Result;
            }
            else
            {
                messages = null;
            }
            ViewBag.IdR = id;
            ViewBag.name = name;
            //ViewBag.Messages = messages;
            return View(messages);
        }
        
        public ActionResult Send(int id)
        {
            ViewBag.IdR = id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Send(int id, Message message)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/message/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsJsonAsync("sendMessage/"+id, message);
            User user;
            HttpResponseMessage httpResponseMessage2 = client.GetAsync("receiver/" + id).Result;
           
                user = httpResponseMessage2.Content.ReadAsAsync<User>().Result;
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index2", new { id = id, name = user.FirstNameLastName });
            }
            return View(message);
        }
    }
}