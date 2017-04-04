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
        public void Post([FromBody]Product p)
        {
            ProductDB Db = new ProductDB();
            Db.products.Add(p);
            Db.SaveChanges();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Product p)
        {
            ProductDB Db = new ProductDB();
            Product pd = Db.products.Find(id);
            pd.Id = p.Id;
            pd.Name = p.Name;
            pd.Description = pd.Description;
            pd.manufactureName = p.manufactureName;
            pd.Price = p.Price;
            Db.SaveChanges();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            ProductDB Db = new ProductDB();
            Product p = Db.products.Single(ps => ps.Id == id);
            Db.products.Remove(p);
            Db.SaveChanges();
        }
    }
}
