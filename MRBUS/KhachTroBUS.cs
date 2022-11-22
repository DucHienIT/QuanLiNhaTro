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
    public class KhachTroBUS
    {
        public List<tb_KhachTro> GetKhach_List(string sql)
        {
            try
            {
                List<tb_KhachTro> result = new KhachTroDAO().GetKhachThue(sql);
                return result;
            }
            catch (SqlException ex)
            {
                
                throw ex ;
            }
        }


        public DataTable GetKhach(string maphong)
        {
            try
            {
                DataTable result = new KhachTroDAO().GetData(maphong);
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public DataTable GetKhachTheoMaPhong(string sql)
        {
            try
            {
                DataTable result = new KhachTroDAO().GetDataChung(sql);
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Insert(string sql,tb_KhachTro kt)
        {
            try
            {
                return new KhachTroDAO().Insert(sql, kt);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int ThucThiSql(string sql)
        {
            try
            {
                return new KhachTroDAO().ThucThiSql(sql);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        
    }
}
