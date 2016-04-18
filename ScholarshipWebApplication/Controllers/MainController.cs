using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ScholarshipWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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

        //protected bool isDataSended<T>(DbSet<T> set)
        //{
        //    ApplicationUser user = getUser();
        //    bool isSended = false;

        //    if (user.student != null)
        //    {
        //        int id = user.student.StudentID;
        //        var props = from docs in set where docs.student.StudentID == id select docs;

        //        if (props.Any())
        //        {
        //            isSended = true;
        //        }
        //    }
        //    return isSended;
        //}
    }
}