using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using MRDTO;
using System.Windows.Forms;

namespace MRDAO
{
    public class ThongTinNoDAO
    {
        private DataProvider dp;

        public ThongTinNoDAO()
        {
            dp = new DataProvider();
        }

        
        public DataTable GetDataChung(string sql)
        {
            try
            {
                DataTable result = new DataTable();
                dp.Connect();
                result = dp.GetData(sql);
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int Insert(string sql, tb_ThongTinNo kt)
        {

            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@id_ThongTinNo_Phong", kt.id_ThongTinNo_Phong));
            paras.Add(new SqlParameter("@SoTienNo", kt.SoTienNo));
            
            try
            {
                return (dp.IExecuteNonQuery(sql, System.Data.CommandType.Text, paras));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


    }
}
