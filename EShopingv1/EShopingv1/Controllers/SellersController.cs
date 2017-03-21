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
    public class SellersController : Controller
    {
        private EShopingv1Context db = new EShopingv1Context();

        // GET: Sellers
        public ActionResult Index()
        {
            return View(db.Users.OfType<Seller>().ToList());
        }

        // GET: Sellers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            Seller seller = (Seller)user;
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // GET: Sellers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,firstName,middleName,lastName,mailId,phoneNumber,OutletName")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(seller);
                db.SaveChanges();
                Role r = new Role();
                r.roleName="Seller";
                r.user = seller;
                r.userId = seller.Id;
                db.Rolls.Add(r);
                db.SaveChanges();
                return RedirectToAction("Create", "ShippingAddresses", new {id=seller.Id});
            }

            return View(seller);
        }

        // GET: Sellers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            Seller seller = (Seller)user;
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // POST: Sellers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,firstName,middleName,lastName,mailId,phoneNumber,OutletName")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seller);
        }

        // GET: Sellers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            Seller seller = (Seller)user;
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(seller);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            Seller seller = (Seller)user;
            db.Users.Remove(seller);
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
