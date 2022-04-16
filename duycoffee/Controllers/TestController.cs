using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;

namespace duycoffee.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            if (this.IsCaptchaValid("Captcha is not valid"))
            {
                Session["kiemtra"] = null;
                return RedirectToAction("XuLyDangNhap", "DangNhap");
            }

            ViewBag.ErrMessage = "Error: captcha is not valid.";
            return View();

            
        }
    }
}