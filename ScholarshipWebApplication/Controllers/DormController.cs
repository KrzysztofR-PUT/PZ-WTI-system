using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScholarshipWebApplication.Controllers
{
    public class DormController : Controller
    {
        // GET: Dorm
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult BookDorm()
        {
            //tutaj bedzie to co Radzio zrobi w tym widoku
            return View();
        }
    }
}