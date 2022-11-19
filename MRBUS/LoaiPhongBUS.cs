using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using MRDAO;
using MRDTO;

namespace MRBUS
{
    public class LoaiPhongBUS
    {
        public List<tb_LoaiPhong> GetLoaiPhong(string sql)
        {
            try
            {
                List<tb_LoaiPhong> tmp = new LoaiPhongDAO().GetLoaiPhong(sql);
                return tmp;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataTable GetLoaiPhongDA()
        {
            try
            {
                DataTable tmp = new LoaiPhongDAO().GetDataLoaiPhong();
                return tmp;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public DataTable GetLoaiPhongDA(string makhuvuc)
        {
            try
            {
                DataTable tmp = new LoaiPhongDAO().GetDataLoaiPhong(makhuvuc);
                return tmp;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
