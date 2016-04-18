using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ScholarshipWebApplication.Models;
using ScholarshipWebApplication.Models.Database;
using System.Web.Mvc;
using System.Linq;

namespace ScholarshipWebApplication.Controllers
{
    public class ScholarshipController : MainController
    {
        private StudentContext db = new StudentContext();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PresidentSch()
        {
            return View();
        }

        [Authorize]
        public ActionResult PresidentSchDoc()
        {
            return View();
        }

        public ActionResult DisabledSch()
        {
            return View();
        }

        [Authorize]
        public ActionResult DisabledSchDoc()
        {
            ApplicationUser user = getUser();
            ViewBag.isSended = false;

            if (user.student != null)
            {
                int id = user.student.StudentID;

                var props = from docs in db.ForDisabledProperties where docs.student.StudentID == id select docs;

                if (props.Any())
                {
                    ViewBag.isSended = true;
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DisabledSchDoc(ForDisabledScholarshipProps forDisabledProperties)
        {
            if (ModelState.IsValid)
            {
                forDisabledProperties.docState = DocState.sended;
                forDisabledProperties.student = db.Student.Find(getUser().student.StudentID);
                db.ForDisabledProperties.Add(forDisabledProperties);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult SocialSch()
        {
            return View();
        }

        [Authorize]
        public ActionResult SocialSchDoc()
        {
            ApplicationUser user = getUser();
            ViewBag.isSended = false;

            if (user.student != null)
            {
                int id = user.student.StudentID;                
                var props = from docs in db.SocialProperties where docs.student.StudentID == id select docs;

                if (props.Any())
                {
                    ViewBag.isSended = true;
                }
            }            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SocialSchDoc( SocialScholarshipProps socialScholarshipProps)
        {
            if (ModelState.IsValid)
            {
                socialScholarshipProps.docState = DocState.sended;
                socialScholarshipProps.student = db.Student.Find(getUser().student.StudentID);
                db.SocialProperties.Add(socialScholarshipProps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }      
    }
}