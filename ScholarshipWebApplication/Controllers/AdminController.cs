using ScholarshipWebApplication.Models.Database;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ScholarshipWebApplication.Controllers
{
    public class AdminController : Controller
    {
        private StudentContext db = new StudentContext();
        
        public ActionResult Index()
        {
            return View();
        }
        
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
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SocialScholarshipProps socialScholarshipProps = db.SocialProperties.Find(id);
            db.SocialProperties.Remove(socialScholarshipProps);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult PresidentSch()
        {
            var query = from props in db.PresidentSchProp where props.docState == DocState.sended select props;
            return View(query);
        }

        public ActionResult SocialSch()
        {
            var query = from props in db.SocialProperties where props.docState == DocState.sended select props;
            return View(query);
        }

        public ActionResult DisabledSch()
        {
            var query = from props in db.ForDisabledProperties where props.docState == DocState.sended select props;
            return View(query);
        }
    }
}