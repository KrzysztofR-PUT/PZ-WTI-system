using ScholarshipWebApplication.Models.Database;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;

namespace ScholarshipWebApplication.Controllers
{
    public class AdminController : Controller
    {
        private StudentContext db = new StudentContext();
        private const int pageSize = 6;
        
        public ActionResult Index()
        {
            return View();
        }
        
        private ActionResult Details<T>(DbSet<T> set, int? id) where T : StatefulDoc
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T ScholarshipProps = set.Find(id);
            if (ScholarshipProps == null)
            {
                return HttpNotFound();
            }
            return View(ScholarshipProps);
        }

        public ActionResult DetailsSocial(int? id)
        {
            return Details(db.SocialProperties, id);
        }

        public ActionResult DetailsPresident(int? id)
        {
            return Details(db.PresidentSchProp, id);
        }

        public ActionResult DetailsDisabled(int? id)
        {
            return Details(db.ForDisabledProperties, id);
        }

        public ActionResult Events()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Events(Dates dates)
        {
            if (ModelState.IsValid)
            {
                db.Dates.Add(dates);
                db.SaveChanges();
            }
            return View();
        }

        private ActionResult query<T>(DbSet<T> set, int? page) where T : StatefulDoc
        {
            int pageNumber = (page ?? 1);
            var query = from props in set where props.docState == DocState.sended select props;
            return View(query.OrderBy(s => s.DocID).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult PresidentSch(int? page)
        {
            return query(db.PresidentSchProp, page);
        }

        public ActionResult SocialSch(int? page)
        {
            return query(db.SocialProperties, page);
        }

        public ActionResult DisabledSch(int? page)
        {
            return query(db.ForDisabledProperties, page);
        }       

        private ActionResult changeStateView<T>(DbSet<T> set, int? id, string method) where T : StatefulDoc
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T ScholarshipProps = set.Find(id);
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
        public ActionResult ChangeDisabledState(int ?id, string method )
        {
            return changeStateView(db.ForDisabledProperties, id, method);
        }

        [HttpPost]
        public ActionResult ChangeSocialState(int? id, string method)
        {
            return changeStateView(db.SocialProperties, id, method);
        }

        [HttpPost]
        public ActionResult ChangePresidentState(int? id, string method)
        {
            return changeStateView(db.PresidentSchProp, id, method);
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