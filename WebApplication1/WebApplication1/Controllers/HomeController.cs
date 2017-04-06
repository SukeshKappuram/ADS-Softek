using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            var path = "";
            if (file != null) {
                if (file.ContentLength > 0) {
                    if (Path.GetExtension(file.FileName).ToLower() == ".jpg" || Path.GetExtension(file.FileName).ToLower() == ".png")
                    {
                        path = Path.Combine(Server.MapPath("~/Content/Images"), file.FileName);
                        file.SaveAs(path);
                        ViewBag.UploadSuccess = true;
                    }
                }
            }
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        public ActionResult FileUpload() {
            return View();
        }

        public ActionResult UploadImage()
        {
            return View();
        }

        public ActionResult ShowImage()
        {
            return View();
        }

        public ActionResult DisplayImage(int Id) {
            var filePath = Server.MapPath("~/Content/Images");
            string[] files = Directory.GetFiles(filePath, Id + ".*", SearchOption.TopDirectoryOnly);
            string path = files[0];
            byte[] imageByteData = System.IO.File.ReadAllBytes(path);
            string imageBase64Data = Convert.ToBase64String(imageByteData);
            string imageDataURL = string.Format("data:image/png;base64,{0}", imageBase64Data);
            ViewBag.ImageData = imageDataURL;
            return View();
        }


        public JsonResult ImageUpload(ProductViewModel model)
        {

            var file = model.ImageFile;

            if (file != null)
            {

                var fileName = Path.GetFileName(file.FileName);
                var extention = Path.GetExtension(file.FileName);
                var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);

                file.SaveAs(Server.MapPath("/Content/Images/" + file.FileName));


            }

            return Json(file.FileName, JsonRequestBehavior.AllowGet);

        }

    }
}
