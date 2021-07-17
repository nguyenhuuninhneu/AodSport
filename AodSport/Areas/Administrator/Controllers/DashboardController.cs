using Bussiness;
using SqlDataProvider.Data;
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
    }
}