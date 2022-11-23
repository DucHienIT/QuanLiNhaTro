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
    public class Room
    {
        string connString;
        
        public Room() { }

        public Room(string connString) { this.connString = connString; }
 
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

      

        public DataTable GetDataPhong(string sql)
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

        public DataTable GetDataPhongConnString(string sql)
        {
            try
            {
                DataTable result = new PhongDAO(connString).GetDataPhong(sql);
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
