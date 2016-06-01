using ScholarshipWebApplication.Models.Database;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using System.Data.Entity;
using ScholarshipWebApplication.Controllers.Hubs;

namespace ScholarshipWebApplication.Controllers
{
    public class AdminController : Controller
    {
        private StudentContext db = new StudentContext();
        private const int pageSize = 6;

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsSocial(int? id)
        {
            return Details(db.SocialProperties, id);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsPresident(int? id)
        {
            return Details(db.PresidentSchProp, id);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DetailsDisabled(int? id)
        {
            return Details(db.ForDisabledProperties, id);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Events()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Events(Dates dates)
        {
            if (ModelState.IsValid)
            {
                db.Dates.Add(dates);
                db.SaveChanges();
                Broadcast.Instance.DisplayNotification("Nowe wydarzenie: " + dates.name);
            }
            return View();
        }

        private ActionResult query<T>(DbSet<T> set, int? page) where T : StatefulDoc
        {
            int pageNumber = (page ?? 1);
            var query = from props in set where props.docState == DocState.sended select props;
            return View(query.OrderBy(s => s.DocID).ToPagedList(pageNumber, pageSize));
        }
        
        [Authorize(Roles = "Admin")]
        public ActionResult PresidentSch(int? page)
        {
            return query(db.PresidentSchProp, page);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult SocialSch(int? page)
        {
            return query(db.SocialProperties, page);
        }

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult ChangeDisabledState(int? id, string method )
        {
            return changeStateView(db.ForDisabledProperties, id, method);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult ChangeSocialState(int? id, string method)
        {
            return changeStateView(db.SocialProperties, id, method);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,")]
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