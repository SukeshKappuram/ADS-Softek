using JQgridExLb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQGridEx.Controllers
{
    public class HomeController : Controller
    {
        UserBL userBl = new UserBL();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult viewUsers()
        {
            return View();
        }

        public JsonResult selectUser() { 
            return Json(userBl.Users.ToList(),JsonRequestBehavior.AllowGet);
        }

        public string InsertUser([Bind(Exclude = "Id")]User user)
        {
            string msg;
            if (ModelState.IsValid)
            {
                if (userBl.InsertUser(user) > 0)
                {
                    msg = "Data Inserted Successfully";
                }
                else
                {
                    msg = "Error. Could Not Insert Data";
                }
            }
            else
            {
                msg = "Sorry! Validation Error";
            }

            return msg;
        }

        public string UpdateUser(User User)
        {
            string msg;
            if (ModelState.IsValid)
            {
                if (userBl.UpdateUser(User) > 0)
                {
                    msg = "Data Updated Successfully";
                }
                else
                {
                    msg = "Error. Could Not Update Data";
                }
            }
            else
            {
                msg = "Sorry! Validation Error";
            }

            return msg;
        }


        public string DeleteUser(int Id)
        {
            string msg;

            if (userBl.DeleteUser(Id) > 0)
            {
                msg = "Data Deleted Successfully";
            }
            else
            {
                msg = "Error. Could Not Delete Data";
            }

            return msg;
        }
    }
}