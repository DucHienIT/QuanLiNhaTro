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
    public partial class DSThuTien : UserControl
    {
        string maphong;
        int idhoadon, idPhong;
        decimal tienTra;
        public DSThuTien()
        {
            InitializeComponent();
        }

        private void DSThuTien_Load(object sender, EventArgs e)
        {
            LoadList();
        }
      
        private void LoadList()
        {

            
            string sql = "select * from vw_ThongTinHoaDon where IdHoaDon in (select IdHoaDon from tb_HoaDon where TrangThaiHoaDon = 1)";
            Room ListLoai = new Room();
            var loaiphong = ListLoai.GetDataPhong(sql);
            for (int i = 0; i < loaiphong.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(loaiphong.Rows[i][1].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][2].ToString().TrimEnd());
                item.SubItems.Add(string.Format("{0:#,##0}",Int32.Parse(loaiphong.Rows[i][7].ToString().TrimEnd())));
                item.SubItems.Add(loaiphong.Rows[i][3].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][4].ToString().TrimEnd());
                listHoaDon.Items.Add(item);
            }
           
        }
        private void listHoaDon_Click(object sender, EventArgs e)
        {
            ListViewItem item = listHoaDon.SelectedItems[0];
            string thang = item.Text;
            maphong = thang;
            string sql = "SELECT hd.IdHoaDon,lp.LoaiPhong, dg.DonGia, hd.SoDien, hd.SoNuoc, hd.TongTienPhaiThanhToan, p.IdPhong FROM tb_HoaDon hd, tb_DonGiaPhong dg, tb_Phong p, tb_LoaiPhong lp WHERE hd.MaHoaDon = N'" + thang + "' AND p.IdPhong = hd.id_HoaDon_Phong AND p.id_Phong_DonGia = dg.IdDonGiaPhong AND lp.IdLoaiPhong = dg.id_DonGia_LoaiPhong ";
            DataTable table = new Room().GetDataPhong(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                grCTHD.Text = "Chi tiết hóa đơn số: " + table.Rows[i][0].ToString().TrimEnd();
                lbLoaiphong.Text = table.Rows[i][1].ToString().TrimEnd();
                lbTienPhong.Text = string.Format("{0:#,##0}",Int32.Parse(table.Rows[i][2].ToString().TrimEnd()));
                lbDienSK.Text = table.Rows[i][3].ToString().TrimEnd();
                lbTienDien.Text = string.Format("{0:#,##0}",Int32.Parse(lbDienSK.Text)*2500);
                lbNuocSK.Text = table.Rows[i][4].ToString().TrimEnd();
                lbTienNuoc.Text = string.Format("{0:#,##0}",Int32.Parse(lbNuocSK.Text)*5000);
                lbTT.Text = string.Format("{0:#,##0}",Int32.Parse(table.Rows[i][5].ToString().TrimEnd())) + " vnd";
            }
            idhoadon = Convert.ToInt32(table.Rows[0][0].ToString());
            idPhong = Convert.ToInt32(table.Rows[0][6].ToString());
            tienTra = Convert.ToDecimal(table.Rows[0][5].ToString());
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string ngaythu = DateTime.Today.ToShortDateString();
            if (MessageBox.Show("Thời gian thu: " + ngaythu.ToString() + "\nMã Phòng: " + maphong, "Xác nhận thanh toán hóa đơn: "+idhoadon, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    string sql = "SELECT tb_KhachTro.IdKhachTro from tb_KhachTro where tb_KhachTro.id_KhachTro_Phong = " + idPhong;
                    DataTable table = new Room().GetDataPhong(sql);
                    int idKhachThanhToan = int.Parse(table.Rows[0][0].ToString());

                    tb_LanThanhToan tt = new tb_LanThanhToan(idKhachThanhToan, idhoadon, tienTra, DateTime.Today);

                    string sql_xn = "Exec proc_ThanhToanHoaDon @id_ThanhToan_KhachTro, @id_ThanhToan_HoaDon, @SoTienTra, @NgayThanhToan";
                    int i = new LanThanhToanBUS().Insert(sql_xn, tt);

                    MessageBox.Show("Đã đóng thành công!");
                    listHoaDon.Items.Clear();
                    LoadList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
        }
    }
}
