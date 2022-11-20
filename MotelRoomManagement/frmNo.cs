using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MRBUS;
using MRDTO;
namespace MotelRoomManagement
{
    public partial class frmNo : Form
    {
        int request, idPhong;
        string maphong;
        int idKhachThanhToan, idHoaDonThanhToan;
        decimal soTienThanhToan, soNoHienTai, soNoCapNhat;
        DateTime ngayThanhToan;

        public frmNo()
        {
            InitializeComponent();
        }

        private void frmNo_Load(object sender, EventArgs e)
        {
            Load_datagrid();
        }

        private void Load_datagrid()
        {
            dgvQLLP.Rows.Clear();

            dgvQLLP.ColumnCount = 3;
            dgvQLLP.Columns[0].Name = "Mã Phòng";
            dgvQLLP.Columns[1].Name = "Mã Nợ";
            dgvQLLP.Columns[2].Name = "Tổng số nợ";

            string sql = "SELECT tb_Phong.MaPhong, tb_ThongTinNo.MaThongTinNo, tb_ThongTinNo.SoTienNo " +
                            "From tb_ThongTinNo, tb_Phong where tb_ThongTinNo.id_ThongTinNo_Phong = tb_Phong.IdPhong";
            var dsphong = new Room().GetDataPhong(sql);

            for (int i = 0; i < dsphong.Rows.Count; i++)
            {
                ArrayList row = new ArrayList();
                row.Add(dsphong.Rows[i][0].ToString());
                row.Add(dsphong.Rows[i][1].ToString());
                row.Add(string.Format("{0:#,##0}", Int32.Parse(dsphong.Rows[i][2].ToString().TrimEnd())));
                dgvQLLP.Rows.Add(row.ToArray());
            }

        }

        private void Load_dataHoaDonThanhToanDuoc(int idPhongNo)
        {
            dgHoaDonThanhToanDuoc.Rows.Clear();
            dgHoaDonThanhToanDuoc.ColumnCount = 9;
            dgHoaDonThanhToanDuoc.Columns[0].Name = "Mã hóa đơn";
            dgHoaDonThanhToanDuoc.Columns[1].Name = "Ngày xuất hóa đơn";
            dgHoaDonThanhToanDuoc.Columns[2].Name = "Kì hạn thanh toán";
            dgHoaDonThanhToanDuoc.Columns[3].Name = "Điện";
            dgHoaDonThanhToanDuoc.Columns[4].Name = "Nước";
            dgHoaDonThanhToanDuoc.Columns[5].Name = "Số tiền còn lại";
            dgHoaDonThanhToanDuoc.Columns[6].Name = "Tổng phải trả";
            dgHoaDonThanhToanDuoc.Columns[7].Name = "Trạng thái";
            dgHoaDonThanhToanDuoc.Columns[8].Name = "id phòng";


            HoadonBUS hoaDonBUS = new HoadonBUS();
            DataTable dataHoaDonThanhToanDuoc = hoaDonBUS.GetInfo("Select * From dbo.func_CacHoaDonThanhToanDuocCuaPhong(" + idPhong + ")");
            for (int i = 0; i < dataHoaDonThanhToanDuoc.Rows.Count; i++)
            {
                ArrayList row = new ArrayList();

                //lấy idPhong                 
                row.Add(dataHoaDonThanhToanDuoc.Rows[i][8].ToString().Trim());
                row.Add(dataHoaDonThanhToanDuoc.Rows[i][2].ToString());
                row.Add(dataHoaDonThanhToanDuoc.Rows[i][3].ToString());
                row.Add(dataHoaDonThanhToanDuoc.Rows[i][4].ToString());
                row.Add(dataHoaDonThanhToanDuoc.Rows[i][5].ToString());
                row.Add(string.Format("{0:#,##0}", Int32.Parse(dataHoaDonThanhToanDuoc.Rows[i][6].ToString().TrimEnd())));
                row.Add(string.Format("{0:#,##0}", Int32.Parse(dataHoaDonThanhToanDuoc.Rows[i][7].ToString().TrimEnd())));
                int trangThaiHoaDon = Convert.ToInt32(dataHoaDonThanhToanDuoc.Rows[i][9].ToString());
                if (trangThaiHoaDon == 1)
                    row.Add("Chưa hề thanh toán");
                else
                    row.Add("Chưa thanh toán đủ");
                row.Add(dataHoaDonThanhToanDuoc.Rows[i][1].ToString());
                dgHoaDonThanhToanDuoc.Rows.Add(row.ToArray());

                
            }
        }

