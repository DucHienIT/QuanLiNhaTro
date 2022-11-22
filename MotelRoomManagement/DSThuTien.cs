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
            LoadHoaDonThanhToanDuHoacQuaHan();
        }
      
        private void LoadList()
        {
            string sql = "select * from vw_ThongTinHoaDon where IdHoaDon in (select IdHoaDon from tb_HoaDon where TrangThaiHoaDon = 1 Or TrangThaiHoaDon = 2) And GETDATE() >= NgayXuatHoaDon And GETDATE() <= KiHanThanhToan";
            Room ListLoai = new Room();
            var loaiphong = ListLoai.GetDataPhong(sql);
            for (int i = 0; i < loaiphong.Rows.Count; i++)
            {
                //mặc định subitem đầu tiền là cột truyền vào constructor
                ListViewItem item = new ListViewItem(loaiphong.Rows[i][1].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][2].ToString().TrimEnd());
                item.SubItems.Add(string.Format("{0:#,##0}",Int32.Parse(loaiphong.Rows[i][7].ToString().TrimEnd())));
                item.SubItems.Add(loaiphong.Rows[i][3].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][4].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][9].ToString().TrimEnd());
                listHoaDon.Items.Add(item);
            }
           
        }

        private void LoadHoaDonThanhToanDuHoacQuaHan()
        {
            string sql = "select * from vw_ThongTinHoaDon where IdHoaDon in (select IdHoaDon from tb_HoaDon where TrangThaiHoaDon = 3 Or TrangThaiHoaDon = 4 Or(TrangThaiHoaDon In(1,2) And GETDATE() < NgayXuatHoaDon Or GETDATE() > KiHanThanhToan))";
            Room ListLoai = new Room();
            var loaiphong = ListLoai.GetDataPhong(sql);
            for (int i = 0; i < loaiphong.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(loaiphong.Rows[i][0].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][2].ToString().TrimEnd());
                item.SubItems.Add(string.Format("{0:#,##0}", Int32.Parse(loaiphong.Rows[i][7].ToString().TrimEnd())));
                item.SubItems.Add(loaiphong.Rows[i][3].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][4].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][9].ToString().TrimEnd());
                lvHoaDonThanhToanDu.Items.Add(item);
            }
        }       

        private void LoadLanThanhToanHoaDon(int idHoaDon)
        {
            lvLanThanhToan.Items.Clear();
            string sql = "Select v.IdLanThanhToan, v.NgayThanhToan, v.SoTienTra,v.NguoiThanhToan, v.HoTen From vw_ThongTinThanhToan v Where v.IdHoaDon = " + idHoaDon + " Order By v.NgayThanhToan Desc";
            HoadonBUS  hoadonBUS = new HoadonBUS();
            DataTable tb_LanThanhToan = hoadonBUS.GetInfo(sql);
            for (int i = 0; i < tb_LanThanhToan.Rows.Count; i++)
            {
                //mặc định subitem đầu tiền là cột truyền vào constructor
                if(tb_LanThanhToan.Rows[i][3].ToString() != "" && tb_LanThanhToan.Rows[i][4].ToString() != "")
                {
                    ListViewItem item = new ListViewItem("ltt" + tb_LanThanhToan.Rows[i][0].ToString());
                    item.SubItems.Add(tb_LanThanhToan.Rows[i][1].ToString());
                    item.SubItems.Add(string.Format("{0:#,##0}", Int32.Parse(tb_LanThanhToan.Rows[i][2].ToString().TrimEnd())));
                    item.SubItems.Add(tb_LanThanhToan.Rows[i][3].ToString().TrimEnd());
                    item.SubItems.Add(tb_LanThanhToan.Rows[i][4].ToString().TrimEnd());
                    lvLanThanhToan.Items.Add(item);
                }
                else {
                    MessageBox.Show("Hóa đơn được thanh toán bởi khách đã rời đi nên lần thanh toán không có thông tin khách","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    ListViewItem item = new ListViewItem("ltt" + tb_LanThanhToan.Rows[i][0].ToString());
                    item.SubItems.Add(tb_LanThanhToan.Rows[i][1].ToString());
                    item.SubItems.Add(string.Format("{0:#,##0}", Int32.Parse(tb_LanThanhToan.Rows[i][2].ToString().TrimEnd())));
                    lvLanThanhToan.Items.Add(item);
                }
            }
        }

        private void listHoaDon_Click(object sender, EventArgs e)
        {
            grCTHD.Visible = true;
            groupBox1.Visible = true; ;
            ListViewItem item = listHoaDon.SelectedItems[0];            
            string mahoadon = item.Text;
            maphong = "p" + item.SubItems[1].Text;
            string sql = "SELECT hd.IdHoaDon,lp.LoaiPhong, dg.DonGia, hd.SoDien, hd.SoNuoc, hd.SoTienConLaiPhaiThanhToan, p.IdPhong,hd.TongTienPhaiThanhToan FROM tb_HoaDon hd, tb_DonGiaPhong dg, tb_Phong p, tb_LoaiPhong lp WHERE hd.MaHoaDon = N'" + mahoadon + "' AND p.IdPhong = hd.id_HoaDon_Phong AND p.id_Phong_DonGia = dg.IdDonGiaPhong AND lp.IdLoaiPhong = dg.id_DonGia_LoaiPhong ";
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
                lbTTCon.Text = string.Format("{0:#,##0}",Int32.Parse(table.Rows[i][5].ToString().TrimEnd())) + " vnd";
                lbTT.Text = string.Format("{0:#,##0}", Int32.Parse(table.Rows[i][7].ToString().TrimEnd())) + " vnd";
            }
            idhoadon = Convert.ToInt32(table.Rows[0][0].ToString());
            idPhong = Convert.ToInt32(table.Rows[0][6].ToString());
            tienTra = Convert.ToDecimal(table.Rows[0][5].ToString());
            LoadLanThanhToanHoaDon(idhoadon);
        }

        private void lvHoaDonThanhToanDu_Click(object sender, EventArgs e)
        {
            grCTHD.Visible = false;
            groupBox1.Visible = false;
            ListViewItem item = lvHoaDonThanhToanDu.SelectedItems[0];
            int idHoaDonThanhToanDu = Convert.ToInt32(item.Text);
            LoadLanThanhToanHoaDon(idHoaDonThanhToanDu);
        }

        //xóa 2 view đi và tạo lại 
        //thay đổi: thay vì đóng toàn bộ tổng số tiền thì sẽ đóng số tiền còn lại vì 
        //hóa đơn có thể đã được thanh toán trước đo
        //nên nếu đóng toàn bộ tiền thì sẽ bị vi phạm trigger trả dư tiền
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
                    lvHoaDonThanhToanDu.Items.Clear();
                    LoadList();
                    LoadHoaDonThanhToanDuHoacQuaHan();
                    resetTextLabels();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
        }

        private void resetTextLabels()
        {
            grCTHD.Text = "Chi tiết hóa đơn số: ";
            lbLoaiphong.Text = "";
            lbTienPhong.Text = "";
            lbDienSK.Text = "";
            lbTienDien.Text = "";
            lbNuocSK.Text = "";
            lbTienNuoc.Text = "";
            lbTTCon.Text = "";
            lbTT.Text = "";
        }
    }
}
