using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ScholarshipWebApplication.Models.Database;

namespace ScholarshipWebApplication.Controllers
{
    public class DormController : Controller
    {
        private StudentContext db = new StudentContext();

        // GET: Dorm
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dorm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DormDocumentProps dormDocumentProps = db.DocumentProperties.Find(id);
            if (dormDocumentProps == null)
            {
                return HttpNotFound();
            }
            return View(dormDocumentProps);
        }

        // GET: Dorm/Create
        public ActionResult AccomodationDoc()
        {
            return View();
        }

        // POST: Dorm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccomodationDoc([Bind(Include = "DistanceFromHome,TransportDifficulties,"+
            "FamilyCount,IncomePerPerson,IsDisabled,isFullFamily,CurrentAcademicYear")] DormDocumentProps dormDocumentProps)
        {
            if (ModelState.IsValid)
            {
                db.DocumentProperties.Add(dormDocumentProps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dormDocumentProps);
        }

        // GET: Dorm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DormDocumentProps dormDocumentProps = db.DocumentProperties.Find(id);
            if (dormDocumentProps == null)
            {
                return HttpNotFound();
            }
            return View(dormDocumentProps);
        }

        // POST: Dorm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DocID,DistanceFromHome,TransportDifficulties,FamilyCount,IncomePerPerson,IsDisabled,isFullFamily,CurrentAcademicYear")] DormDocumentProps dormDocumentProps)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dormDocumentProps).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dormDocumentProps);
        }

        // GET: Dorm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DormDocumentProps dormDocumentProps = db.DocumentProperties.Find(id);
            if (dormDocumentProps == null)
            {
                return HttpNotFound();
            }
            return View(dormDocumentProps);
        }

        // POST: Dorm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DormDocumentProps dormDocumentProps = db.DocumentProperties.Find(id);
            db.DocumentProperties.Remove(dormDocumentProps);
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
