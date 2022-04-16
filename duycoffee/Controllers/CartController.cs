using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using duycoffee.Models;
namespace duycoffee.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart

        //GioHangDO gh = null;
        public ActionResult giohang()
        {
            string ma = Request.QueryString["ma"];
            string ten = Request.QueryString["ten"];
            string gia = Request.QueryString["gia"];
            string anh = Request.QueryString["anh"];
            string giaht = Request.QueryString["giaht"];
            if(ma == null)
            {
                ViewBag.tb = "Giỏ hàng trống";
                return View();
            }
            else
            {
                GioHangDO gh = null;
                if (object.ReferenceEquals(Session["gh"], null))
                {
                    gh = new GioHangDO();
                    Session["gh"] = gh;
                }
                
                gh = (GioHangDO)Session["gh"];
                gh.Them(long.Parse(ma), ten, long.Parse(gia), 1, anh, giaht);
                Session["gh"] = gh;
              
            }
            return View();
        }

        public ActionResult Xoa()
        {
            string ma= Request.QueryString["ma"];
            GioHangDO gh;
            gh = (GioHangDO)Session["gh"];
            gh.del(long.Parse(ma));
            Session["gh"] = gh;

            return RedirectToAction("giohang");
        }

        public ActionResult Sua()
        {
            string ma = Request.QueryString["ma"];
            string soluong = Request.Form["soluong"];

            GioHangDO gh;
            gh = (GioHangDO)Session["gh"];

            gh.DieuChinh(long.Parse(ma), long.Parse(soluong));
            Session["gh"] = gh;

            return RedirectToAction("giohang");
        }
        public ActionResult CoTheBanThich()
        {
            qlduycoffeeDataContext db = new qlduycoffeeDataContext();
      
            Random rand = new Random();
         
            int skip = rand.Next(1, 32);

          
            return PartialView(db.SanPhams.Skip(skip).Take(8));
        }

 
    }
}