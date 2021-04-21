using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KeedoApp.Controllers
{
    public class ResponseController : Controller
    {
        // GET: Response
        public ActionResult Index()
        {
            return View();
        }

        // GET: Response/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Response/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Response/Create
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

        // GET: Response/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Response/Edit/5
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

        // GET: Response/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Response/Delete/5
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
