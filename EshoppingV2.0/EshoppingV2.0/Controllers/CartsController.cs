using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EshoppingV2._0.Models;

namespace EshoppingV2._0.Controllers
{
    public class CartsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Carts
        public IQueryable<CartItem> GetCartItems()
        {
            return db.CartItems;
        }

        // GET: api/Carts/5
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult GetCartItem(int id)
        {
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            return Ok(cartItem);
        }

        // PUT: api/Carts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCartItem(int id, CartItem cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartItem.Id)
            {
                return BadRequest();
            }

            db.Entry(cartItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Carts
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult PostCartItem(CartItem cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CartItems.Add(cartItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cartItem.Id }, cartItem);
        }

        // DELETE: api/Carts/5
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult DeleteCartItem(int id)
        {
            CartItem cartItem = db.CartItems.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            db.CartItems.Remove(cartItem);
            db.SaveChanges();

            return Ok(cartItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartItemExists(int id)
        {
            return db.CartItems.Count(e => e.Id == id) > 0;
        }
    }
}