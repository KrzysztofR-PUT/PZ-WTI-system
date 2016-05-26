using System.Web.Mvc;
using System.Linq;
using ScholarshipWebApplication.Models.Database;
using ScholarshipWebApplication.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Collections.ObjectModel;



namespace ScholarshipWebApplication.Controllers
{
    public class HomeController : MainController
    {
        private StudentContext db = new StudentContext();
       

        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        public ActionResult BasicDoc()
        {
           

            ApplicationUser user = getUser();
            ViewBag.Edit = false;

            if (user.student != null)
            {
                int id = user.student.StudentID;
                var props = from docs in db.Student where docs.StudentID == id select docs;
                ViewModeltoBasicDoc viewmodel = new ViewModeltoBasicDoc();

                if (props.Any())
                {                
                    viewmodel.Student = props.First();
                 
                }

                var props1 = from docs in db.Address where docs.AddressID == viewmodel.Student.address.AddressID select docs;

                if (props1.Any())
                {
                    viewmodel.Adres = props1.First();
                   
                }

                viewmodel.Studies = viewmodel.Student.studies;
               
              
               
                ViewBag.Edit = true;
                return View(viewmodel);

            } else
            {
                ViewModeltoBasicDoc model = new ViewModeltoBasicDoc();
                return View(model);
            }
      
        }

        [Authorize]
        public ActionResult News()
        {
            var newsList = db.News.ToList();
                
            return View(newsList);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BasicDoc(ViewModeltoBasicDoc tuple)
        {
            ApplicationUser user = getUser();

           
            if (user.student != null)
            {

                int id = user.student.StudentID;

                var Student = db.Student.Find(id);
                var Adres = db.Address.Find(user.student.address.AddressID);

                if (tuple.Course != null)
                {
                    if (tuple.Studies == null)
                        tuple.Studies = new List<Studies>();
                    tuple.Adres = Adres;
                    tuple.Student = Student;
                    tuple.Studies.Add(tuple.Course);
                    ViewBag.Edit = true;
                
                    return View(tuple);

                }
                else {

                    if (Adres != null)
                    {
                        Adres.FlatNumber = tuple.Adres.FlatNumber;
                        Adres.Place = tuple.Adres.Place;
                        Adres.PostCode = tuple.Adres.PostCode;
                        Adres.Street = tuple.Adres.Street;
                        Adres.Voivodeship = tuple.Adres.Voivodeship;

                    }

                    if (Student != null)
                    {
                        Student.Email = tuple.Student.Email;
                        Student.FirstName = tuple.Student.FirstName;
                        Student.LastName = tuple.Student.LastName;
                        Student.PhoneNumber = tuple.Student.PhoneNumber;
                        Student.RegistryNumber = tuple.Student.RegistryNumber;
                
                    }
                }
                var props = from docs in db.Student where docs.StudentID == id select docs;
                ViewModeltoBasicDoc viewmodel = new ViewModeltoBasicDoc();
                if (props.Any())
                {
                    viewmodel.Student = props.First();
               
                }



                if (ModelState.IsValid)
                {                    
                      if (tuple.Studies.Count > viewmodel.Student.studies.Count)
                      { int i = 0;
                          while (viewmodel.Student.studies.Count > i)
                          {
                              tuple.Studies.RemoveAt(0);
                              i++;
                          }
                         Student.studies = tuple.Studies;

                      }

                    db.SaveChanges();

                   db.Database.ExecuteSqlCommand(
       "update Studies set Student_StudentID ="+id.ToString()+" where Student_StudentID is NULL");

                    return RedirectToAction("Index");
                }

                return View(tuple);

            }
            else {
                
                if (tuple.Course == null)
                {
                    tuple.Student.address = tuple.Adres;
                    tuple.Student.studies = tuple.Studies;
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
                else
                {
                    if (tuple.Studies == null)
                        tuple.Studies = new List<Studies>();
                    tuple.Studies.Add(tuple.Course);
                    return View(tuple);
                }
            }
        }}

    }
