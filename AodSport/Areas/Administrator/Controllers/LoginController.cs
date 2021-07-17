using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
namespace AodSport.Areas.Administrator.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult CheckCapCha(string txtimgCode, string code = "")
        {
            var sessionCapCha = Session["CaptchaImageText"];

            if (txtimgCode != sessionCapCha.ToString() || string.IsNullOrEmpty(txtimgCode))
            {
                return Json(new
                {
                    isSuccess = false,
                    Message = string.Format("Kiểm tra lại capcha")
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                isSuccess = true,
            }, JsonRequestBehavior.AllowGet);

        }
        [Authorize]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (!Veslic.Veslic.checkLicense())
            {
                try
                {
                    string active_key = Veslic.Veslic.activeKey();
                    string responeData = "";
                    responeData = Veslic.Veslic.activeServerVES(active_key);
                }
                catch (Exception ex)
                {
                }
                return RedirectToAction("Register", "License");
            }
            return View();
            if (Request.IsAuthenticated)
            {
                //return RedirectToLocal(returnUrl);
            }
            else
            {
                ViewBag.ReturnUrl = returnUrl;
                //var cauHinhMacDinh = db.CauHinhMacDinh.ToList();
                //var emaillogin = cauHinhMacDinh.FirstOrDefault(g => g.Ma == "emaillogin");
                //var dienthoailogin = cauHinhMacDinh.FirstOrDefault(g => g.Ma == "dienthoailogin");
                //var hotlinelogin = cauHinhMacDinh.FirstOrDefault(g => g.Ma == "hotlinelogin");
                //var skypelogin = cauHinhMacDinh.FirstOrDefault(g => g.Ma == "skypelogin");

                //ViewData["emaillogin"] = emaillogin?.NoiDung;
                //ViewData["dienthoailogin"] = dienthoailogin?.NoiDung;
                //ViewData["hotlinelogin"] = hotlinelogin?.NoiDung;
                //ViewData["skypelogin"] = skypelogin?.NoiDung;

                return View();
            }
        }

        //
        // POST: /Account/Login
        [Authorize]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl, string txtimgCode)
        {
            try
            {
                var sessionCapCha = Session["CaptchaImageText"];
                if (txtimgCode != sessionCapCha.ToString() || string.IsNullOrEmpty(txtimgCode))
                {
                    ModelState.AddModelError(string.Empty, "Kiểm tra lại mã captcha.");
                    return View(model);
                }
                //check user
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Lỗi chưa xác định");
            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult Error()
        {
            return View("/Views/Account/_Error.cshtml");
        }

    }
}