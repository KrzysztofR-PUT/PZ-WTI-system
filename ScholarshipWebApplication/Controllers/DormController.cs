using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ScholarshipWebApplication.Models.Database;
using ScholarshipWebApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ScholarshipWebApplication.Controllers
{
    public class DormController : MainController
    {
        private StudentContext db = new StudentContext();
        
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AccomodationDoc()
        {
            ApplicationUser user = getUser();
            ViewBag.isSended = false;

            if (user.student != null)
            {
                int id = user.student.StudentID;
                var props = from docs in db.DocumentProperties where docs.student.StudentID == id select docs;

                if (props.Any())
                {
                    ViewBag.isSended = true;
                }
            }
            else
            {
                ViewBag.Message = "Przed wypełnianiem dokumentów, należy podać podstawowe dane osobowe.";
                return RedirectToAction("BasicDoc", "Home");
            }
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccomodationDoc(DormDocumentProps dormDocumentProps)
        {
            if (ModelState.IsValid)
            {
                dormDocumentProps.docState = DocState.sended;
                dormDocumentProps.student = db.Student.Find(getUser().student.StudentID);
                db.DocumentProperties.Add(dormDocumentProps);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dormDocumentProps);
        }
    }
}
