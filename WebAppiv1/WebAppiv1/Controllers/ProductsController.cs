using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppiv1.Models;

namespace WebAppiv1.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/values
        public IEnumerable<Product> Get()
        {
            ProductDB Db = new ProductDB();
            return Db.products;
        }



        // GET api/values/5
        public Product Get(int id)
        {
            ProductDB Db = new ProductDB();
            Product p = Db.products.Single(ps => ps.Id == id);
            return p;
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Product p)
        {
            try
            {
                ProductDB Db = new ProductDB();
                Db.products.Add(p);
                Db.SaveChanges();
                var msg = Request.CreateResponse(HttpStatusCode.Created, p);
                return msg;
            }
            catch (Exception Ex) {
                var msg = Request.CreateErrorResponse(HttpStatusCode.BadGateway, Ex);
                return msg;
            }
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Product p)
        {
            try
            {
                ProductDB Db = new ProductDB();
                Product pd = Db.products.Find(id);
                pd.Id = p.Id;
                pd.Name = p.Name;
                pd.Description = pd.Description;
                pd.manufactureName = p.manufactureName;
                pd.Price = p.Price;
                Db.SaveChanges();
                var msg = Request.CreateResponse(HttpStatusCode.OK, p);
                return msg;
            }
            catch (Exception Ex)
            {
                var msg = Request.CreateErrorResponse(HttpStatusCode.NotModified, Ex);
                return msg;
            }
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ProductDB Db = new ProductDB();
                Product p = Db.products.Single(ps => ps.Id == id);
                Db.products.Remove(p);
                Db.SaveChanges();
                var msg = Request.CreateResponse(HttpStatusCode.OK, p);
                return msg;
            }
            catch (Exception Ex)
            {
                var msg = Request.CreateErrorResponse(HttpStatusCode.NotFound, Ex);
                return msg;
            }
        }
    }
}
