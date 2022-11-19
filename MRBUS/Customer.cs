using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MRDAO;
using MRDTO;

namespace MRBUS
{
    public class Customer
    {
        public DataTable GetData(string makt)
        {
            DataTable dt = new DataTable();
            DataProvider dp = new DataProvider();
            string sql = "SELECT * FROM ThongTinKhach WHERE MaKhachTro='" + makt + "'";
            dt = dp.GetData(sql);
            return dt;
        }

    }
}
