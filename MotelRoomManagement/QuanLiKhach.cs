using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MRBUS;
using MRDTO;
using System.Collections;

namespace MotelRoomManagement
{
    public partial class QuanLiKhach : UserControl
    {
        Room data = new Room();
        string maKhackTro;
        int idPhong;
     
        public QuanLiKhach()
        {
            InitializeComponent();
        }

        private void QuanLiKhach_Load(object sender, EventArgs e)
        {
            Load_DSKhach();
        }

        

        private void Load_datagrid(string sql)
        {
            dgvQLKhach.Rows.Clear();

            dgvQLKhach.ColumnCount = 5;
            dgvQLKhach.Columns[0].Name = "Mã Khách";
            dgvQLKhach.Columns[1].Name = "Mã Phòng";
            dgvQLKhach.Columns[2].Name = "Họ và tên";
            dgvQLKhach.Columns[3].Name = "CCCD";
            dgvQLKhach.Columns[4].Name = "Năm sinh";
           
            var dsphong = new Room().GetDataPhong(sql);
           
            for (int i = 0; i < dsphong.Rows.Count; i++)
            {
                ArrayList row = new ArrayList();
                
                row.Add(dsphong.Rows[i][0].ToString());
                row.Add(dsphong.Rows[i][1].ToString());
                row.Add(dsphong.Rows[i][2].ToString());
                row.Add(dsphong.Rows[i][3].ToString());
                row.Add(dsphong.Rows[i][4].ToString());
                dgvQLKhach.Rows.Add(row.ToArray());
                
            }

            


        }

        private void Load_DSKhach()
        {
            
            string sql = "select kt.MaKhachTro, p.MaPhong, kt.HoTen, kt.CCCD, kt.NamSinh from tb_KhachTro kt, tb_Phong p Where kt.id_KhachTro_Phong = p.IdPhong";
           
            Load_datagrid(sql);
            

        }

        private void cbKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DSKhach();
        }


        private void dgvQLKhach_SelectionChanged(object sender, EventArgs e)
        {
            clearall();
            if (dgvQLKhach.SelectedCells.Count > 0)
            {
                int index = dgvQLKhach.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dgvQLKhach.Rows[index];
                string makhach = Convert.ToString(selectedrow.Cells["Mã Khách"].Value).Trim();
             
                string sql = "SELECT * FROM tb_KhachTro WHERE MaKhachTro = N'" + makhach + "'";
              
                List<tb_KhachTro> tmp = new KhachTroBUS().GetKhach_List(sql);
                maKhackTro = makhach.Trim();
                txtCCCD.DataBindings.Add("Text", tmp, "CCCD");
                txtHoTen.DataBindings.Add("Text", tmp, "HoTen");
                txtNamSinh.DataBindings.Add("Text", tmp, "NamSinh");
                txtSdt.DataBindings.Add("Text", tmp, "SoDienThoai");
                txtQue.DataBindings.Add("Text", tmp, "QueQuan");
                txtNghe.DataBindings.Add("Text", tmp, "NgheNghiep");
                txtTenDangNhap.DataBindings.Add("Text", tmp, "TenDangNhap");


          
                idPhong = int.Parse(tmp[0].id_KhachTro_Phong.ToString());


            }
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnSua.Visible = true;
        }

        private void clearall()
        {
          
            txtCCCD.DataBindings.Clear();
            txtHoTen.DataBindings.Clear();
            txtNamSinh.DataBindings.Clear();
           
            txtSdt.DataBindings.Clear();
            txtQue.DataBindings.Clear();
            txtNghe.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Clear();

           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtCCCD.Enabled = true;
            txtHoTen.Enabled = true;
            txtNamSinh.Enabled = true;
            txtSdt.Enabled = true;
            txtQue.Enabled = true;
            txtNghe.Enabled = true;
            txtTenDangNhap.Enabled = true;
     
            btnSave.Visible = true;
            btnCancel.Visible = true;
            
            btnSua.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           txtCCCD.Enabled = false;
            txtHoTen.Enabled = false;
            txtNamSinh.Enabled = false;
            txtSdt.Enabled = false;
            txtQue.Enabled = false;
            txtNghe.Enabled = false;
            txtTenDangNhap.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnSua.Visible = true;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string hoten, cccd, quequan, nghenghiep, sdt, tendangnhap;
            int namsinh;
           
            hoten = txtHoTen.Text;            
            namsinh = int.Parse(txtNamSinh.Text.Trim());
            cccd = txtCCCD.Text.Trim();
            sdt = txtSdt.Text.Trim();
            quequan = txtQue.Text.Trim();
            nghenghiep = txtNghe.Text.Trim();
            tendangnhap = txtTenDangNhap.Text.Trim();
     

            txtCCCD.Enabled = false;
            txtHoTen.Enabled = false;           
            txtNamSinh.Enabled = false;
            txtSdt.Enabled = false;
            txtQue.Enabled = false;
            txtNghe.Enabled = false;
            txtTenDangNhap.Enabled = false;
        
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnSua.Visible = true;

            tb_KhachTro kt = new tb_KhachTro(cccd, hoten, sdt, namsinh, quequan, nghenghiep, idPhong, tendangnhap);
            string sql = "Exec proc_CapNhatThongTinKhachTro " + maKhackTro + ", @CCCD, @HoTen, @SoDienThoai, @NamSinh, @QueQuan, @NgheNghiep, @TenDangNhap";
            KhachTroBUS khachtro = new KhachTroBUS();
            khachtro.Insert(sql, kt);
            MessageBox.Show("Đã sửa thông tin khách!");

            //Refresh
            Load_DSKhach();
        }
    }
}
