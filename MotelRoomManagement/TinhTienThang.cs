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

namespace MotelRoomManagement
{
    public partial class TinhTienThang : UserControl
    {
        Room data = new Room();
        private int tiennha, tiendien, tiennuoc2,tongtien;
        int thismonth = DateTime.Today.Month;
        int thisyear = DateTime.Today.Year;

        string idPhong;
        public TinhTienThang()
        {
            InitializeComponent();
        }

       

        private void TinhTienThang_Load(object sender, EventArgs e)
        {
            load_phong();
        }

        

        //Load Phòng chưa lập hóa đơn
        private void load_phong()
        {
            lvPhong.Items.Clear();
          
            
            var phong = data.GetDataPhong("SELECT * From tb_Phong WHERE id_Phong_TrangThaiPhong <> 1 AND IdPhong not in (Select id_HoaDon_Phong From tb_HoaDon Where MONTH(NgayXuatHoaDon)= " + thismonth + " AND YEAR(NgayXuatHoaDon)= " + thisyear +" )");

            for (int i = 0; i < phong.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(phong.Rows[i][1].ToString());
                item.ImageIndex = 0;
                lvPhong.Items.Add(item);
            }

            gpLHD.Text = "Lập hóa đơn tháng " + thismonth;
        }


        private void lvPhong_Click(object sender, EventArgs e)
        {
            //Lay ma phong chon tu list
            string tp = lvPhong.SelectedItems[0].Text;
            string sql = "SELECT IdPhong, MaPhong, TenPhong FROM tb_Phong WHERE TenPhong=N'" + tp + "'";
            //MessageBox.Show(tp);
            var mp = data.GetDataPhong(sql);

            //Load Thong Tin Phong Thue
            idPhong = mp.Rows[0][0].ToString();
            string maphong = mp.Rows[0][1].ToString();
          
            txtMaPhong.Text = maphong;
            txtTenPhong.Text = mp.Rows[0][2].ToString();
  
            //Load Thong Tin Chu Thue
            string sqlkhach = "SELECT kt.MaKhachTro, kt.HoTen FROM tb_KhachTro kt WHERE kt.id_KhachTro_Phong = " + idPhong;
            var khach = data.GetDataPhong(sqlkhach);

            //combobox Ten Chu Thue
            txtSoluong.Text = khach.Rows.Count.ToString();
            if (khach.Rows.Count == 0)
            {
                ClearThongTinKhach();
            }
                
            cbMaKhachThue.DisplayMember = "HoTen";
            cbMaKhachThue.ValueMember = "MaKhachTro";
            cbMaKhachThue.DataSource = khach;
            
            //Load Thong Tin Dich Vu
            string sqldichvu = "SELECT p.TenPhong, lp.DonGia From tb_Phong p, tb_DonGiaPhong lp WHERE lp.IdDonGiaPhong=p.id_Phong_DonGia AND p.MaPhong=N'" + maphong + "'";
            var dichvu = data.GetDataPhong(sqldichvu);

            txtLoaiPhong.Text = dichvu.Rows[0][0].ToString();
            tiennha = Convert.ToInt32(dichvu.Rows[0][1].ToString());
            string gia = string.Format("{0:#,##0}", Int32.Parse(dichvu.Rows[0][1].ToString()));
            txtTienNha.Text = gia;

        }

        private void cbMaKhachThue_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            // Load chi tiet thong tin khach
            string makhach = cbMaKhachThue.SelectedValue.ToString();
            string sql = "SELECT CCCD, NgheNghiep, SoDienThoai FROM tb_KhachTro WHERE MaKhachTro=N'" + makhach + "'";
            var thongtinkhach = data.GetDataPhong(sql);

            txtCCCD.Text = thongtinkhach.Rows[0][0].ToString();
            txtNN.Text = thongtinkhach.Rows[0][1].ToString();
            txtSdt.Text = thongtinkhach.Rows[0][2].ToString();
        }

       

        

        private void txtSoKi_TextChanged(object sender, EventArgs e)
        {
            int soki = 0;
            //Load tien dich vu
            Room data = new Room();
            string str_soki = txtSoKi.Text;
            if (txtSoKi.Text != "") 
                soki = Convert.ToInt32(str_soki);
            //Tinh
            tiendien = soki * 2500;
            //Xuat
            txtTienDien2.Text = string.Format("{0:#,##0}", Int32.Parse(tiendien.ToString())); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (thismonth == 12)
            {
                thisyear += 1;
                thismonth = 1;
            }    

            else
                thismonth += 1;
            load_phong();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (thismonth == 1)
            {
                thisyear -= 1;
                thismonth = 12;
            }

            else
                thismonth -= 1;

            load_phong();
        }

   
        private void txtSoKhoi_TextChanged(object sender, EventArgs e)
        {
            int sokhoi = 0;
            //Load tien dich vu
            Room data = new Room();
        

            string str_sokhoi = txtSoKhoi.Text;
   
            if(txtSoKhoi.Text!="")
                sokhoi = Convert.ToInt32(str_sokhoi);
            //Tinh            
            tiennuoc2 = sokhoi * 5000;
            //Xuat
            txtTienNuoc.Text = string.Format("{0:#,##0}", Int32.Parse(tiennuoc2.ToString()));
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {                     
                                         
            tongtien = tiennha + tiendien + tiennuoc2;
            txtTongCong.Text = string.Format("{0:#,##0}", Int32.Parse(tongtien.ToString()))+" vnd";
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
           
            //Lay du lieu bang phieu thu
            double idPT = new LanThanhToanBUS().newID();
          
            DateTime ngaylap = dtLapHoaDon.Value;
            DateTime kihan = dtKiHanThanhToan.Value;
            int TrangThai = 1;
            int sokidien = Convert.ToInt32(txtSoKi.Text);
            int PT_tiennuoc, sokhoinuoc;
            string maphong = txtMaPhong.Text;
            sokhoinuoc = Convert.ToInt32(txtSoKhoi.Text);
            PT_tiennuoc = tiennuoc2;
            

            //Xac Nhan
            if (MessageBox.Show("Thời gian lập hóa đơn: \n" + ngaylap.ToString() + "\nMã Phòng: "+maphong, "Xác nhận lập hóa đơn: " + idPT, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                //Insert vao bang phieu thu
                tb_HoaDon pt = new tb_HoaDon(int.Parse(idPhong), ngaylap,kihan,  sokidien, sokhoinuoc, tongtien, tongtien, TrangThai);
                string sql = "Exec proc_XuatHoaDonPhong @id_HoaDon_Phong, @NgayXuatHoaDon, @KiHanThanhToan, @SoDien, @SoNuoc";
                int i = new HoadonBUS().Insert(sql, pt);
                if (i == 1)
                    MessageBox.Show("Lập hóa đơn thành công");
                else
                    MessageBox.Show("Không thành công");
                
            }
            //Refresh
            load_phong();
            ClearAll();
        }

        private void ClearAll()
        {
            txtMaPhong.Text = "";
            txtTenPhong.Text = "";
      
            txtSoluong.Text = "";
            cbMaKhachThue.Text = "";
            txtCCCD.Text = "";
            txtNN.Text = "";
            txtSdt.Text = "";
            txtLoaiPhong.Text = "";
            txtTienNha.Text = "";
            txtSoKi.Text = "";
            txtTienDien2.Text = "";
            txtSoKhoi.Text = "";
          
           
        }
        private void ClearThongTinKhach()
        {
            txtSoluong.Text = "";
            cbMaKhachThue.Text = "";
            txtCCCD.Text = "";
            txtNN.Text = "";
            txtSdt.Text = "";
        }

    }
}
