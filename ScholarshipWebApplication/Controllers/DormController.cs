using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ScholarshipWebApplication.Models.Database;
using ScholarshipWebApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;
using System.Web.Helpers;

namespace ScholarshipWebApplication.Controllers
{
    public class DormController : MainController
    {
        private StudentContext db = new StudentContext();
        private List<Rooms> ListR = new List<Rooms>();
        
        public ActionResult Index()
        {
            Dates model = new Dates();


            var query = from dates in db.Dates where dates.what == 0 select dates;

            model.ListDates = query.ToList();

           

            return View(model);
        }
        
        [Authorize]
        public ActionResult AccomodationDoc()
        {
            var query2 = from dates in db.Dates where dates.what == 0 select dates;

            List<Dates> ListDates = query2.ToList();
            DateTime dt2 = DateTime.Now;
            DateTime dt1 = ListDates.ElementAt(0).data;
            ViewBag.dateCheck = false;

            if (dt1.Date < dt2.Date)
            {
                
                ViewBag.dateCheck = true;

            }else
            {
                ViewBag.dateCheck = false;

               
            }

            //Create db context object here 
            ViewModelToDorm model = new ViewModelToDorm();
            //Get the value from database and then set it to ViewBag to pass it View
            IEnumerable<SelectListItem> items = db.Room.AsNoTracking().Where(c => c.isAvailable == 1).Select(c => new SelectListItem
            {
                
                Value = c.RoomID.ToString(),
                Text = c.RoomID.ToString(),
                Selected = c.RoomID.Equals(1)
                
            });
               ViewBag.RoomID = items;

            model.Rooms = new Rooms();
            model.DormDocProps = new DormDocumentProps();

            int w=Convert.ToInt32(items.ToList().ElementAt(0).Text);

            var query = from rooms in db.Room where rooms.RoomID == w select rooms;

            ListR= query.ToList(); 
            
            model.Rooms.RoomID = ListR.ElementAt(0).RoomID;
            model.Rooms.roomSpace = ListR.ElementAt(0).roomSpace;
            model.Rooms.currentLodgersNumber =ListR.ElementAt(0).currentLodgersNumber;
            model.Rooms.floorNumber = ListR.ElementAt(0).floorNumber;
            model.Rooms.isAvailable = ListR.ElementAt(0).isAvailable;


            ApplicationUser user = getUser();
            ViewBag.isSended = false;

            if (user.student != null)
            {
                int id = user.student.StudentID;
                var props = from docs in db.DocumentProperties where docs.student.StudentID == id select docs;

                if (props.Any())
                {
                    ViewBag.isSended = true;
                    ViewModelToDorm viewmodel = new ViewModelToDorm();
                    viewmodel.DormDocProps = props.First();
                    return View(viewmodel);
                }
            }
            else
            {
                ViewBag.Message = "Przed wypełnianiem dokumentów, należy podać podstawowe dane osobowe.";
                return RedirectToAction("BasicDoc", "Home");
            }
            return View(model);
        }
        
        [ActionName("CallChangefun")]
        public ActionResult CallChangefun(int? value , ViewModelToDorm model)
        {
            int i =Convert.ToInt32(value);

            model.Rooms = new Rooms();
            model.DormDocProps = new DormDocumentProps();

            IEnumerable<SelectListItem> x = db.Room.Where(c => c.isAvailable == 1).Select(c => new SelectListItem
            {
                Value = c.RoomID.ToString(),
                Text = c.RoomID.ToString(),
                Selected = c.RoomID.Equals(i)
            });

            ViewBag.RoomID = x;

            var query = from rooms in db.Room where rooms.RoomID == i select rooms;


            ListR = query.ToList();
            model.Rooms.RoomID = ListR.ElementAt(0).RoomID;
            model.Rooms.roomSpace = ListR.ElementAt(0).roomSpace;
            model.Rooms.currentLodgersNumber = ListR.ElementAt(0).currentLodgersNumber;
            model.Rooms.floorNumber = ListR.ElementAt(0).floorNumber;
            model.Rooms.isAvailable = ListR.ElementAt(0).isAvailable;

            return View("AccomodationDoc",model);
        }

        [HttpPost]
        [ActionName("CallChangefun")]
        public ActionResult CallChangefun( ViewModelToDorm model, string part1, string part2, string part3, string part4)
        {
            if (ModelState.IsValid)
            {
                model.DormDocProps.bankAccountNmb = part1 + part2 + part3 + part4;

                model.Rooms.currentLodgersNumber += 1;
                if (model.Rooms.roomSpace > model.Rooms.currentLodgersNumber)
                {
                    db.Entry(model.Rooms).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    model.Rooms.isAvailable = 0;
                    db.Entry(model.Rooms).State = EntityState.Modified;
                    db.SaveChanges();
                }

                model.DormDocProps.docState = DocState.sended;
                model.DormDocProps.Room = model.Rooms;
                model.DormDocProps.student = db.Student.Find(getUser().student.StudentID);
                db.DocumentProperties.Add(model.DormDocProps);
                db.SaveChanges();


                return RedirectToAction("Index");
            }

            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccomodationDoc(string RoomID, ViewModelToDorm model, string part1, string part2, string part3, string part4)
        {

            
            if (ModelState.IsValid)
            {
                model.DormDocProps.bankAccountNmb = part1 + part2 + part3 + part4;

                model.Rooms.currentLodgersNumber += 1;
                if (model.Rooms.roomSpace> model.Rooms.currentLodgersNumber)
                {
                    db.Entry(model.Rooms).State = EntityState.Modified;                
                    db.SaveChanges();
                }
                else
                {
                    model.Rooms.isAvailable= 0;
                    db.Entry(model.Rooms).State = EntityState.Modified;
                    db.SaveChanges();
                }
               
                model.DormDocProps.docState = DocState.sended;
                model.DormDocProps.Room = model.Rooms;
                model.DormDocProps.student = db.Student.Find(getUser().student.StudentID);
                db.DocumentProperties.Add(model.DormDocProps);
                db.SaveChanges();

                         
                return RedirectToAction("Index");
            }

            return View(model);


        }
    }
}
