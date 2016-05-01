using System.Web.Mvc;
using ScholarshipWebApplication.Models.Database;
using ScholarshipWebApplication.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace ScholarshipWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private StudentContext db = new StudentContext();

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BasicDoc()
        {
            ViewModeltoBasicDoc model = new ViewModeltoBasicDoc();
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BasicDoc(ViewModeltoBasicDoc tuple)
        {
            tuple.Student.address = tuple.Adres;
            if (ModelState.IsValid)
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(User.Identity.GetUserId());
                currentUser.student = tuple.Student;
                manager.UpdateAsync(currentUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tuple);
        }

    }
}