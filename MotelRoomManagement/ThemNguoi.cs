﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MRBUS;
using MRDTO;

namespace MotelRoomManagement
{
    public partial class ThemNguoi : UserControl
    {
        string hoten, cccd, quequan, nghenghiep, sdt;
        string makhach, tendangnhap;
        int namsinh, idPhong;

        public ThemNguoi()
        {
            InitializeComponent();
        }

       

        private void ThemNguoi_Load(object sender, EventArgs e)
        {
            
            Load_CBLoaiPhong();
        }


        private void Load_CBLoaiPhong()
        {
            LoaiPhongBUS data = new LoaiPhongBUS();
            var loaiphong = data.GetLoaiPhongDA();
            cbLoaiPhong.ValueMember = "MaLoaiPhong";
            cbLoaiPhong.DisplayMember = "LoaiPhong";
            cbLoaiPhong.DataSource = loaiphong;
        }

       

        private void LoadData_ListPhong()
        {
          
            string loaiphong = cbLoaiPhong.SelectedValue.ToString();
            Room data = new Room();
            var phong = data.GetDataPhong("SELECT MaPhong, TenPhong FROM tb_Phong, tb_DonGiaPhong, tb_LoaiPhong WHERE tb_Phong.id_Phong_TrangThaiPhong = 2 AND tb_Phong.id_Phong_DonGia = tb_DonGiaPhong.IdDonGiaPhong AND tb_LoaiPhong.IdLoaiPhong = tb_DonGiaPhong.id_DonGia_LoaiPhong AND tb_LoaiPhong.MaLoaiPhong = N'" + loaiphong + "'");

            for (int i = 0; i < phong.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(phong.Rows[i][1].ToString());
                item.SubItems.Add(phong.Rows[i][0].ToString());
                item.ImageIndex = 0;
                lvPhong.Items.Add(item);
            }


        }

        

        private void cbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPhong.Items.Clear();
            LoadData_ListPhong();
        }

        private void lvPhong_Click(object sender, EventArgs e)
        {
            Room data = new Room();
          
            string tp = lvPhong.SelectedItems[0].Text;
            
            string sql = "SELECT MaPhong, IdPhong FROM tb_Phong, tb_LoaiPhong, tb_DonGiaPhong WHERE tb_Phong.TenPhong = N'" + tp + "' AND tb_DonGiaPhong.IdDonGiaPhong = tb_Phong.id_Phong_DonGia AND tb_DonGiaPhong.id_DonGia_LoaiPhong = tb_LoaiPhong.IdLoaiPhong";
            var mp = data.GetDataPhong(sql);
            PhongBUS listphong = new PhongBUS();
            string maphong = mp.Rows[0][0].ToString();
            idPhong = Convert.ToInt32(mp.Rows[0][1].ToString());
            string sql1 = "SELECT p.TenPhong, lp.DonGia From tb_Phong p, tb_DonGiaPhong lp WHERE p.MaPhong=N'" + maphong  + "' AND p.id_Phong_DonGia = lp.IdDonGiaPhong";
            var dsphong = listphong.GetThongTinThuePhong(sql1);
            string tenphong = dsphong.Rows[0][0].ToString();
            string gia = string.Format("{0:#,##0}", Int32.Parse(dsphong.Rows[0][1].ToString()));
            lbMaPhong.Text = maphong; lbMaPhong.ForeColor = Color.Red;
            lbTenPhong.Text = tenphong; lbTenPhong.ForeColor = Color.Red;
            lbGia.Text = gia + " vnd"; lbGia.ForeColor = Color.Red;

            Load_ListKhach(maphong);

        }
        //Load ListView Khach thue 
        private void Load_ListKhach(string maphong)
        {
            KhachTroBUS khach = new KhachTroBUS();
            var listkhach = khach.GetKhach(maphong);
            lvKhachThue.Items.Clear();
            for (int i = 0; i < listkhach.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(listkhach.Rows[i][0].ToString());
                item.ImageIndex = 3;
                item.SubItems.Add(listkhach.Rows[i][2].ToString());
                item.SubItems.Add(listkhach.Rows[i][1].ToString());
                item.SubItems.Add(listkhach.Rows[i][3].ToString());
                lvKhachThue.Items.Add(item);
            }
            lbSoNguoi.Text = listkhach.Rows.Count.ToString();
        }

        //Clear Textbox
        private void ClearAll()
        {
            txtHoTen.Text = "";
            txtNamSinh.Text = "";
            txtCCCD.Text = "";
            txtNgheNghiep.Text = "";
            txtQueQuan.Text = "";
            txtSoDienThoai.Text = "";
            txtTenDangNhap.Text = "";
           
        }

        //Nút Clear
        private void buttonX2_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        //Nút Lưu
       
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                //Lay thong tin bang ThongTinKhach
                hoten = txtHoTen.Text.Trim();

                namsinh = int.Parse(txtNamSinh.Text.Trim());
                cccd = txtCCCD.Text.Trim();
                quequan = txtQueQuan.Text.Trim();
                nghenghiep = txtNgheNghiep.Text.Trim();

                sdt = txtSoDienThoai.Text.Trim();
                tendangnhap = txtTenDangNhap.Text.Trim();


               // MessageBox.Show(namsinh.ToString());
                tb_KhachTro kt = new tb_KhachTro(cccd, hoten, sdt, namsinh, quequan, nghenghiep, idPhong, tendangnhap);

                KhachTroBUS khachtro = new KhachTroBUS();
                //Lay thong tin ThongTinThuePhong
                string select_maphong = lbMaPhong.Text;
                DateTime ngaythue = dtpNgayThue.Value;



                if (MessageBox.Show("Bạn có muốn lưu?", "Mã khách trọ: " + makhach, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string sql = "EXEC dbo.proc_ThemKhachTro @CCCD, @HoTen, @SoDienThoai, @NamSinh, @QueQuan, @NgheNghiep, @id_KhachTro_Phong, @TenDangNhap, N'" + txtPass.Text + "'";
                    khachtro.Insert(sql, kt);
                }
                lvPhong.Items.Clear();
                LoadData_ListPhong();

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


    }
}
