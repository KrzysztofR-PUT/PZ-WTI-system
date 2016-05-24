using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ScholarshipWebApplication.Models;
using System.Web.Mvc;

namespace ScholarshipWebApplication.Controllers
{
    public class MainController : Controller
    {
        protected ApplicationUser getUser()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            return manager.FindById(User.Identity.GetUserId());
        }        
    }
}