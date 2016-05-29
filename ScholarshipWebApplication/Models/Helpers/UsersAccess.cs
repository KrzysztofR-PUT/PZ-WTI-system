using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ScholarshipWebApplication.Models.Helpers
{
    public class UsersAccess
    {
        public static UserManager<ApplicationUser> getUserManager()
        {
            return new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }
    }
}