using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ScholarshipWebApplication.Models.Database;
using ScholarshipWebApplication.Models;

namespace ScholarshipWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private StudentContext db = new StudentContext();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BasicDoc()
        {
            ViewModeltoBasicDoc model = new ViewModeltoBasicDoc();
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BasicDoc(ViewModeltoBasicDoc tuple)
        {
            tuple.Student.address = tuple.Adres;
            if (ModelState.IsValid)
            {
                db.Student.Add(tuple.Student);
                db.Address.Add(tuple.Adres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tuple);
        }

    }
}