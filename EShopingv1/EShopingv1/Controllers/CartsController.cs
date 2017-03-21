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
    public class CartsController : Controller
    {
        private EShopingv1Context db = new EShopingv1Context();

        // GET: Carts
        public ActionResult Index()
        {
            var carts = db.Carts.Include(c => c.product).Include(c => c.user);
            return View(carts.ToList());
        }

        public ActionResult AddToCart(int? id) {
            Cart c = new Cart();
            c.product= db.Products.Find(id);
            c.productId = c.product.Id;
            c.user=(User)Session["user"];
            c.userId = c.user.Id;
            db.Carts.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // GET: Carts/Create
        public ActionResult Create()
        {
            ViewBag.productId = new SelectList(db.Products, "Id", "Name");
            ViewBag.userId = new SelectList(db.Users, "Id", "firstName");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,productId,userId,quantity")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.productId = new SelectList(db.Products, "Id", "Name", cart.productId);
            ViewBag.userId = new SelectList(db.Users, "Id", "firstName", cart.userId);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.productId = new SelectList(db.Products, "Id", "Name", cart.productId);
            ViewBag.userId = new SelectList(db.Users, "Id", "firstName", cart.userId);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,productId,userId,quantity")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.productId = new SelectList(db.Products, "Id", "Name", cart.productId);
            ViewBag.userId = new SelectList(db.Users, "Id", "firstName", cart.userId);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
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
