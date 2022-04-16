using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace duycoffee.Controllers
{
    public class DangXuatController : Controller
    {
        // GET: DangXuat
        public ActionResult XuLyDangXuat()
        {
            Session["gh"] = null;
            Session["makh"] = null;
            Session["tenkh"] = null;
            Session["kh"] = null;
            Session["tendn"] = null;
            Session["avatar"] = null;
            Session["thaydoi"] = null;
            Session["kiemtra"] = null;

            return RedirectToAction("XuLyDangNhap", "DangNhap");
        }
    }
}