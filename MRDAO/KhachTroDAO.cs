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
    public class KhachTroDAO
    {
        private DataProvider dp;

        public KhachTroDAO()
        {
            dp = new DataProvider();
        }

        public List<tb_KhachTro> GetKhachThue(string sql)
        {
            List<tb_KhachTro> list = new List<tb_KhachTro>();
            int IdKhachTro, NamSinh, id_KhachTro_Phong;
            string CCCD, HoTen, SoDienThoai, QueQuan, NgheNghiep, MaKhachTro, TenDangNhap;
            dp.Connect();
            try 
	        {	        
		        SqlDataReader dr = dp.ExecuteReader(sql);
                while (dr.Read())
                {
                      
                    IdKhachTro = dr.GetInt32(0);
                    CCCD = dr.GetString(1);
                    HoTen = dr.GetString(2);
                    SoDienThoai = dr.GetString(3);
                    NamSinh = dr.GetInt32(4);
                    QueQuan = dr.GetString(5);
                    NgheNghiep = dr.GetString(6);
                    id_KhachTro_Phong = dr.GetInt32(7);
                    MaKhachTro = dr.GetString(8);
                    TenDangNhap = dr.GetString(9);

                   
                    tb_KhachTro khach = new tb_KhachTro(CCCD,HoTen,SoDienThoai,NamSinh,QueQuan,NgheNghiep,id_KhachTro_Phong,TenDangNhap);
                    list.Add(khach);
                    
                }
                return list;
	        }
	        catch (Exception ex)
	        {
		
		        throw ex;
	        }
            finally
            {
                dp.Disconnect();
            }
        }

        


        public DataTable GetData(string maphong)
        {
            try
            {
                DataTable result = new DataTable();
                dp.Connect();
                string strQuery = "Select tb_KhachTro.MaKhachTro AS [Mã khách],CCCD, HoTen AS [Họ và tên], SoDienThoai AS [Số điện thoại], NamSinh AS [Năm Sinh], QueQuan , NgheNghiep, id_KhachTro_Phong AS [Mã phòng] From tb_KhachTro, tb_Phong Where tb_KhachTro.id_KhachTro_Phong = tb_Phong.IdPhong AND tb_Phong.MaPhong = N'" + maphong + "'";
                result = dp.GetData(strQuery);
                
                return result;
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

        public int Insert(string sql, tb_KhachTro kt)
        {

            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@CCCD", kt.CCCD));
            paras.Add(new SqlParameter("@HoTen", kt.HoTen));
            paras.Add(new SqlParameter("@SoDienThoai", kt.SoDienThoai));
            paras.Add(new SqlParameter("@NamSinh", kt.NamSinh));
            paras.Add(new SqlParameter("@QueQuan", kt.QueQuan));
            paras.Add(new SqlParameter("@NgheNghiep", kt.NgheNghiep));            
            paras.Add(new SqlParameter("@id_KhachTro_Phong", kt.id_KhachTro_Phong));            
            paras.Add(new SqlParameter("@TenDangNhap", kt.TenDangNhap));                     
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
