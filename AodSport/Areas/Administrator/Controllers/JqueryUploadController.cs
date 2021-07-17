using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Veslic;

namespace AodSport.Areas.Administrator.Controllers
{
    //[Authorize]
    public class JqueryUploadController : Controller
    {
        public string pathUpload = "/Content/Upload";
        [HttpPost]
        public ActionResult UploadFiles()
        {
            if (!Directory.Exists(Server.MapPath(pathUpload)))
            {
                Directory.CreateDirectory(Server.MapPath(pathUpload));
            }
            // Checking no of files injected in Request object  
            var lstFile = new List<string>();
            if (Request.Files.Count <= 0) return Json("Bạn chưa chọn file.");
            try
            {
                //  Get all files from Request object  
                var files = Request.Files;
                var name = ""; long size = 0;
                object[] response = new object[files.Count];
                for (var i = 0; i < files.Count; i++)
                {
                    var file = files[i];
                    var fname = "";
                    // Checking for Internet Explorer  
                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    {
                        if (file != null)
                        {
                            var testfiles = file.FileName.Split(new[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                    }
                    else
                    {
                        if (file != null) fname = file.FileName;
                    }
                    name = fname;
                    fname = HelperString.UnsignCharacter(string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddhhmmss-"), fname));
                    fname = fname.Replace(",", "-");
                    var linkfile = string.Format("{0}/{1}", pathUpload, fname);
                    lstFile.Add(linkfile);
                    // Get the complete folder path and store the file inside it.  
                    fname = Path.Combine(Server.MapPath(pathUpload), fname);
                    if (file == null) continue;
                    file.SaveAs(fname);
                    //get size
                    long sizefile = new FileInfo(fname).Length;
                    size = sizefile;
                    //get ten 
                    var abcd = Request.Form.GetValues("abcd");

                    var linkabcd = "";

                    //for (int j = 0; j < abcd.Count(); j++)
                    //{
                    //    valuleAbcd = abcd[0];
                    //    //var fabcd = HelperString.UnsignCharacter(string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddhhmmss-"), valuleAbcd));
                    //    //linkabcd = string.Format("{0}", fabcd);
                    //}
                    var fileb = new
                    {
                        thumbnailUrl = fname,
                        url = linkfile,
                        urlabcd = linkabcd,
                        name = name,
                        abcd = abcd,
                        deleteUrl = "/JqueryUpload/DeleteFile?url=" + fname,
                        size = size,
                        deleteType = "GET"
                    };
                    response[i] = fileb;
                }
                // Returns message that successfully uploaded  
                return Json(new { files = response, JsonRequestBehavior.AllowGet });
            }
            catch (Exception)
            {
                return Json(new
                {
                    error = "Upload không thành công"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [ValidateInput(false)]
        public ActionResult DeleteFile(string url)
        {
            var arr = url.Split(',');
            for (int i = 0; i < arr.Length; i++)
            {
                var link = HelperCommon.GetPath(pathUpload, arr[i].Split('/').Last());
                System.IO.File.Delete(link);

            }
            return Json("Ok", JsonRequestBehavior.AllowGet);
        }
    }
}