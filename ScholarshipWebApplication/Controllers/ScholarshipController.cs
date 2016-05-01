using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ScholarshipWebApplication.Models;
using ScholarshipWebApplication.Models.Database;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;

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
            ApplicationUser user = getUser();
            ViewBag.isSended = false;

            if (user.student != null)
            {
                int id = user.student.StudentID;

                var props = from docs in db.PresidentSchProp where docs.student.StudentID == id select docs;

                if (props.Any())
                {
                    ViewBag.isSended = true;
                    return View(props.First());
                }
            }
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PresidentSchDoc(PresidentSchProp pr)
        {
            
            if (ModelState.IsValid)
            {
                pr.docState = DocState.sended;
                pr.student = db.Student.Find(getUser().student.StudentID);
                db.PresidentSchProp.Add(pr);
                db.ForPresidentSchProp.Add(pr.table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           

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
                    return View(props.First());
                }
            }
            else
            {
                return RedirectToAction("BasicDoc", "Home");
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
                    SocialMembersViewModel model = new SocialMembersViewModel();
                    model.props = props.First();
                    return View(model);
                }
            }
            else
            {
                return RedirectToAction("BasicDoc", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SocialSchDoc(SocialMembersViewModel socialScholarshipProps)
        {
            if (socialScholarshipProps.income == null)
            {
                if (ModelState.IsValid)
                {
                    socialScholarshipProps.props.familyMembersIncome = socialScholarshipProps.incomes;
                    socialScholarshipProps.props.docState = DocState.sended;
                    socialScholarshipProps.props.student = db.Student.Find(getUser().student.StudentID);
                    db.SocialProperties.Add(socialScholarshipProps.props);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            else
            {
                if (socialScholarshipProps.incomes == null)
                    socialScholarshipProps.incomes = new List<FamilyMembersIncome>();
                socialScholarshipProps.incomes.Add(socialScholarshipProps.income);
                return View(socialScholarshipProps);
            }
        }
    }
}