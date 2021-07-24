using Bussiness;
using SqlDataProvider.Data;
using SqlDataProvider.SqlDataProvider.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AodSport.Areas.Administrator.Controllers
{
    [Authorize]
    public class DashboardController : BaseController
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
            var userData = User as CustomPrincipal;
            ViewData["userData"] = userData;
            return View(lstMenu);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}