        private void dgvQLLP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQLLP.SelectedCells.Count > 0)
            {
                int index = dgvQLLP.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dgvQLLP.Rows[index];
                maphong = Convert.ToString(selectedrow.Cells["Mã Phòng"].Value);

                var data = new Room().GetDataPhong("SELECT tb_Phong.MaPhong, tb_ThongTinNo.MaThongTinNo, tb_ThongTinNo.SoTienNo, tb_Phong.IdPhong From tb_ThongTinNo, tb_Phong " +
                    "where tb_ThongTinNo.id_ThongTinNo_Phong = tb_Phong.IdPhong AND tb_Phong.MaPhong = N'" + maphong + "'");
                txtMaPhong.Text = data.Rows[0][0].ToString();
                txtMaNo.Text = data.Rows[0][1].ToString();
                txtSoNo.Text = data.Rows[0][2].ToString();
                soNoHienTai = Convert.ToDecimal(txtSoNo.Text);
                txtSoNo.Text = string.Format("{0:#,##0}", Int32.Parse(data.Rows[0][2].ToString().TrimEnd()));
                idPhong = int.Parse(data.Rows[0][3].ToString());

                Load_dataHoaDonThanhToanDuoc(idPhong);
            }
        }

        private void dgHoaDonThanhToanDuoc_SelectionChanged(object sender, EventArgs e)
        {
            //chọn 1 cell thì coi như chọn row chứa cell đó
            if (dgHoaDonThanhToanDuoc.SelectedCells.Count > 0)
            {
                int index = dgHoaDonThanhToanDuoc.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgHoaDonThanhToanDuoc.Rows[index];
                idHoaDonThanhToan = Convert.ToInt32(selectedRow.Cells[0].Value.ToString().Trim().Substring(2));
                idPhong = Convert.ToInt32(selectedRow.Cells[8].Value.ToString());

                var data = new KhachTroBUS().GetKhachTheoMaPhong("Select Top(1) * From tb_KhachTro kt Where kt.id_KhachTro_Phong = '" + idPhong + "'");
                idKhachThanhToan = Convert.ToInt32(data.Rows[0][0].ToString());
                MessageBox.Show(idHoaDonThanhToan.ToString()  + " " +idKhachThanhToan.ToString());
                ngayThanhToan = DateTime.Now;
                idPhong = int.Parse(data.Rows[0][3].ToString());

                btn_Sua.Enabled = true;
                btn_Xoa.Enabled = true;

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {            
            txtSoNo.Enabled = true;
            btn_Luu.Visible = true; btn_Huy.Visible = true;
            btn_Xoa.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Load_datagrid();
            btn_Luu.Visible = false; btn_Huy.Visible = false;
            txtSoNo.Enabled = false;
            btn_Sua.Enabled = false; btn_Xoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "Exec dbo.proc_ThanhToanHoaDon @id_ThanhToan_KhachTro, @id_ThanhToan_HoaDon,@SoTienTra, @NgayThanhToan";
            soTienThanhToan = soNoHienTai;
            if (MessageBox.Show("Bạn có muốn xóa nợ(thanh toán hóa đơn này và toàn bộ nợ trước)","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try {
                    int i = new LanThanhToanBUS().Insert(sql, new tb_LanThanhToan(idKhachThanhToan, idHoaDonThanhToan, soTienThanhToan, ngayThanhToan));
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Đã xóa nợ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Luu.Visible = false;
                btn_Huy.Visible = false;
                btn_Xoa.Enabled = true;
                Load_datagrid();

            }
            else{
                btnHuy_Click(sender,e);
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            soNoCapNhat = Convert.ToDecimal(txtSoNo.Text);
            if(soNoCapNhat < soNoHienTai)
            {
                soTienThanhToan = soNoHienTai - soNoCapNhat;
                string sql = "Exec dbo.proc_ThanhToanHoaDon @id_ThanhToan_KhachTro, @id_ThanhToan_HoaDon,@SoTienTra, @NgayThanhToan";
                try
                {
                    int i = new LanThanhToanBUS().Insert(sql, new tb_LanThanhToan(idKhachThanhToan,idHoaDonThanhToan,soTienThanhToan,ngayThanhToan));

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Luu.Visible = false;
                btn_Huy.Visible = false;
                btn_Xoa.Enabled = true;
                Load_datagrid();

            }
            else if (soNoCapNhat == soNoHienTai)
            {
                MessageBox.Show("Không thể thanh toán 0 đồng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Không thể tự tiện thêm nợ","Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
