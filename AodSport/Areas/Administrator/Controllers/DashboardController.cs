using Bussiness;
using SqlDataProvider.Data;
using SqlDataProvider.SqlDataProvider.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AodSport.Areas.Administrator.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Administrator/Dashboard
        public ActionResult Index()
        {
            try
            {
                using (AdminBussiness db = new AdminBussiness())
                {
                    var list = db.GetAll();
                }
            }
            catch (Exception ex)
            {
            }
            return View();
        }
        public ActionResult MenuMain()
        {
            var lstMenu = new List<Menu>() {
            new Menu{Id = 1,ParentId = 0,Name = "Trang chủ", IsBackEnd = true }
            };
            //var lstID = new List<int?>();
            //var strID = "";
            //var objUser = Request.GetOwinContext().Authentication.User.Identity.Name;
            //if (!string.IsNullOrEmpty(objUser))
            //{
            //    var serializer = new JavaScriptSerializer();
            //    var userData = serializer.Deserialize<Models.Users>(objUser);
            //    var arrRoleMenu = !String.IsNullOrEmpty(userData.MenuID) ? userData.MenuID.Split(',').ToList() : null;
            //    var IDLangCurrent = Request.Cookies["IDLangCurrent"].Value;
            //    var currentLang = db.sysLangs.FirstOrDefault(g => g.Status && g.Id.ToString() == IDLangCurrent.ToString());
            //    ViewData["currentLang"] = currentLang;
            //    ViewData["userData"] = userData;

            //    var lstLang = db.sysLangs.Where(g => g.Status && g.Id.ToString() != IDLangCurrent.ToString() && !g.IsDev).AsNoTracking().ToList();
            //    ViewData["lstLang"] = lstLang;
            //    var user = db.Users.Find(userData.Id);
            //    if (user.IsRoot)
            //    {
            //        lstMenu = db.Menu.Where(g => g.Status && g.IsShowMenu).OrderBy(g => g.Ordering).ToList();
            //    }
            //    else
            //    {
            //        var lstRoles = userData.Permission.Split(',').ToList();
            //        if (lstRoles.Count > 0)
            //        {
            //            var lstMenuIDPerm = db.Permission.Where(g => lstRoles.Contains(g.Code)).Select(g => g.AdminMenuID).ToList();
            //            if (lstMenuIDPerm != null)
            //            {
            //                lstMenu = db.Menu.Where(g => g.Status && g.IsShowMenu && lstMenuIDPerm.Contains(g.Id)).OrderBy(g => g.Ordering).ToList();
            //            }
            //        }

            //    }
            //}
            return View(lstMenu);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}