using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using duycoffee.Models;
namespace duycoffee.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        qlduycoffeeDataContext db = new qlduycoffeeDataContext();
        
        public ActionResult MenuCoffee()
        {
            IEnumerable<SanPham> ds = null;
           
            string timkiem = Request.Form["tk"];
            string tam = Request.QueryString["page"];
            string ma = Request.QueryString["ma"];
            int trang = 1;
            if (tam != null)
                trang = int.Parse(tam);
            if (ma!=null)
            {
                int maloai = int.Parse(ma);
                if (maloai == 0)
                {
                    ds = db.SanPhams.Where(s => s.SanPhamNoiBat == true).ToList();
                }
                else
                {
                    ds = db.SanPhams.Where(s => s.MaLoai == maloai).ToList();
                }
            }
                
            else
            {
                if (timkiem != null)
                    ds = db.SanPhams.Where(s => s.TenSanPham.ToLower().Contains(timkiem.ToLower())).ToList();
                else
                {
                    ds = db.SanPhams.ToList();
                }
            }

            Session["sosp"] = ds.Count();

            return View(ds.Skip(trang * 10 - 10).Take(10));
        }

        public ActionResult Loai()
        {
           
            return PartialView(db.Loais.ToList());
        }

       
      
    }
}