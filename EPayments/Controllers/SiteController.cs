using EPayments.Models;
using EPayments.Properties;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace EPayments.Controllers
{
    public class SiteController : Controller
    {
        IRepository repo;

        public SiteController(IRepository r)
        {
            repo = r;
        }

        public SiteController()
        {
            repo = new SiteRepository();
        }

        public ActionResult Index()
        {
            ViewBag.Period = Settings.Default.PeriodMonitoring * 60000; // TODO: перевод в минуты
            ViewBag.PeriodMin = Settings.Default.PeriodMonitoring;

            return View("Index");
        }

        public PartialViewResult GetSites()
        {
            return PartialView("GetSites", repo.Sites);
        }

        // GET: Site/Create
         public ActionResult Create()
        {
            if(Request.IsAuthenticated)
                return View("Create");
            else
                return RedirectToAction("Index");
        }

        // POST: Site/Create
        [HttpPost]
        public ActionResult Create(Site site)
        {
            if (ModelState.IsValid)
            {
                repo.Create(site);
                repo.Save();

                return RedirectToAction("Index");
            }
            else
            {
               return View("Create", site);
            }
        }

        // GET: Site/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (Request.IsAuthenticated)
                return View("Edit", repo.Find(id));
            else
                return RedirectToAction("Index");
        }

        // POST: Site/Edit/5
        [HttpPost]
        public ActionResult Edit(Site site)
        {
            if (ModelState.IsValid)
            {
                repo.Update(site);
                repo.Save();

                return RedirectToAction("Index");
            }
            return View("Edit", site);
        }

        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
            base.Dispose(disposing);
        }
    }
}
