using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class ParticipationController : Controller
    {
        // GET: Participation
        public ActionResult Index()
        {
            return View();
        }

        // GET: Participation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Participation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Participation/Create
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

        // GET: Participation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Participation/Edit/5
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

        // GET: Participation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Participation/Delete/5
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
