using EshoppingV2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EshoppingV2._0.Controllers
{
    [Authorize(Roles = "Seller")]
    public class ProductDetailController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ProductDetail
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult selectCategory()
        {
            var qry = from p in db.Products
                      orderby p.Name descending
                      select new { p.Id, p.Name};
            return Json(qry.ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}