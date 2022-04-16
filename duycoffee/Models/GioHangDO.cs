using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace duycoffee.Models
{
    public class GioHangDO
    {
        public List<GioHang> ds = new List<GioHang>();

        public void Them(long Ma, string Ten, long Gia, long Soluong, string Anh, string GiaHT)
        {
            foreach(GioHang g in ds)
            {
                if (g.Ma == Ma)
                {
                    g.Soluong = g.Soluong + Soluong;
                    g.ThanhTien = g.ThanhTien + (Gia * Soluong);
                    return;
                }
                   
            }

            GioHang gh = new GioHang(Ma,Ten,Gia,Soluong,Anh, GiaHT);
            ds.Add(gh);
        }

        public void DieuChinh(long Ma, long SoLuong)
        {
            foreach(GioHang g in ds)
            {
                if(g.Ma == Ma)
                {
                    g.Soluong = SoLuong;
                    g.ThanhTien = g.Soluong * g.Gia;
                    break;
                }
            }
        }

        public void del(long Ma)
        {
            foreach(GioHang gh in ds)
            {
                if(gh.Ma == Ma)
                {
                    ds.Remove(gh); break;
                }
            }
        }
    }
}