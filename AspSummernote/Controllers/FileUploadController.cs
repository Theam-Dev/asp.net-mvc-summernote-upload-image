using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AspSummernote.Controllers
{
    public class FileUploadController : ApiController
    {
        [HttpPost]
        [Route("api/upload")]
        [System.Web.Mvc.HandleError]
        public IHttpActionResult Post()
        {
            var files = HttpContext.Current.Request.Files["uploadFiles"];

            string fileName = Path.GetFileNameWithoutExtension(files.FileName);
            string extension = Path.GetExtension(files.FileName);

            string newFileName = fileName + "-" + DateTime.Now.ToString("yyyymmssffff") + extension;
            string UploadPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Image/"), newFileName);
            var newpaht = "/Content/Image/" + newFileName;

            files.SaveAs(UploadPath);
            return Ok(newpaht);
        }
    }
}
