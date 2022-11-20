using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using MRDTO;

namespace MRDAO
{
    public class LoaiPhongDAO
    {
        private DataProvider dp;

        public LoaiPhongDAO()
        {
            dp = new DataProvider();
        }
        public List<tb_LoaiPhong> GetLoaiPhong(string sql)
        {
            List<tb_LoaiPhong> list = new List<tb_LoaiPhong>();
            string LoaiPhong, MaLoaiPhong;
            int IdLoaiPhong;
            dp.Connect();
            try
            {
                SqlDataReader dr = dp.ExecuteReader(sql);
                while (dr.Read())
                {
                    IdLoaiPhong = dr.GetInt16(0);
                    LoaiPhong = dr.GetString(1);
                    MaLoaiPhong = dr.GetString(2);
                   

                    tb_LoaiPhong pro = new tb_LoaiPhong(LoaiPhong);
                    list.Add(pro);
                }
                return list;
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



        public DataTable GetDataLoaiPhong()
        {
            string sql = "SELECT * FROM tb_LoaiPhong";
            DataTable da = dp.ExecuteAdapter(sql);
            return da;
        }

        public DataTable GetDataLoaiPhong(string id_Phong_DonGia)
        {
            string sql = "SELECT * FROM tb_Phong WHERE id_Phong_DonGia = '" + id_Phong_DonGia + "'";
            DataTable da = dp.GetData(sql);
            return da;
        }

        //public List<LoaiPhong> getloaiphong(string sql)
        //{
        //    List<SqlParameter> paras = new List<SqlParameter>();
        //    paras.Add(new SqlParameter("@ma", ma));
        //    List<LoaiPhong> list = new List<LoaiPhong>();
        //    string ten, ghichu;
        //    int dientich, dongia;
        //    dp.Connect();
        //    try
        //    {
        //        SqlDataReader dr = dp.ExecuteReader(sql);
        //        while (dr.Read())
        //        {
        //            ma = dr.GetString(0);
        //            ten = dr.GetString(1);
        //            dientich = dr.GetInt32(2);
        //            dongia = dr.GetInt32(3);
        //            ghichu = dr.GetString(4);

        //            LoaiPhong pro = new LoaiPhong(ma,ten,dientich,dongia,ghichu);
        //            list.Add(pro);
        //        }
        //        return list;
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dp.Disconnect();
        //    }
        //}

        //public DataTable GetDataTWChild(string where, string trangthai)
        //{
        //    DataTable nodecon = new DataTable();
        //    dp.Connect();
        //    if (trangthai == "NoVacant")
        //    {
        //        nodecon = dp.GetData("SELECT MaPhong, TenPhong FROM Phong Where MaKhuVuc='" + where + "'AND TrangThai=N'Đã thuê'");
        //    }
        //    else
        //        nodecon = dp.GetData("SELECT MaPhong, TenPhong FROM Phong Where MaKhuVuc='" + where + "'AND TrangThai=N'Trống'");

        //    return nodecon;
        //}
    }
}
