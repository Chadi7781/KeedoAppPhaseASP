using KeedoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class ChatBotController : Controller
    {
        // GET: ChatBot
        public ActionResult Index()
        {
            @ViewBag.resp = "";
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Index(string reportName, string Lange)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/SpringMVC/servlet/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response= await client.PostAsJsonAsync("chat/replayBasedOnWords/" + 1, reportName);

            if (Lange.Equals("Fr"))
            {
                response = await client.PostAsJsonAsync("chat/replayBasedOnWords/" + 1, reportName);
            }
            if (Lange.Equals("En"))
            {
                response = await client.PostAsJsonAsync("chat/replayBasedOnWords/" + 2, reportName);
            }
            System.Diagnostics.Debug.WriteLine("msgg:: " + reportName);
            ViewBag.msg = reportName;
            String re = response.Content.ReadAsStringAsync().Result.ToString();
            Chat chat = new Chat
            {
                respense = re
            };
            @ViewBag.resp = re;
            System.Diagnostics.Debug.WriteLine("msgg222:: " + re);
            return View();
        }
    }
}