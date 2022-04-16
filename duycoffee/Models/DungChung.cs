using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
namespace duycoffee.Models
{
    public class DungChung
    {
        public SqlConnection cn;

        public void ketnoi()
        {
            string con = "Data Source=DELLCUADUY;Initial Catalog=qlcafe;User ID=sa;Password=123";
            cn = new SqlConnection(con);
            cn.Open();
        }
    }
}