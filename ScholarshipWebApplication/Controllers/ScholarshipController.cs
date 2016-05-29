using ScholarshipWebApplication.Models;
using ScholarshipWebApplication.Models.Database;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System;

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
            Dates model = new Dates();
            var query = from dates in db.Dates where dates.what == Document.rektorski select dates;

            model.ListDates = query.ToList();
            return View(model);
        }

       [Authorize]
        public ActionResult PresidentSchDoc()
        {

            var query2 = from dates in db.Dates where dates.what == Document.rektorski where dates.importantdate == true select dates;

            List<Dates> ListDates = query2.ToList();
            ViewBag.dateCheck = true;
            if (ListDates.Count > 0)
            {
                DateTime dt3 = DateTime.Now;
                DateTime dt1 = Convert.ToDateTime(ListDates.ElementAt(0).startdate);
                DateTime dt2 = Convert.ToDateTime(ListDates.ElementAt(0).enddate);
                ViewBag.dateCheck = false;

                if (dt1.Date <= dt3.Date && dt3.Date <= dt2.Date)
                {
                    ViewBag.dateCheck = false;
                }
            }

            PresidentSchProp pr = new PresidentSchProp();

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
            return View(pr);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PresidentSchDoc(PresidentSchProp pr, string part1, string part2, string part3,string part4)
        {           
            if (ModelState.IsValid)
            {
            string x = part1 + part2 + part3 + part4;

            pr.bankAccountNmb = x;
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
            Dates model = new Dates();
            var query = from dates in db.Dates where dates.what == Document.niepelnosprawny select dates;

            model.ListDates = query.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult DisabledSchDoc()
        {

            var query2 = from dates in db.Dates where dates.what == Document.niepelnosprawny where dates.importantdate == true select dates;

            List<Dates> ListDates = query2.ToList();
            ViewBag.dateCheck = true;
            if (ListDates.Count > 0)
            {
                DateTime dt3 = DateTime.Now;
                DateTime dt1 = Convert.ToDateTime(ListDates.ElementAt(0).startdate);
                DateTime dt2 = Convert.ToDateTime(ListDates.ElementAt(0).enddate);
                ViewBag.dateCheck = false;

                if (dt1.Date <= dt3.Date && dt3.Date <= dt2.Date)
                {
                    ViewBag.dateCheck = false;
                }
            }
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
        public ActionResult DisabledSchDoc(ForDisabledScholarshipProps forDisabledProperties, string part1, string part2, string part3, string part4)
        {
            if (ModelState.IsValid)
            {
                forDisabledProperties.bankAccountNmb = part1 + part2 + part3 + part4;

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
            Dates model = new Dates();
            var query = from dates in db.Dates where dates.what == Document.socjalny select dates;

            model.ListDates = query.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult SocialSchDoc()
        {

            var query2 = from dates in db.Dates where dates.what == Document.socjalny where dates.importantdate == true select dates;

            List<Dates> ListDates = query2.ToList();
            ViewBag.dateCheck = true;
            if (ListDates.Count > 0)
            {
                DateTime dt3 = DateTime.Now;
                DateTime dt1 = Convert.ToDateTime(ListDates.ElementAt(0).startdate);
                DateTime dt2 = Convert.ToDateTime(ListDates.ElementAt(0).enddate);
                ViewBag.dateCheck = false;

                if (dt1.Date <= dt3.Date && dt3.Date <= dt2.Date)
                {
                    ViewBag.dateCheck = false;
                }
            }

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
        public ActionResult SocialSchDoc(SocialMembersViewModel socialScholarshipProps, string part1, string part2, string part3, string part4)
        {

            if (socialScholarshipProps.income == null)
            {
                if (ModelState.IsValid)
                {
                    socialScholarshipProps.props.bankAccountNmb = part1 + part2 + part3 + part4;
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