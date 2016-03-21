using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScholarshipWebApplication.Startup))]
namespace ScholarshipWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
