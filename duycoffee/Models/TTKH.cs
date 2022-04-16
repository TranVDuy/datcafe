using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace duycoffee.Models
{
    
    public class TTKH
    {
        DungChung dc = new DungChung();
        public KH ttkh(string tendn, string matkhau)
        {
            dc.ketnoi();
            string sql = "SELECT * FROM KhachHang as kh WHERE kh.TenDangNhap = @tendn AND kh.MatKhau = @matkhau";
            SqlCommand cmd = new SqlCommand(sql, dc.cn);
            cmd.Parameters.Add(new SqlParameter("@tendn", tendn));
            cmd.Parameters.Add(new SqlParameter("@matkhau", matkhau));
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                KH kh = new KH(int.Parse(r["MaKH"].ToString()), r["HoDem"].ToString(),
                    r["Ten"].ToString(), r["SoDienThoai"].ToString(), r["Email"].ToString(),
                    r["TenDangNhap"].ToString(), r["MatKhau"].ToString(), bool.Parse(r["ThanhVien"].ToString()));

                return kh;

            }
            r.Close();

            return null;
        }
    }
}