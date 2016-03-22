using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScholarshipWebApplication.Controllers
{
    public class ScholarshipController : Controller
    {
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
        
        [Authorize]
        public ActionResult DisabledSchDoc()
        {
            //Radzio
            return View();
        }
    }
}