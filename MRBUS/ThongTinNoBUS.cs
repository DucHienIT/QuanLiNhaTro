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
    public class ThongTinNoBUS
    {
        

        public DataTable GetData(string sql)
        {
            try
            {
                DataTable result = new ThongTinNoDAO().GetDataChung(sql);
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

      
        public int Insert(string sql, tb_ThongTinNo kt)
        {
            try
            {
                return new ThongTinNoDAO().Insert(sql, kt);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


    }
}
