using ScholarshipWebApplication.Models.Database;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ScholarshipWebApplication.Controllers
{
    public class AdminController : Controller
    {
        private StudentContext db = new StudentContext();
        
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult DetailsSocial(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialScholarshipProps ScholarshipProps = db.SocialProperties.Find(id);
            if (ScholarshipProps == null)
            {
                return HttpNotFound();
            }
            return View(ScholarshipProps);
        }

        public ActionResult DetailsPresident(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PresidentSchProp ScholarshipProps = db.PresidentSchProp.Find(id);
            if (ScholarshipProps == null)
            {
                return HttpNotFound();
            }
            return View(ScholarshipProps);
        }

        public ActionResult DetailsDisabled(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForDisabledScholarshipProps ScholarshipProps = db.ForDisabledProperties.Find(id);
            if (ScholarshipProps == null)
            {
                return HttpNotFound();
            }
            return View(ScholarshipProps);
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

        [HttpPost]
        public ActionResult ChangeDisabledState(int ?id, string method )
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForDisabledScholarshipProps ScholarshipProps = db.ForDisabledProperties.Find(id);
            if (ScholarshipProps == null)
            {
                return HttpNotFound();
            }
            else
            {
                ScholarshipProps.docState = getDocState(method);
                db.SaveChanges();
            }
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult ChangeSocialState(int? id, string method)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SocialScholarshipProps ScholarshipProps = db.SocialProperties.Find(id);
            if (ScholarshipProps == null)
            {
                return HttpNotFound();
            }
            else
            {
                ScholarshipProps.docState = getDocState(method);
                db.SaveChanges();
            }
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult ChangePresidentState(int? id, string method)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PresidentSchProp ScholarshipProps = db.PresidentSchProp.Find(id);
            if (ScholarshipProps == null)
            {
                return HttpNotFound();
            }
            else
            {
                ScholarshipProps.docState = getDocState(method);
                db.SaveChanges();
            }
            return new EmptyResult();
        }

        private DocState getDocState( string method )
        {
            if (method == "accepted")
                return DocState.accepted;
            else if (method == "reject")
                return DocState.rejected;
            else return DocState.sended;
        }
    }
}