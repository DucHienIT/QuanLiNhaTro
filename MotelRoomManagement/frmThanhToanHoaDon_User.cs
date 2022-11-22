using MRBUS;
using MRDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotelRoomManagement
{
    public partial class frmThanhToanHoaDon_User : Form
    {
        int idPhongThanhToan, idKhachThanhToan;
        int idHoaDon;
        decimal tongTien,tienConLai;
        public frmThanhToanHoaDon_User(int idPhong, int idKhach)
        {
            InitializeComponent();
            idPhongThanhToan = idPhong;
            idKhachThanhToan = idKhach;
        }

       
        private void frmThanhToanHoaDon_User_Load(object sender, EventArgs e)
        {
            LoadList();
        }


        private void LoadList()
        {

            listHoaDon.Items.Clear();
            string sql = "Select * from tb_HoaDon where tb_HoaDon.id_HoaDon_Phong = " + idPhongThanhToan;
            Room ListLoai = new Room();
            var loaiphong = ListLoai.GetDataPhong(sql);
            for (int i = 0; i < loaiphong.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(loaiphong.Rows[i][8].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][2].ToString().TrimEnd());
                item.SubItems.Add(string.Format("{0:#,##0}", Int32.Parse(loaiphong.Rows[i][7].ToString().TrimEnd())));
                item.SubItems.Add(loaiphong.Rows[i][3].ToString().TrimEnd());


               /* --1 là Quá kì hạn mà chưa thanh toán(giá trị mặc định của cột TrangThaiHoaDon)
                  --2 là Quá kì hạn mà chưa thanh toán đủ(số tiền thanh toán < SoTienPhaiThanhToanCua Hoa Don)
                  --3 là Thanh toán đủ và trong kì hạn
                  --4 là hóa đơn của phòng đã trả hoặc đã bị đuổi nên không thanh toán được 
               */
                if (loaiphong.Rows[i][9].ToString().TrimEnd() == "1")
                {
                    item.SubItems.Add("Chưa thanh toán");
                }
                else if (loaiphong.Rows[i][9].ToString().TrimEnd() == "2")
                    item.SubItems.Add("Chưa thanh toán đủ");
                else if(loaiphong.Rows[i][9].ToString().TrimEnd() == "3")
                    item.SubItems.Add("Đã thanh toán đủ");
                else
                    item.SubItems.Add("Hóa đơn của những phòng trước");
                item.SubItems.Add(string.Format("{0:#,##0}", Int32.Parse(loaiphong.Rows[i][6].ToString().TrimEnd())));
                listHoaDon.Items.Add(item);
            }

        }
       
        private void resetTextBox()
        {
            textBox1.ResetText();
        }
        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                        
            if (checkBox1.Checked == true)
            {
                resetTextBox();
                groupBox2.Visible = true;
            }
            else
            {
                groupBox2.Visible = false;
            }
        }

        private void listHoaDon_Click(object sender, EventArgs e)
        {
            ListViewItem item = listHoaDon.SelectedItems[0];
            string thang = item.Text;
            string sql = "SELECT hd.IdHoaDon,lp.LoaiPhong, dg.DonGia, hd.SoDien, hd.SoNuoc, hd.TongTienPhaiThanhToan , hd.TrangThaiHoaDon, hd.SoTienConLaiPhaiThanhToan FROM tb_HoaDon hd, tb_DonGiaPhong dg, tb_Phong p, tb_LoaiPhong lp WHERE hd.MaHoaDon = N'" + thang + "' AND p.IdPhong = hd.id_HoaDon_Phong AND p.id_Phong_DonGia = dg.IdDonGiaPhong AND lp.IdLoaiPhong = dg.id_DonGia_LoaiPhong ";
            DataTable table = new Room().GetDataPhong(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                grCTHD.Text = "Chi tiết hóa đơn số: " + table.Rows[i][0].ToString().TrimEnd();
                lbLoaiphong.Text = table.Rows[i][1].ToString().TrimEnd();
                lbTienPhong.Text = string.Format("{0:#,##0}", Int32.Parse(table.Rows[i][2].ToString().TrimEnd()));
                lbDienSK.Text = table.Rows[i][3].ToString().TrimEnd();
                lbTienDien.Text = string.Format("{0:#,##0}", Int32.Parse(lbDienSK.Text) * 2500);
                lbNuocSK.Text = table.Rows[i][4].ToString().TrimEnd();
                lbTienNuoc.Text = string.Format("{0:#,##0}", Int32.Parse(lbNuocSK.Text) * 5000);
                lbTT2.Text = string.Format("{0:#,##0}", Int32.Parse(table.Rows[i][5].ToString().TrimEnd())) + " vnd";
                lbTCL.Text = string.Format("{0:#,##0}", Int32.Parse(table.Rows[i][7].ToString().TrimEnd())) + " vnd";
            }
            idHoaDon = Convert.ToInt32(table.Rows[0][0].ToString());
            //tongTien = Convert.ToDecimal(table.Rows[0][5].ToString().TrimEnd());
            tienConLai = Convert.ToDecimal(table.Rows[0][7].ToString().TrimEnd());

            int trangThaiHoaDon = int.Parse(table.Rows[0][6].ToString().TrimEnd());

      
            if (trangThaiHoaDon != 1 && trangThaiHoaDon != 2)
            {
                checkBox1.Visible = false;
                groupBox1.Visible = false;
            }
            else
            {
                checkBox1.Visible = true;
                groupBox1.Visible = true;
            }



        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            decimal soTienTra;
            if(checkBox1.Checked == false)
            {
                soTienTra = tienConLai;
            }
            else
            {
                if(Convert.ToDecimal(textBox1.Text.ToString().TrimEnd()) < tienConLai)
                    MessageBox.Show("Thanh toán ít hơn số tiền còn lại(thanh toán một phần)");
                else if (Convert.ToDecimal(textBox1.Text.ToString().TrimEnd()) > tienConLai)
                    MessageBox.Show("Thanh toán nhiều hơn số tiền còn lại(thanh toán luôn nợ tồn)");
                soTienTra = Convert.ToDecimal(textBox1.Text.ToString().TrimEnd());
            }

            string ngaythu = DateTime.Today.ToShortDateString();
            if (MessageBox.Show("Thời gian thu: " + ngaythu.ToString() + "\nMã Phòng: " + idPhongThanhToan, "Xác nhận thanh toán hóa đơn: " + idHoaDon, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                tb_LanThanhToan tt = new tb_LanThanhToan(idKhachThanhToan, idHoaDon, soTienTra, DateTime.Today);

                string sql_xn = "Exec proc_ThanhToanHoaDon @id_ThanhToan_KhachTro, @id_ThanhToan_HoaDon, @SoTienTra, @NgayThanhToan";
                int i = new LanThanhToanBUS().Insert(sql_xn, tt);
                MessageBox.Show("Đã đóng thành công!");
                LoadList();
            }
        }
    }
}
