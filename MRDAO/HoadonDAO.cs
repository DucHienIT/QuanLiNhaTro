using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using MRDTO;
namespace MRDAO
{
    public class HoadonDAO
    {
        private DataProvider dp;

        public HoadonDAO()
        {
            dp = new DataProvider();
        }

        public DataTable GetInfo(string sql)
        {
            DataTable result = new DataTable();
            dp.Connect();
            result = dp.GetData(sql);
            return result;
        }

        public int Insert(string sql, tb_HoaDon pt)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            //paras.Add(new SqlParameter("@IdHoaDon", pt.IdHoaDon));
            paras.Add(new SqlParameter("@id_HoaDon_Phong", pt.id_HoaDon_Phong));
            paras.Add(new SqlParameter("@NgayXuatHoaDon", pt.NgayXuatHoaDon));
            paras.Add(new SqlParameter("@KiHanThanhToan", pt.KiHanThanhToan));
            paras.Add(new SqlParameter("@SoDien", pt.SoDien));
            paras.Add(new SqlParameter("@SoNuoc", pt.SoNuoc));
            paras.Add(new SqlParameter("@SoTienConLaiPhaiThanhToan", pt.SoTienConLaiPhaiThanhToan));
            paras.Add(new SqlParameter("@TongTienPhaiThanhToan", pt.TongTienPhaiThanhToan));
            //paras.Add(new SqlParameter("@MaHoaDon", pt.MaHoaDon));
            paras.Add(new SqlParameter("@TrangThaiHoaDon", pt.TrangThaiHoaDon));
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
            paras.Add(new SqlParameter("@MaPhong", id));
            try
            {
                return (dp.IExecuteNonQuery(sql, CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int XNDongTien2(string sql)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
          
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
