using ScholarshipWebApplication.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScholarshipWebApplication.Controllers
{
    public class ScholarshipController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Scholarship
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PresidentSch()
        {
            return View();
        }

        public ActionResult SocialSch()
        {
            return View();
        }

        public ActionResult DisabledSch()
        {
            return View();
        }

        [Authorize]
        public ActionResult PresidentSchDoc()
        {
            //Radzio
            return View();
        }

        [Authorize]
        public ActionResult SocialSchDoc()
        {
            //Radzio
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SocialSchDoc([Bind(Include = "kind,incomeYear,netIncome,lostIncome,gainedIncome,incomePerPersonPerMonth,alimonyCuts")] SocialScholarshipProps socialScholarshipProps)
        {
            if (ModelState.IsValid)
            {
                db.SocialProperties.Add(socialScholarshipProps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize]
        public ActionResult DisabledSchDoc()
        {
            //Radzio
            return View();
        }
    }
}