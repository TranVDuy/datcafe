using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace duycoffee.Models
{
    public class KH
    {
       
        public long MaKH { set; get; }
        public string HoDem { set; get; }
        public string Ten { set; get; }
        public string SoDienThoai { set; get; }
        public string Email { set; get; }
        public string TenDangNhap { set; get; }
        public string MatKhau { set; get; }
        public bool ThanhVien { set; get; }
        

        public KH(long MaKH, string HoDem, string Ten, string SoDienThoai, string Email, string TenDangNhap, string MatKhau, bool ThanhVien)
        {
            this.MaKH = MaKH;
            this.Ten = Ten;
            this.SoDienThoai = SoDienThoai;
            this.Email = Email;
            this.TenDangNhap = TenDangNhap;
            this.MatKhau = MatKhau;
            this.ThanhVien = ThanhVien;
        }
        public KH() { }
    }
}