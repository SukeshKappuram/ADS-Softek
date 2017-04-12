using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EshoppingV2._0.Models;
using System.IO;

namespace EshoppingV2._0.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ViewProducts(int? id)
        {
            var products = db.Products.Include(p => p.Category);
            var categories = from s in db.Products group s by s.Category;
            ViewBag.Categories = categories;
            if (id == null)
            {
                return View(products.ToList());
            }
            else
            {
                return View(products.Where(c => c.CategoryId == id).ToList());
            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Upload(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();

            }

            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), product.Id+fileName.Substring(fileName.IndexOf(".")));
                    file.SaveAs(path);
                }
            }
            
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            
             return RedirectToAction("Create");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            id = Convert.ToInt32(Request.QueryString["productId"]);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            
            ViewBag.ImageData = getImage(id);
            return View(product);
        }

        public string getImage(int? id) {
            var filePath = Server.MapPath("~/Content/Images");
            string[] files = Directory.GetFiles(filePath, id + ".*", SearchOption.TopDirectoryOnly);
            string path = files[0];
            byte[] imageByteData = System.IO.File.ReadAllBytes(path);
            string imageBase64Data = Convert.ToBase64String(imageByteData);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            return imageDataURL;
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            id = Convert.ToInt32(Request.QueryString["productId"]);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
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
