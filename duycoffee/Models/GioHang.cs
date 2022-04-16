using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace duycoffee.Models
{
    public class GioHang
    {
        public long Ma { set; get; }
        public string Ten { set; get; }
        public long Gia { set; get; }
        public long Soluong { set; get; }
        public long ThanhTien { set; get; }
        public string Anh { set; get; }
        public string GiaHT { set; get; }

        public GioHang(long Ma, string Ten, long Gia, long Soluong, string Anh, string GiaHT)
        {
            this.Ma = Ma;
            this.Ten = Ten;
            this.Gia = Gia;
            this.Soluong = Soluong;
            this.Anh = Anh;
            this.ThanhTien = Soluong * Gia;
            this.GiaHT = GiaHT;
        }
        public GioHang()
        {

        }
    }
}