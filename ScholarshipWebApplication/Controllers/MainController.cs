using Microsoft.AspNet.Identity;
using ScholarshipWebApplication.Models;
using ScholarshipWebApplication.Models.Helpers;
using System.Web.Mvc;

namespace ScholarshipWebApplication.Controllers
{
    public class MainController : Controller
    {
        protected ApplicationUser getUser()
        {
            return UsersAccess.getUserManager().FindById(User.Identity.GetUserId());
        }        
    }
}