using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Bussiness;
using SqlDataProvider.Data;

namespace AodSport.Areas.Administrator.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {

        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult ListData(int page = 1, int pageSize = 100)
        {
            List<Admin> listData = null;
            var total = 0;
            ViewBag.totalPage = 0;
            ViewBag.total = total;
            ViewBag.stt = 0;
            ViewBag.pageSize = pageSize;
            ViewBag.page = page;
            
            try
            {
                //using (AdminBussiness db = new AdminBussiness())
                //{
                //    listData = db.GetByPage(page, pageSize,ref total, 0, keySeach,"Id","*", 0);
                //}
                //var keySeach = Request["keySearch"];
                //if (!string.IsNullOrEmpty(keySeach))
                //{
                //    listData = listData.Where(g => g.Username.Contains(keySeach) || g.Email.Contains(keySeach) || g.FullName.Contains(keySeach));
                //}

                //var fieldSort = Request["fieldSort"];
                //if (!string.IsNullOrEmpty(fieldSort))
                //{
                //    switch (fieldSort)
                //    {
                //        case "Username":
                //            useries = useries.OrderBy(g => g.Username);
                //            break;
                //        case "Username_des":
                //            useries = useries.OrderByDescending(g => g.Username);
                //            break;
                //        case "Email":
                //            useries = useries.OrderBy(g => g.Email);
                //            break;
                //        case "Email_des":
                //            useries = useries.OrderByDescending(g => g.Email);
                //            break;
                //        case "FullName":
                //            useries = useries.OrderBy(g => g.FullName);
                //            break;
                //        case "FullName_des":
                //            useries = useries.OrderByDescending(g => g.FullName);
                //            break;
                //        case "Status":
                //            useries = useries.OrderBy(g => g.Status);
                //            break;
                //        case "Status_des":
                //            useries = useries.OrderByDescending(g => g.Status);
                //            break;
                //        default:
                //            useries = useries.OrderByDescending(g => g.Id);
                //            break;
                //    }
                //}
                //else
                //{
                //    useries = useries.OrderByDescending(g => g.Id);
                //}
                //var total = useries.Count();
                //ViewBag.total = total;
                //ViewBag.totalPage = Math.Ceiling(((double)total / pageSize));
                //ViewBag.stt = (page - 1) * pageSize;
                //listData = useries.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            }
            catch (Exception ex)
            {
                //Log.Error("Users/ListData", ex);
            }
            return PartialView(listData);
        }


        //public ActionResult Create()
        //{
        //    ViewData["lstGroupUser"] =
        //        db.UserGroups.Where(g => g.Status).OrderBy(g => g.Ordering).ThenBy(g => g.Id).ToList();
        //    var lstMenu = db.Menu.Where(g => g.Status).AsNoTracking().ToList();
        //    ViewData["lstMenu"] =
        //        db.Menu.Where(g => g.Status).OrderBy(g => g.Ordering).ThenBy(g => g.Id).ToList();

        //    var lstQuyTrinh = db.QuyTrinhXuatBan.Where(g => g.Status).AsNoTracking().ToList();
        //    ViewData["lstQuyTrinh"] = lstQuyTrinh;
        //    return PartialView();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<JsonResult> Create([Bind(Include = "Username,Password,Email, FullName,Phone,Photo,IsThongKe,Roles,GroupIDStr")] Models.Users users)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (string.IsNullOrEmpty(users.Username) || string.IsNullOrEmpty(users.Password))
        //            {
        //                return Json(new { status = false, message = "Không được để trống tên đăng nhập và mật khẩu" }, JsonRequestBehavior.AllowGet);
        //            }
        //            var check = await db.Users.FirstOrDefaultAsync(g => (g.Username == users.Username || (users.Username != null && g.Email == users.Email)) && !g.isDeleted);
        //            if (check != null)
        //            {
        //                return Json(new { status = false, message = "Tên đăng nhập hoặc email đã được sử dụng" }, JsonRequestBehavior.AllowGet);
        //            }
        //            var objUser = Request.GetOwinContext().Authentication.User.Identity.Name;
        //            if (!string.IsNullOrEmpty(objUser))
        //            {
        //                var serializer = new JavaScriptSerializer();
        //                var userData = serializer.Deserialize<Models.Users>(objUser);
        //                users.CreateDate = DateTime.Now;
        //                users.CreateBy = userData.Id;
        //                users.Password = BCrypt.Net.BCrypt.HashPassword(users.Password);

        //                users.Status = (!string.IsNullOrEmpty(Request.Form["Status"]) &&
        //                                Convert.ToBoolean(Request.Form["Status"]));

        //                users.IsRoot = (!string.IsNullOrEmpty(Request.Form["Administrator"]) &&
        //                                Convert.ToBoolean(Request.Form["Administrator"]));
        //                users.Photo = Request["linkFileImage"];
        //                users.GroupIDStr = Request["GroupIDStr"] == null ? "" : Request["GroupIDStr"];
        //                users.Roles = Request["Roles"];
        //                users.MenuID = Request["MenuID"];

        //                db.Users.Add(users);
        //                await db.SaveChangesAsync();
        //            }
        //            else
        //            {
        //                return Json(new { status = false, message = "Tài khoản đã thoát hoặc hết thời gian đăng nhập" }, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            var errors = ModelState.Values.SelectMany(v => v.Errors);
        //            Log.Error("Users/Create - validate Field");
        //            return Json(new { status = false, message = "Lỗi dữ liệu nhập" }, JsonRequestBehavior.AllowGet);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error("Users/Create", ex);
        //        return Json(new { status = false, message = "Thêm mới thất bại" }, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(new { status = true, message = "Thêm mới thành công" }, JsonRequestBehavior.AllowGet);
        //}


        //public async Task<ActionResult> Partiton(int? id)
        //{
        //    Models.Menu obj = await db.Menu.FindAsync(id);
        //    if (obj == null)
        //    {
        //        return Json(new { status = false, message = "Bản ghi không tồn tại" }, JsonRequestBehavior.AllowGet);
        //    }
        //    var lstMenu = db.Menu.Where(g => g.Status).AsNoTracking().ToList();
        //    ViewData["lstMenu"] = lstMenu;
        //    return PartialView(obj);
        //}


        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return Json(new { status = false, message = "Id không được để trống" }, JsonRequestBehavior.AllowGet);
        //    }

        //    Models.Users users = await db.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return Json(new { status = false, message = "Bản ghi không tồn tại" }, JsonRequestBehavior.AllowGet);
        //    }
        //    ViewData["lstGroupUser"] =
        //        db.UserGroups.Where(g => g.Status).OrderBy(g => g.Ordering).ThenBy(g => g.Id).ToList();
        //    var lstQuyTrinh = db.QuyTrinhXuatBan.Where(g => g.Status).AsNoTracking().ToList();
        //    ViewData["lstQuyTrinh"] = lstQuyTrinh;
        //    var lstMenu = db.Menu.Where(g => g.Status).AsNoTracking().ToList();
        //    ViewData["lstMenu"] = lstMenu;
        //    return PartialView(users);
        //}

        //[HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        //public async Task<JsonResult> EditPost(int? id)
        //{
        //    string[] fieldsToBind = new string[] { "Username", "Email", "FullName", "Phone", "Photo", "Roles", "GroupIDStr" };
        //    if (id == null)
        //    {
        //        return Json(new { status = false, message = "Id không được để trống" }, JsonRequestBehavior.AllowGet);
        //    }

        //    var usersToUpdate = await db.Users.FindAsync(id);
        //    if (usersToUpdate == null)
        //    {
        //        return Json(new { status = false, message = "Không thể lưu vì có người dùng khác đang sửa hoặc đã bị xóa" }, JsonRequestBehavior.AllowGet);
        //    }

        //    if (TryUpdateModel(usersToUpdate, fieldsToBind))
        //    {
        //        try
        //        {
        //            var check = await db.Users.FirstOrDefaultAsync(g => (g.Username == usersToUpdate.Username || (usersToUpdate.Username == null && g.Email == usersToUpdate.Email)) && g.Id != usersToUpdate.Id && !g.isDeleted);
        //            if (check != null)
        //            {
        //                return Json(new { status = false, message = "Tên đăng nhập hoặc email đã được sử dụng" }, JsonRequestBehavior.AllowGet);
        //            }

        //            var objUser = Request.GetOwinContext().Authentication.User.Identity.Name;
        //            if (!string.IsNullOrEmpty(objUser))
        //            {
        //                var serializer = new JavaScriptSerializer();
        //                var userData = serializer.Deserialize<Models.Users>(objUser);
        //                usersToUpdate.ModifyDate = DateTime.Now;
        //                usersToUpdate.ModifyBy = userData.Id;
        //                usersToUpdate.Status = (!string.IsNullOrEmpty(Request.Form["Status"]) &&
        //                                Convert.ToBoolean(Request.Form["Status"]));
        //                usersToUpdate.IsThongKe = (!string.IsNullOrEmpty(Request.Form["IsThongKe"]) &&
        //                                Convert.ToBoolean(Request.Form["IsThongKe"]));

        //                usersToUpdate.IsRoot = (!string.IsNullOrEmpty(Request.Form["Administrator"]) &&
        //                                Convert.ToBoolean(Request.Form["Administrator"]));
        //                usersToUpdate.Photo = Request["linkFileImage"];
        //                usersToUpdate.GroupIDStr = Request["GroupIDStr"] == null ? "" : Request["GroupIDStr"];
        //                usersToUpdate.Roles = Request["Roles"];
        //                usersToUpdate.MenuID = Request["MenuID"];


        //                await db.SaveChangesAsync();
        //            }
        //            else
        //            {
        //                return Json(new { status = false, message = "Tài khoản đã thoát hoặc hết thời gian đăng nhập" },
        //                    JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        catch (DbUpdateConcurrencyException ex)
        //        {
        //            var entry = ex.Entries.Single();
        //            var databaseEntry = entry.GetDatabaseValues();
        //            if (databaseEntry == null)
        //            {
        //                Log.Error("Users/EditPost - Bản ghi này đã bị xóa bởi người dùng khác", ex);
        //                return Json(new { status = false, message = "Bản ghi này đã bị xóa bởi người dùng khác" },
        //                    JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                Log.Error("Users/EditPost - Bản ghi này đã bị sửa bởi người dùng khác", ex);
        //                return Json(new { status = false, message = "Bản ghi này đã bị sửa bởi người dùng khác" },
        //                    JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        catch (RetryLimitExceededException ex)
        //        {
        //            Log.Error("Users/EditPost", ex);
        //            return Json(new { status = false, message = "Không thể lưu được" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        Log.Error("Users/EditPost - Không cập nhật được dữ liệu");
        //        return Json(new { status = false, message = "Kiểm tra lại dữ liệu đầu vào" }, JsonRequestBehavior.AllowGet);
        //    }

        //    return Json(new { status = true, message = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);

        //}

        //public async Task<JsonResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return Json(new { status = false, message = "Id không được để trống" }, JsonRequestBehavior.AllowGet);
        //    }
        //    var users = await db.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return Json(new { status = false, message = "Bản ghi đã bị xóa" }, JsonRequestBehavior.AllowGet);
        //    }


        //    try
        //    {
        //        db.Database.ExecuteSqlCommand("delete from Users where Id = " + id);
        //        await db.SaveChangesAsync();
        //        var objUser = Request.GetOwinContext().Authentication.User.Identity.Name;
        //        if (!string.IsNullOrEmpty(objUser))
        //        {
        //            //var serializer = new JavaScriptSerializer();
        //            //var userData = serializer.Deserialize<Models.Users>(objUser);
        //            ////users.DeleteDate = DateTime.Now;
        //            ////users.DeleteBy = userData.Id;
        //            ////users.isDeleted = true;

        //        }
        //        else
        //        {
        //            return Json(new { status = false, message = "Tài khoản đã thoát hoặc hết thời gian đăng nhập" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        Log.Error("Users/Delete", ex);
        //        return Json(new { status = false, message = "Không xóa được bản ghi này" }, JsonRequestBehavior.AllowGet);
        //    }


        //    return Json(new { status = true, message = "Bản ghi đã được xóa thành công" }, JsonRequestBehavior.AllowGet);
        //}

        //public async Task<JsonResult> Status(int? id)
        //{
        //    if (id == null)
        //    {
        //        return Json(new { status = false, message = "Id không được để trống" }, JsonRequestBehavior.AllowGet);
        //    }
        //    var users = await db.Users.FindAsync(id);
        //    if (users == null)
        //    {
        //        return Json(new { status = false, message = "Bản ghi đã bị xóa" }, JsonRequestBehavior.AllowGet);
        //    }


        //    try
        //    {
        //        users.Status = !users.Status;
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        Log.Error("Users/Delete", ex);
        //        return Json(new { status = false, message = "Không thay đổi được trạng thái bản ghi này" }, JsonRequestBehavior.AllowGet);
        //    }


        //    return Json(new { status = true, message = "Bản ghi đã được cập nhật trạng thái thành công" }, JsonRequestBehavior.AllowGet);
        //}

        //public async Task<JsonResult> DeleteAll(string lstid)
        //{
        //    if (string.IsNullOrEmpty(lstid))
        //    {
        //        return Json(new { status = false, message = "lstid không được để trống" }, JsonRequestBehavior.AllowGet);
        //    }
        //    try
        //    {
        //        var objUser = Request.GetOwinContext().Authentication.User.Identity.Name;
        //        if (!string.IsNullOrEmpty(objUser))
        //        {
        //            var serializer = new JavaScriptSerializer();
        //            var userData = serializer.Deserialize<Models.Users>(objUser);
        //            var arrlstId = lstid.Split(',');
        //            var lstUser = await db.Users.Where(g => arrlstId.Contains(g.Id.ToString())).ToListAsync();
        //            if (lstUser.Any())
        //            {
        //                foreach (var itemDelete in lstUser)
        //                {
        //                    //itemDelete.DeleteDate = DateTime.Now;
        //                    //itemDelete.DeleteBy = userData.Id;
        //                    db.Database.ExecuteSqlCommand("delete from Users where Id = " + itemDelete.Id);
        //                    //itemDelete.isDeleted = true;
        //                }

        //                await db.SaveChangesAsync();
        //            }
        //        }
        //        else
        //        {
        //            return Json(new { status = false, message = "Tài khoản đã thoát hoặc hết thời gian đăng nhập" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        Log.Error("Users/Delete", ex);
        //        return Json(new { status = false, message = "Không xóa được bản ghi này" }, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(new { status = true, message = "Bản ghi đã được xóa thành công" }, JsonRequestBehavior.AllowGet);
        //}

        ////Đổi mật khẩu
        //public async Task<ActionResult> ChangePass(int? id)
        //{
        //    Models.Users users = await db.Users.FindAsync(id);
        //    if (id == null)
        //    {
        //        return Json(new
        //        {
        //            IsSuccess = false,
        //            Messenger = "Chưa chọn người dùng!",
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    var obj = db.Users.FirstOrDefault(g => g.Id == id);
        //    ViewBag.id = id;
        //    return View("~/Views/Users/ChangePass.cshtml", obj);
        //}
        //[HttpPost]
        //public ActionResult ChangePass(int id = 0)
        //{
        //    try
        //    {
        //        var Pass = Request["password"];
        //        var RePass = Request["repassword"];
        //        if (Pass != RePass)
        //            return Json(new { status = false, message = "Nhập lại mật khẩu chưa trùng khớp" }, JsonRequestBehavior.AllowGet);

        //        var obj = db.Users.Find(id);
        //        if (obj != null)
        //        {
        //            obj.Password = BCrypt.Net.BCrypt.HashPassword(Pass);
        //            db.Users.AddOrUpdate(obj);
        //            db.SaveChanges();
        //            return Redirect("/Home?success=1");
        //        }
        //        else
        //        {
        //            return Json(new { status = false, message = "Bản ghi không tồn tại hoặc bị xóa" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        var entry = ex.Entries.Single();
        //        var databaseEntry = entry.GetDatabaseValues();
        //        if (databaseEntry == null)
        //        {
        //            Log.Error("Users/ChangePass - Bản ghi này đã bị xóa bởi người dùng khác", ex);
        //            return Json(new { status = false, message = "Bản ghi này đã bị xóa bởi người dùng khác" }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            Log.Error("Users/ChangePass - Bản ghi này đã bị sửa bởi người dùng khác", ex);
        //            return Json(new { status = false, message = "Bản ghi này đã bị sửa bởi người dùng khác" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    return Json(new { status = true, message = "Cập nhật bản ghi thành công!" }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public ActionResult CheckPassOld(int id = 0, string oldpass = "")
        //{
        //    var obj = db.Users.FirstOrDefault(g => g.Id == id);
        //    var matkhaucu = BCrypt.Net.BCrypt.HashPassword(oldpass);
        //    if (BCrypt.Net.BCrypt.Verify(oldpass, obj.Password))
        //    {
        //        return Json(new { result = "1", message = "Mật khẩu cũ trùng khớp." }, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new { result = "0", message = "Sai mật khẩu cũ." }, JsonRequestBehavior.AllowGet);
        //    }

        //}

        ////Cập nhật thông tin đăng nhập
        //public ActionResult ChangeInfo(int id = 0)
        //{
        //    if (id == 0)
        //    {
        //        return Json(new
        //        {
        //            IsSuccess = false,
        //            Messenger = "Chưa chọn người dùng!",
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    var obj = db.Users.FirstOrDefault(g => g.Id == id);
        //    ViewBag.id = id;
        //    return View("~/Views/Users/ChangeInfo.cshtml", obj);
        //}
        //[HttpPost]
        //public async Task<JsonResult> ChangeInfo(string Id = "")
        //{
        //    var photo = Request.Form.GetValues("linkFileImage");

        //    var idUser = Convert.ToInt32(Id);
        //    string[] fieldsToBind = new string[] { "Username", "Email", "FullName", "Phone", "Photo" };
        //    if (idUser == 0)
        //    {
        //        return Json(new { status = false, message = "Id không được để trống" }, JsonRequestBehavior.AllowGet);
        //    }

        //    var usersToUpdate = await db.Users.FindAsync(idUser);
        //    if (usersToUpdate == null)
        //    {
        //        return Json(new { status = false, message = "Không thể lưu vì có người dùng khác đang sửa hoặc đã bị xóa" }, JsonRequestBehavior.AllowGet);
        //    }

        //    if (TryUpdateModel(usersToUpdate, fieldsToBind))
        //    {
        //        try
        //        {
        //            var check = await db.Users.FirstOrDefaultAsync(g => (g.Username == usersToUpdate.Username || (usersToUpdate.Username == null && g.Email == usersToUpdate.Email)) && g.Id != usersToUpdate.Id && !g.isDeleted);
        //            if (check != null)
        //            {
        //                return Json(new { status = false, message = "Tên đăng nhập hoặc email đã được sử dụng" }, JsonRequestBehavior.AllowGet);
        //            }

        //            var objUser = Request.GetOwinContext().Authentication.User.Identity.Name;
        //            if (!string.IsNullOrEmpty(objUser))
        //            {
        //                var serializer = new JavaScriptSerializer();
        //                var userData = serializer.Deserialize<Models.Users>(objUser);
        //                if (photo != null)
        //                {
        //                    usersToUpdate.Photo = photo[0];
        //                }
        //                else
        //                {
        //                    usersToUpdate.Photo = "";
        //                }
        //                await db.SaveChangesAsync();
        //            }
        //            else
        //            {
        //                return Json(new { status = false, message = "Tài khoản đã thoát hoặc hết thời gian đăng nhập" },
        //                    JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        catch (DbUpdateConcurrencyException ex)
        //        {

        //            return Json(new { status = false, message = "Lỗi tải trang" },
        //                JsonRequestBehavior.AllowGet);
        //        }
        //        catch (RetryLimitExceededException ex)
        //        {
        //            return Json(new { status = false, message = "Không thể lưu được" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        Log.Error("Users/EditPost - Không cập nhật được dữ liệu");
        //        return Json(new { status = false, message = "Kiểm tra lại dữ liệu đầu vào" }, JsonRequestBehavior.AllowGet);
        //    }

        //    return Json(new { status = true, message = "Cập nhật thành công" }, JsonRequestBehavior.AllowGet);

        //}

        //[HttpGet]
        //public ActionResult CheckTrungUserName(string id, string username = "")
        //{
        //    var trungName = false;
        //    var lstData = db.Users.ToList();
        //    if (id == "")
        //    {
        //        lstData = lstData.Where(g => g.Username == username).ToList();
        //    }
        //    else
        //    {
        //        lstData = lstData.Where(g => g.Username == username && g.Id != Convert.ToInt32(id)).ToList();
        //    }

        //    if (lstData.Count > 0)
        //    {
        //        trungName = true;
        //    }
        //    else
        //    {
        //        trungName = false;
        //    }
        //    //Form thêm mới
        //    return Json(new
        //    {
        //        trungName = trungName
        //    }, JsonRequestBehavior.AllowGet);
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }

    }
}