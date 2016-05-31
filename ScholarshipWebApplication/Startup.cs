using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using ScholarshipWebApplication.Models;

[assembly: OwinStartupAttribute(typeof(ScholarshipWebApplication.Startup))]
namespace ScholarshipWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                        
            if (!roleManager.RoleExists("Admin"))
            {         
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
                
                var user = new ApplicationUser();
                user.UserName = "adrn.kaczmarek@gmail.com";
                user.Email = "adrn.kaczmarek@gmail.com";

                string userPWD = "Karczycho123";

                var chkUser = UserManager.Create(user, userPWD);
                
                if (chkUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Admin");
                }
            }
            if (!roleManager.RoleExists("Student"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);
            }
        }
    }
}
