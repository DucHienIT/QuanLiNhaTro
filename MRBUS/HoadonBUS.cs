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
    public class HoadonBUS
    {
        public DataTable GetInfo(string sql)
        {
            try
            {
                DataTable dsHoaDon = new HoadonDAO().GetInfo(sql);
                return dsHoaDon;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int Insert(string sql, tb_HoaDon pt)
        {
            try
            {
                return new HoadonDAO().Insert(sql, pt);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public double newID()
        {
            var table = new PhongDAO().GetDataPhong("SELECT * From tb_HoaDon");
            table.PrimaryKey = new DataColumn[] { table.Columns["MaHoaDon"] };
            double id_pt = table.Rows.Count + 1;
            return id_pt;
        }
        public int XNDongTien(string sql, string id)
        {
            try
            {
                return (new HoadonDAO().XNDongTien(sql, id));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        public int XNDongTien2(string sql)
        {
            try
            {
                return (new HoadonDAO().XNDongTien2(sql));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}

