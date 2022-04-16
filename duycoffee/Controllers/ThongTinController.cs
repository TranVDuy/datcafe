using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using duycoffee.Models;
namespace duycoffee.Controllers
{
    public class ThongTinController : Controller
    {
        // GET: ThongTin
        qlduycoffeeDataContext db = new qlduycoffeeDataContext();
        
        public ActionResult ThongTinKhachHang()
        {
            string tendn = Session["tendn"].ToString();
            return View(db.KhachHangs.Where(k=>k.TenDangNhap == tendn));
        }
    }
}