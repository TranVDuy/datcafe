using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using duycoffee.Models;

namespace duycoffee.Controllers
{
    public class ThayDoiController : Controller
    {
        // GET: ThayDoi
        qlduycoffeeDataContext db = new qlduycoffeeDataContext();
        public ActionResult DoiThongTin()
        {
            
            string HoDem = Request.Form["HoDem"];
            string Ten = Request.Form["Ten"];
            string SoDienThoai = Request.Form["SoDienThoai"];
            string Email = Request.Form["Email"];

            if (HoDem==null && Ten ==null && SoDienThoai ==null && Email ==null)
            {
                
                return View();
            }

            else
            {

                KhachHang k = db.KhachHangs.Single(s => s.TenDangNhap.Equals(Session["tendn"].ToString()));

                    if (k != null)
                    {
                        if (HoDem != null)
                            k.HoDem = HoDem;
                        if (Ten != null)
                            k.Ten = Ten;
                        if (SoDienThoai != null)
                            k.SoDienThoai = SoDienThoai;
                        if (Email != null)
                            k.Email = Email;

                        db.SubmitChanges();

                        ViewBag.tb = "Thay đổi thành công!";

                       
                    }  

                else
                {
                    ViewBag.tb = "Thay đổi thất bại!";
                    
                }
                return View();
            }
            
        }

        public ActionResult DoiMatKhau() {
            string tendn = Request.Form["TenDangNhap"];
            string mkcu = Request.Form["mkcu"];
            string mkmoi = Request.Form["mkmoi"];
            string mknl = Request.Form["nlmk"];

            if (tendn == null && mkcu == null && mkmoi == null && mknl == null)
                return RedirectToAction("DoiThongTin");
            else
            {
                if (tendn == null)
                {
                    ViewBag.tb1 = "Tên đăng nhập trống!";
                    return RedirectToAction("DoiThongTin");
                }
                if (mkcu == null)
                {
                    ViewBag.tb1 = "Mật khẩu trống!";
                    return RedirectToAction("DoiThongTin");
                }
                if (mkmoi == null)
                {
                    ViewBag.tb1 = "Mật khẩu mới trống!";
                    return RedirectToAction("DoiThongTin");
                }
                if (mknl == null)
                {
                    ViewBag.tb1 = "Mật khẩu nhập lại trống!";
                    return RedirectToAction("DoiThongTin");
                }
                if (!mkmoi.Equals(mknl))
                {
                    ViewBag.tb1 = "Mật khẩu nhập lại không đúng!";
                    return RedirectToAction("DoiThongTin");
                }

                KhachHang k = db.KhachHangs.Single(s => s.TenDangNhap.Equals(tendn));
                if (k != null)
                {
                    k.MatKhau = mknl;
                    db.SubmitChanges();
                    ViewBag.tb1 = "Thay đổi thành công!";
                    return RedirectToAction("DoiThongTin");
                }
                else
                {
                    ViewBag.tb1 = "Thay đổi thất bại";
                    return RedirectToAction("DoiThongTin");
                }
            }
        }



    }
}