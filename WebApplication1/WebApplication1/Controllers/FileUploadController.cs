using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class FileUploadController : ApiController
    {
        [HttpPost]
        public void UploadFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)
                    string extention=httpPostedFile.FileName.Substring(httpPostedFile.FileName.IndexOf("."));
                    // Get the complete file path
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Images"),"newfile"+extention);

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                }
            }
        }

        public string GetImage(int id) {
            var filePath = HttpContext.Current.Server.MapPath("~/Content/Images");
            string[] files=Directory.GetFiles(filePath,id+".*",SearchOption.TopDirectoryOnly);
            string path = files[0];
            return path;
        }
    }
}
