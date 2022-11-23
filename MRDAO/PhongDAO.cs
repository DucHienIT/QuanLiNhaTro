using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using MRDTO;
using System.Windows.Forms;

namespace MRDAO
{
    public class PhongDAO
    {
        private DataProvider dp;

        public PhongDAO()
        {
            dp = new DataProvider();
        }

        public PhongDAO(string connString)
        {
            dp = new DataProvider(connString);
        }

        public List<tb_Phong> GetPhong(string sql)
        {
            List<tb_Phong> list = new List<tb_Phong>();
            int idPhong, idTrangThaiPhong, idDonGiaPhong;
            string tenPhong, loaiPhong;
            dp.Connect();
            try
            {
                SqlDataReader dr = dp.ExecuteReader(sql);
                while (dr.Read())
                {
                    idPhong = dr.GetInt16(0);
                    tenPhong = dr.GetString(1);
                    idTrangThaiPhong = dr.GetInt16(2);
                    idDonGiaPhong = dr.GetInt16(3);
                    loaiPhong = dr.GetString(4);
                  

                    tb_Phong pro = new tb_Phong(idPhong, tenPhong, idTrangThaiPhong, idDonGiaPhong, loaiPhong);
                    list.Add(pro);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dp.Disconnect();
            }
        }



        public DataTable GetDataTWChild(string trangthai)
        {
            DataTable nodecon = new DataTable();
            dp.Connect();
            try
            {

                if (trangthai == "NoVacant")
                {
                    nodecon = dp.GetData("SELECT MaPhong, TenPhong FROM tb_Phong Where id_Phong_TrangThaiPhong= 2");
                }
                else if (trangthai == "Vacant")
                    nodecon = dp.GetData("SELECT MaPhong, TenPhong FROM tb_Phong Where id_Phong_TrangThaiPhong= 1");
                else
                {
                    nodecon = dp.GetData("SELECT MaPhong, TenPhong FROM tb_Phong Where id_Phong_TrangThaiPhong= 3");
                }
                return nodecon;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                dp.Disconnect();
            }
        }
        public int themphong(string sql, string tenPhong, int idTrangThaiPhong, int idDonGiaPhong)
        {

            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@TenPhong", tenPhong));
            paras.Add(new SqlParameter("@id_Phong_TrangThaiPhong", idTrangThaiPhong));
            paras.Add(new SqlParameter("@id_Phong_DonGia", idDonGiaPhong));
            try
            {
                return (dp.IExecuteNonQuery(sql, System.Data.CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int themloaiphong(string sql,string LoaiPhong)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@LoaiPhong", LoaiPhong));  
            try
            {
                return (dp.IExecuteNonQuery(sql, CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


       /* public DataTable GetCBPhong(string makv)
        {
            DataTable result = new DataTable();
            dp.Connect();
            try
            {
                result = dp.GetData("SELECT MaPhong, TenPhong From Phong Where MaKhuVuc='" + makv + "'AND TrangThai=N'Đã thuê'");
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                dp.Disconnect();
            }
             
        }*/
        public DataTable GetDataPhong(string sql)
        {
            DataTable dt = new DataTable();
            dp.Connect();
            try
            {
                dt = dp.GetData(sql);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                dp.Disconnect();
            }
        }

        public int XoaLoaiPhong(string sql)
        {
            try
            {
                return dp.DExecuteNonQuery(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
       
    }
}
