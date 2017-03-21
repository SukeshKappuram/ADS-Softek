using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EShopingv1.Models;

namespace EShopingv1.Controllers
{
    public class ProductDetailsController : Controller
    {
        private EShopingv1Context db = new EShopingv1Context();

        // GET: ProductDetails
        public ActionResult Index(int? id)
        {
            var productDetails = db.ProductDetails.Include(p => p.product).Include(p => p.seller);
            if (id == null)
            {
                return View(productDetails.ToList());
            }
            else {
                return View(productDetails.Where(p=>p.ProductId==id).ToList());
            }
        }

        // GET: ProductDetails/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetails productDetails = db.ProductDetails.Find(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            return View(productDetails);
        }

        // GET: ProductDetails/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            ViewBag.sellerId = new SelectList(db.Users, "Id", "firstName");
            return View();
        }

        // POST: ProductDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SerialNumber,ProductId,ExpieryDate,ManufactureDate,Size,Color,sellerId")] ProductDetails productDetails)
        {
            if (ModelState.IsValid)
            {
                db.ProductDetails.Add(productDetails);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productDetails.ProductId);
            ViewBag.sellerId = new SelectList(db.Users, "Id", "firstName", productDetails.sellerId);
            return View(productDetails);
        }

        // GET: ProductDetails/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetails productDetails = db.ProductDetails.Find(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productDetails.ProductId);
            ViewBag.sellerId = new SelectList(db.Users, "Id", "firstName", productDetails.sellerId);
            return View(productDetails);
        }

        // POST: ProductDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SerialNumber,ProductId,ExpieryDate,ManufactureDate,Size,Color,sellerId")] ProductDetails productDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productDetails).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", productDetails.ProductId);
            ViewBag.sellerId = new SelectList(db.Users, "Id", "firstName", productDetails.sellerId);
            return View(productDetails);
        }

        // GET: ProductDetails/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductDetails productDetails = db.ProductDetails.Find(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            return View(productDetails);
        }

        // POST: ProductDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProductDetails productDetails = db.ProductDetails.Find(id);
            db.ProductDetails.Remove(productDetails);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
