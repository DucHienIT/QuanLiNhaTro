using MRBUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotelRoomManagement
{
    public partial class frmGeneralUser : Form
    {
        string tendangnhap;
        string matkhau;
        int idPhong;
        int idKhach;
        string connString = "";
        SqlConnection conn;
        public frmGeneralUser(string tenDangNhap, string password)
        {
            InitializeComponent();
            tendangnhap = tenDangNhap;
            matkhau = password;
            
        }

        private void frmGeneralUser_Load(object sender, EventArgs e)
        {
            connString = "Server=DUCTHINHPC;Database=db_QuanLyPhongTro;User Id=" + tendangnhap + ";Password=" + matkhau + ";";
            conn = new SqlConnection(connString); ;
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn = new SqlConnection(connString);
                conn.Open();
                loadKhach();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            
        }
        void loadKhach()
        {
            listKhach.Items.Clear();
            KhachTroBUS _ListKT = new KhachTroBUS(connString);
            string sql = "Select kt.MaKhachTro AS [Mã khách],CCCD, HoTen AS [Họ và tên], SoDienThoai AS [Số điện thoại], NamSinh AS [Năm Sinh], QueQuan , NgheNghiep, id_KhachTro_Phong AS [Mã phòng], IdKhachTro From tb_KhachTro kt Where kt.id_KhachTro_Phong in (Select tb_KhachTro.id_KhachTro_Phong from tb_KhachTro where tb_KhachTro.TenDangNhap = N'" + tendangnhap + "')";
            var list_khach = _ListKT.GetKhachTheoMaPhongConnStr(sql);

            idPhong = int.Parse(list_khach.Rows[0][7].ToString());
            idKhach = int.Parse(list_khach.Rows[0][8].ToString());
            for (int i = 0; i < list_khach.Rows.Count; i++)
            {

                    ListViewItem item = new ListViewItem(list_khach.Rows[i][0].ToString());
                    item.ImageIndex = 3;
                    item.SubItems.Add(list_khach.Rows[i][1].ToString());
                    item.SubItems.Add(list_khach.Rows[i][2].ToString());
                    item.SubItems.Add(list_khach.Rows[i][3].ToString());
                    item.SubItems.Add(list_khach.Rows[i][4].ToString());
                    item.SubItems.Add(list_khach.Rows[i][5].ToString());
                    item.SubItems.Add(list_khach.Rows[i][6].ToString());
                    item.SubItems.Add(list_khach.Rows[i][7].ToString());
                    listKhach.Items.Add(item);
                
            }

        }

        private void btnTrangThai_Click(object sender, EventArgs e)
        {
            frmThanhToanHoaDon_User frm = new frmThanhToanHoaDon_User(idPhong, idKhach,connString);
            frm.ShowDialog();
        }

        private void btnDSTT_Click(object sender, EventArgs e)
        {
            frmQLNo_User frn = new frmQLNo_User(idPhong,connString);
            frn.Show();
        }

        private void btnDSKhach_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
