using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using MRDTO;
using MRDAO;

namespace MRBUS
{
    public class PhongBUS
    {
        public List<tb_Phong> GetPhong(string sql)
        {
            try
            {
                List<tb_Phong> tmp = new PhongDAO().GetPhong(sql);
                return tmp;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }



        public DataTable GetDataTWChild(string trangthai)
        {
            try
            {
                DataTable nodecon = new PhongDAO().GetDataTWChild(trangthai);
                return nodecon;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        
       
        public int themphong(string sql, string tenPhong, int idTrangThaiPhong, int idDonGiaPhong)
        {
            try
            {
                return (new PhongDAO().themphong(sql,tenPhong, idTrangThaiPhong, idDonGiaPhong));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int themloaiphong(string sql, string LoaiPhong)
        { 
            try
            {
                return (new PhongDAO().themloaiphong(sql, LoaiPhong));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

 

        public DataTable GetPhongTrong(string sql)
        {
            try
            {
                DataTable result = new PhongDAO().GetDataPhong(sql);
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public DataTable GetThongTinThuePhong(string sql)
        {
            try
            {
                DataTable result = new PhongDAO().GetDataPhong(sql);
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public int XoaLoaiPhong(string sql)
        {
            try
            {
                return new PhongDAO().XoaLoaiPhong(sql);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        
    }
}
