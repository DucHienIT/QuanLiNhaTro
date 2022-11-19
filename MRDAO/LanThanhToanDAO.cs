using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MRDTO;

namespace MRDAO
{
    public class LanThanhToanDAO
    {
        private DataProvider dp;
        public LanThanhToanDAO()
        {
            dp = new DataProvider();
        }

        public int Insert(string sql, tb_LanThanhToan pt)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
         
            paras.Add(new SqlParameter("@id_ThanhToan_KhachTro", pt.id_ThanhToan_KhachTro));
            paras.Add(new SqlParameter("@id_ThanhToan_HoaDon", pt.id_ThanhToan_HoaDon));
            paras.Add(new SqlParameter("@SoTienTra", pt.SoTienTra));
            paras.Add(new SqlParameter("@NgayThanhToan", pt.NgayThanhToan));
            try
            {
                return (dp.IExecuteNonQuery(sql, CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int XNDongTien(string sql, string id)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@id_ThanhToan_HoaDon", id));
            try
            {
                return (dp.IExecuteNonQuery(sql, CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


    }
}
