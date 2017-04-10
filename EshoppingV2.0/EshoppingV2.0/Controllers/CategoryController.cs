using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EshoppingBL;


namespace EshoppingV2._0.Controllers
{
    [Authorize(Roles="Admin")]
    public class CategoryController : Controller
    {
        CategoryBL categoryBl = new CategoryBL();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult selectCategory()
        {
            return Json(categoryBl.Categorys.ToList(), JsonRequestBehavior.AllowGet);
        }

        public string InsertCategory([Bind(Exclude = "Id")]Category Category)
        {
            string msg;
            if (ModelState.IsValid)
            {
                if (categoryBl.InsertCategory(Category) > 0)
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

        public string UpdateCategory(Category Category)
        {
            string msg;
            if (ModelState.IsValid)
            {
                if (categoryBl.UpdateCategory(Category) > 0)
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


        public string DeleteCategory(int Id)
        {
            string msg;

            if (categoryBl.DeleteCategory(Id) > 0)
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
