using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EshoppingV2._0.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EshoppingV2._0.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cart
        public ActionResult Index()
        {
            foreach(CartItem c in db.CartItems.ToList()){
                ProductDetails p = db.ProductDetails.FirstOrDefault(pd=>pd.SerialNumber==c.productId) ;
                p.product = db.Products.FirstOrDefault(t => t.Id == p.ProductId);
                c.product = p;
            }
            return View(db.CartItems.ToList());
        }

        public ActionResult Add(string Id) {
            Guid productId = Guid.Parse(Id);
            var userId = User.Identity.GetUserId();
            Guid uId=Guid.Parse(userId);
            Cart c = db.Carts.FirstOrDefault(d => d.userId == uId );
            CartItem cartItem = new CartItem();
            cartItem.cartId = c.Id;
            cartItem.cart = c;
            cartItem.productId = productId;
            cartItem.product = db.ProductDetails.FirstOrDefault(pd => pd.SerialNumber == productId);
            cartItem.quantity = 1;
            db.CartItems.Add(cartItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Buy(string Id)
        {
            Guid productId = Guid.Parse(Id);
            var userId = User.Identity.GetUserId();
            Guid uId = Guid.Parse(userId);
            Cart c = db.Carts.FirstOrDefault(d => d.userId == uId);
            CartItem cartItem = new CartItem();
            cartItem.cartId = c.Id;
            cartItem.cart = c;
            cartItem.productId = productId;
            cartItem.product = db.ProductDetails.FirstOrDefault(pd => pd.SerialNumber == productId);
            cartItem.quantity = 1;
            db.CartItems.Add(cartItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

     
  
        [HttpGet]  
        public PartialViewResult Edit(Int32 id)  // Update PartialView  
        {  
            CartItem cartItem = db.CartItems.Where(x => x.Id == id).FirstOrDefault();  
            CartItem cartItm = new CartItem();  
  
            cartItm.Id = cartItem.Id;  
            cartItm.productId = cartItem.productId;  
            cartItm.quantity = cartItem.quantity;  
            cartItm.cartId = cartItem.cartId;  
  
            return PartialView(cartItem);  
        }  
  
        [HttpPost]  
        public JsonResult Edit(CartItem cartItem)  // Record Update 
        {  
              
            CartItem cartItm = db.CartItems.Where(x => x.Id == cartItem.Id).FirstOrDefault();  
  
            cartItm.quantity = cartItem.quantity;  
            db.SaveChanges();  
  
            return Json(cartItm, JsonRequestBehavior.AllowGet);  
        }  
  
        public JsonResult Delete(Int32 id)  
        {  
            CartItem cartItem = db.CartItems.Where(x => x.Id == id).FirstOrDefault();  
            db.CartItems.Remove(cartItem);  
            db.SaveChanges();  
            return Json(true, JsonRequestBehavior.AllowGet);  
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
