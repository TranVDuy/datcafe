using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using duycoffee.Models;

namespace duycoffee.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap

        qlduycoffeeDataContext db = new qlduycoffeeDataContext();
        public ActionResult XuLyDangNhap()
        {
            string tendn = Request.Form["tendn"];
            string matkhau = Request.Form["matkhau"];

            if (tendn==null)
            {
                ViewBag.tb = "Chạy lần đầu!";
                return View();
            }
               
            else
            {

                var kh = db.KhachHangs.Where(k => k.TenDangNhap == tendn && k.MatKhau == matkhau).ToList();
                //TTKH kh = new TTKH();
                //KH khachhang = kh.ttkh(tendn, matkhau);
                if (kh.Count==0)
                {
                    if(object.ReferenceEquals(Session["kiemtra"], null))
                    {
                        Session["kiemtra"] = 1;
                        return View();
                    }

                    int sl = (int)Session["kiemtra"];
                    if (sl >= 3)
                    {
                        return RedirectToAction("Index", "Test");
                    }
                    else
                    {
                        int a = sl + 1;
                        Session["kiemtra"] = a;
                    }
                    ViewBag.tb = "Tên đăng nhập hoặc mật khẩu không đúng";
                    return View();
                }
                else
                {
                   // Session["makh"] = kh.First().MaKH;
                    Session["makh"] = kh.First().MaKH;//db.KhachHangs.Where(k => k.TenDangNhap.Equals(tendn) && k.MatKhau.Equals(matkhau)).Select(k => new { k.MaKH });
                    Session["tenkh"] = kh.First().Ten;
                        

                    Session["kh"] = kh;
                    Session["tendn"] = tendn;
               
                    return RedirectToAction("Home","Blog" );
                }
            }
            
        }

       
    }
}