using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class HomeController : Controller
    {
        //Client


        public ActionResult IndexClient()
        {
            return View("IndexClient");
        }
        //Admin
        public ActionResult Index()
        {
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