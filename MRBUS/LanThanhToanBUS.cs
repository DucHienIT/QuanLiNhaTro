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
    public class LanThanhToanBUS
    {
        public int Insert(string sql, tb_LanThanhToan pt)
        {
            try
            {
                return new LanThanhToanDAO().Insert(sql, pt);
            }
            catch (SqlException ex)
            {
                
                throw ex;
            }
        }
        public double newID()
        {
            var table = new PhongDAO().GetDataPhong("SELECT * From tb_LanThanhToan");
            table.PrimaryKey = new DataColumn[] { table.Columns["MaLanThanhToan"] };
            double id_pt = table.Rows.Count + 1;            
            return id_pt;
        }
        public int XNDongTien(string sql,string id)
        {
            try
            {
                return (new LanThanhToanDAO().XNDongTien(sql,id));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

    }
}
