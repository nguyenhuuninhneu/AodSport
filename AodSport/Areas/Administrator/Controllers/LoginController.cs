using Bussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

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
            //if (!Veslic.Veslic.checkLicense())
            //{
            //    try
            //    {
            //        string active_key = Veslic.Veslic.activeKey();
            //        string responeData = "";
            //        responeData = Veslic.Veslic.activeServerVES(active_key);
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //    return RedirectToAction("Register", "License");
            //}
            return View();
            
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
                var message = "";
                //check user
                try
                {
                    using (AdminBussiness db = new AdminBussiness())
                    {
                        var checkUser = db.CheckUserLogin(model.UserName,model.Password,ref message);
                        if (!checkUser)
                        {
                            ModelState.AddModelError(string.Empty,message);
                            return View(model);
                        }
                        var info = db.GetByUserName(model.UserName);
                        if (info != null && info.IsActive)
                        {
                            // khai bao tren coockie
                            CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                            serializeModel.Id = info.Id;
                            serializeModel.Username = info.UserName;
                            serializeModel.FirstName = info.FirstName;
                            serializeModel.LastName = info.LastName;
                            //gan vao cookie
                            JavaScriptSerializer serializer = new JavaScriptSerializer();

                            string AccountData = serializer.Serialize(serializeModel);

                            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                                1,
                                info.UserName,
                                DateTime.Now,
                                DateTime.Now.AddMinutes(480),
                                false,
                                AccountData);

                            string encTicket = FormsAuthentication.Encrypt(authTicket);
                            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                            Response.Cookies.Add(faCookie);
                            return Redirect("/Administrator/Dashboard");
                        }
                       
                    }
                }
                catch (Exception ex)
                {
                    //log.Error("Load Active is fail!", ex);
                }
                
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
                FormsAuthentication.SignOut();
                return Redirect("/Administrator/Login/Login");
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