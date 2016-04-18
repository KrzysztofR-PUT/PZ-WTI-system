using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ScholarshipWebApplication.Models;
using ScholarshipWebApplication.Models.Database;
using System.Web.Mvc;
using System.Linq;

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
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            int id = manager.FindById(User.Identity.GetUserId()).student.StudentID;

            ViewBag.isSended = false;
            var props = from docs in db.SocialProperties where docs.student.StudentID == id select docs;

            if (props != null)
            {
                ViewBag.isSended = true;
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
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                ApplicationUser user = manager.FindById(User.Identity.GetUserId());
                db.Student.Find(user.student.StudentID);
                socialScholarshipProps.student = db.Student.Find(user.student.StudentID);

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