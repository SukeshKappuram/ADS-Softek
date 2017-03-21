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
    public class ShippingAddressesController : Controller
    {
        private EShopingv1Context db = new EShopingv1Context();

        // GET: ShippingAddresses
        public ActionResult Index()
        {
            var shippingAddresses = db.ShippingAddresses.Include(s => s.user);
            return View(shippingAddresses.ToList());
        }

        // GET: ShippingAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingAddress shippingAddress = db.ShippingAddresses.Find(id);
            if (shippingAddress == null)
            {
                return HttpNotFound();
            }
            return View(shippingAddress);
        }

        // GET: ShippingAddresses/Create
        public ActionResult Create(int? id)
        {
            User u = db.Users.Find(id);
            List<User> users = new List<Models.User>();
            users.Add(u);
            ViewBag.UserId = new SelectList(users, "Id", "firstName");
            return View();
        }

        // POST: ShippingAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Location,State,Pincode,PhoneNumber,UserId")] ShippingAddress shippingAddress)
        {
            if (ModelState.IsValid)
            {
                db.ShippingAddresses.Add(shippingAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "firstName", shippingAddress.UserId);
            return View(shippingAddress);
        }

        // GET: ShippingAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingAddress shippingAddress = db.ShippingAddresses.Find(id);
            if (shippingAddress == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstName", shippingAddress.UserId);
            return View(shippingAddress);
        }

        // POST: ShippingAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Location,State,Pincode,PhoneNumber,UserId")] ShippingAddress shippingAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shippingAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "firstName", shippingAddress.UserId);
            return View(shippingAddress);
        }

        // GET: ShippingAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShippingAddress shippingAddress = db.ShippingAddresses.Find(id);
            if (shippingAddress == null)
            {
                return HttpNotFound();
            }
            return View(shippingAddress);
        }

        // POST: ShippingAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShippingAddress shippingAddress = db.ShippingAddresses.Find(id);
            db.ShippingAddresses.Remove(shippingAddress);
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
