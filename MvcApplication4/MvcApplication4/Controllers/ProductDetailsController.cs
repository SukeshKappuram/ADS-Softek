using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Models;

namespace MvcApplication4.Controllers
{
    public class ProductDetailsController : Controller
    {
        private MvcApplication4Context db = new MvcApplication4Context();

        //
        // GET: /ProductDetails/

        public ActionResult Index()
        {
            return View(db.ProductDertails.ToList());
        }

        //
        // GET: /ProductDetails/Details/5

        public ActionResult Details(int id = 0)
        {
            ProductDertails productdertails = db.ProductDertails.Find(id);
            if (productdertails == null)
            {
                return HttpNotFound();
            }
            return View(productdertails);
        }

        //
        // GET: /ProductDetails/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ProductDetails/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductDertails productdertails)
        {
            if (ModelState.IsValid)
            {
                db.ProductDertails.Add(productdertails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productdertails);
        }

        //
        // GET: /ProductDetails/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ProductDertails productdertails = db.ProductDertails.Find(id);
            if (productdertails == null)
            {
                return HttpNotFound();
            }
            return View(productdertails);
        }

        //
        // POST: /ProductDetails/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductDertails productdertails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productdertails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productdertails);
        }

        //
        // GET: /ProductDetails/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ProductDertails productdertails = db.ProductDertails.Find(id);
            if (productdertails == null)
            {
                return HttpNotFound();
            }
            return View(productdertails);
        }

        //
        // POST: /ProductDetails/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductDertails productdertails = db.ProductDertails.Find(id);
            db.ProductDertails.Remove(productdertails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}