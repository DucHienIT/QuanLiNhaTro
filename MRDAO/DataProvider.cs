using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace MRDAO
{
    public class DataProvider
    {
        string cnStr = "";
        SqlConnection cn;

        public DataProvider()
        {
            cnStr = "Data Source=DUCTHINHPC;Initial Catalog=db_QuanLyPhongTro;Integrated Security=True";
            cn = new SqlConnection(cnStr);
        }

        public DataProvider(string connString)
        {
            cnStr = connString;
            cn = new SqlConnection(cnStr);
        }

        public void Connect()
        {
            try
            {
                if (cn != null && cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void Disconnect()
        {
            if (cn != null && cn.State != ConnectionState.Closed)
                cn.Close();
        }
        public SqlDataReader ExecuteReader(string sql)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                return (cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Data TreeView

        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            
        }

        //Select 1 hàng
        public object exeCuteScalarQuery(string sql, CommandType type, List<SqlParameter> paras)
        {
            object result = 0;
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                if (paras != null)
                {
                    foreach (SqlParameter para in paras)
                    {
                        cmd.Parameters.Add(para);
                    }
                }
                result = cmd.ExecuteScalar();
                return result;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
        public DataTable ExecuteAdapter(string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Thêm, sửa 
        public int IExecuteNonQuery(string sql, CommandType type, List<SqlParameter> paras)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                if (paras != null)
                {
                    foreach (SqlParameter para in paras)
                    {
                        cmd.Parameters.Add(para);
                    }
                }
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }

        //Xóa
        public int DExecuteNonQuery(string sql, CommandType type)
        {
            Connect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }

    }
}
