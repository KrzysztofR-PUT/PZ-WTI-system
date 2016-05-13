using ScholarshipWebApplication.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ScholarshipWebApplication.Controllers
{
    public class AdminController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: SocialScholarshipProps
        public ActionResult Index()
        {
            return View(db.SocialProperties.ToList());
        }

        // GET: SocialScholarshipProps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialScholarshipProps socialScholarshipProps = db.SocialProperties.Find(id);
            if (socialScholarshipProps == null)
            {
                return HttpNotFound();
            }
            return View(socialScholarshipProps);
        }

        // GET: SocialScholarshipProps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocialScholarshipProps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocID,kind,incomeYear,netIncome,lostIncome,gainedIncome,incomePerPersonPerMonth,alimonyCuts,bankAccountNmb,docState")] SocialScholarshipProps socialScholarshipProps)
        {
            if (ModelState.IsValid)
            {
                db.SocialProperties.Add(socialScholarshipProps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socialScholarshipProps);
        }

        // GET: SocialScholarshipProps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialScholarshipProps socialScholarshipProps = db.SocialProperties.Find(id);
            if (socialScholarshipProps == null)
            {
                return HttpNotFound();
            }
            return View(socialScholarshipProps);
        }

        // POST: SocialScholarshipProps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocID,kind,incomeYear,netIncome,lostIncome,gainedIncome,incomePerPersonPerMonth,alimonyCuts,bankAccountNmb,docState")] SocialScholarshipProps socialScholarshipProps)
        {
            if (ModelState.IsValid)
            {
                db.Entry(socialScholarshipProps).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socialScholarshipProps);
        }

        // GET: SocialScholarshipProps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialScholarshipProps socialScholarshipProps = db.SocialProperties.Find(id);
            if (socialScholarshipProps == null)
            {
                return HttpNotFound();
            }
            return View(socialScholarshipProps);
        }

        // POST: SocialScholarshipProps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialScholarshipProps socialScholarshipProps = db.SocialProperties.Find(id);
            db.SocialProperties.Remove(socialScholarshipProps);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}