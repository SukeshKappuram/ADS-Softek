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
using Microsoft.AspNet.Identity;

namespace EshoppingV2._0.Controllers
{
    [Authorize(Roles = "Seller")]
    public class ProductDetailsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProductDetails
        public IQueryable<ProductDetails> GetProductDetails()
        {
            return db.ProductDetails;
        }

        // GET: api/ProductDetails/5
        [ResponseType(typeof(ProductDetails))]
        public IHttpActionResult GetProductDetails(Guid id)
        {
            ProductDetails productDetails = db.ProductDetails.Find(id);
            if (productDetails == null)
            {
                return NotFound();
            }

            return Ok(productDetails);
        }

        // PUT: api/ProductDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductDetails(Guid id, ProductDetails productDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productDetails.SerialNumber)
            {
                return BadRequest();
            }

            db.Entry(productDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDetailsExists(id))
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

        // POST: api/ProductDetails
        [ResponseType(typeof(ProductDetails))]
        public IHttpActionResult PostProductDetails(ProductDetails productDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                productDetails.sellerId=Guid.Parse(user.GetUserId());
                db.ProductDetails.Add(productDetails);
            };

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductDetailsExists(productDetails.SerialNumber))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = productDetails.SerialNumber }, productDetails);
        }

        // DELETE: api/ProductDetails/5
        [ResponseType(typeof(ProductDetails))]
        public IHttpActionResult DeleteProductDetails(Guid id)
        {
            ProductDetails productDetails = db.ProductDetails.Find(id);
            if (productDetails == null)
            {
                return NotFound();
            }

            db.ProductDetails.Remove(productDetails);
            db.SaveChanges();

            return Ok(productDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductDetailsExists(Guid id)
        {
            return db.ProductDetails.Count(e => e.SerialNumber == id) > 0;
        }
    }
}