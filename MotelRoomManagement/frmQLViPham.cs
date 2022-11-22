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
    public partial class frmQLViPham : Form
    {
        public frmQLViPham()
        {
            InitializeComponent();
        }

        private void loadPhongThanhToanThieuSauThangGanNhat()
        {
            dgPhongThanhToanThieuSauThangGanNhat.Rows.Clear();
            dgPhongThanhToanThieuSauThangGanNhat.ColumnCount = 4;
            dgPhongThanhToanThieuSauThangGanNhat.Columns[0].Name = "Id Phòng";
            dgPhongThanhToanThieuSauThangGanNhat.Columns[1].Name = "Mã Phòng";
            dgPhongThanhToanThieuSauThangGanNhat.Columns[2].Name = "Tên Phòng";
            dgPhongThanhToanThieuSauThangGanNhat.Columns[3].Name = "Trạng thái Phòng";

            //chỉ load các phòng không có khách trọ -> khi trả phòng hoặc đuổi khách phải set các hóa đơn có trạng thái khác 4 hiện tại = 4
            string sql = "Select * From tb_Phong p Where dbo.func_SoLanThanhToanThieuSauThang(p.IdPhong) > 3 And p.id_Phong_TrangThaiPhong In(2,3)";
            var dsphong = new Room().GetDataPhong(sql);

            for (int i = 0; i < dsphong.Rows.Count; i++)
            {
                ArrayList row = new ArrayList();
                row.Add(dsphong.Rows[i][0].ToString());
                row.Add(dsphong.Rows[i][4].ToString());
                row.Add(dsphong.Rows[i][1].ToString());
                string trangThaiPhong = dsphong.Rows[i][2].ToString();
                if (trangThaiPhong == "1")
                    row.Add("Trống");
                else if (trangThaiPhong == "2")
                    row.Add("Có người ở");
                else if (trangThaiPhong == "3")
                    row.Add("Đầy");
                dgPhongThanhToanThieuSauThangGanNhat.Rows.Add(row.ToArray());
            }
        }

        private void loadPhongNoHonBaTrieu()
        {
            dgPhongNoHonBaTrieu.Rows.Clear();
            dgPhongNoHonBaTrieu.ColumnCount = 5;
            dgPhongNoHonBaTrieu.Columns[0].Name = "Id Phòng";
            dgPhongNoHonBaTrieu.Columns[1].Name = "Mã Phòng";
            dgPhongNoHonBaTrieu.Columns[2].Name = "Tên Phòng";
            dgPhongNoHonBaTrieu.Columns[3].Name = "Trạng thái Phòng";
            dgPhongNoHonBaTrieu.Columns[4].Name = "Nợ hiện tại";

            //chỉ load các phòng không có khách trọ vì khách trọ rời đi thì phòng đó đã phải hết nợ
            string sql = "Select *, dbo.func_NoPhong(p.IdPhong) 'Nợ' From tb_Phong p Where dbo.func_NoPhong(p.IdPhong) > 10000 And p.id_Phong_TrangThaiPhong In(2,3)";
            var dsphong = new Room().GetDataPhong(sql);

            for (int i = 0; i < dsphong.Rows.Count; i++)
            {
                ArrayList row = new ArrayList();
                row.Add(dsphong.Rows[i][0].ToString());
                row.Add(dsphong.Rows[i][4].ToString());
                row.Add(dsphong.Rows[i][1].ToString());
                string trangThaiPhong = dsphong.Rows[i][2].ToString();
                if (trangThaiPhong == "1")
                    row.Add("Trống");
                else if (trangThaiPhong == "2")
                    row.Add("Có người ở");
                else if (trangThaiPhong == "3")
                    row.Add("Đầy");
                row.Add(dsphong.Rows[i][5].ToString());
                dgPhongNoHonBaTrieu.Rows.Add(row.ToArray());
            }

        }

        private void reset()
        {
            btn_Duoi.Visible = false;
            btn_Duoi.Enabled = false;
            loadPhongThanhToanThieuSauThangGanNhat();
            loadPhongNoHonBaTrieu();
            if(dgPhongNoHonBaTrieu.Rows.Count > 0 || dgPhongThanhToanThieuSauThangGanNhat.Rows.Count > 0)
            {
                btn_Duoi.Visible = true;
                btn_Duoi.Enabled = true;
            }    
        }
        private void frmQLViPham_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void dgPhongThanhToanThieuSauThangGanNhat_SelectionChanged(object sender, EventArgs e)
        {
            if (dgPhongThanhToanThieuSauThangGanNhat.SelectedCells.Count > 0)
            {
                int index = dgPhongThanhToanThieuSauThangGanNhat.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgPhongThanhToanThieuSauThangGanNhat.Rows[index];
                int idPhong = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                loadCacHoaDonChuaThanhToanDuCuaPhongTrongSauThang(idPhong);
            }
        }

        private void loadCacHoaDonChuaThanhToanDuCuaPhongTrongSauThang(int idPhong)
        {
            dgHoaDonThanhToanThieuSauThangGanNhat.Rows.Clear();
            dgHoaDonThanhToanThieuSauThangGanNhat.ColumnCount = 5;
            dgHoaDonThanhToanThieuSauThangGanNhat.Columns[0].Name = "Id HĐ";
            dgHoaDonThanhToanThieuSauThangGanNhat.Columns[1].Name = "Ngày xuất HĐ";
            dgHoaDonThanhToanThieuSauThangGanNhat.Columns[2].Name = "Kì hạn";
            dgHoaDonThanhToanThieuSauThangGanNhat.Columns[3].Name = "Số tiền còn";
            dgHoaDonThanhToanThieuSauThangGanNhat.Columns[4].Name = "Tổng tiền cần TT";

            string sql = "Select * From tb_HoaDon hd Where DATEDIFF(month,hd.NgayXuatHoaDon,GETDATE()) <= 6 And hd.TrangThaiHoaDon = 2 And hd.id_HoaDon_Phong = 1 Order By hd.NgayXuatHoaDon Desc";
            var dsHoaDon = new HoadonBUS().GetInfo(sql);

            for (int i = 0; i < dsHoaDon.Rows.Count; i++)
            {
                ArrayList row = new ArrayList();
                row.Add(dsHoaDon.Rows[i][0].ToString());
                row.Add(dsHoaDon.Rows[i][2].ToString());
                row.Add(dsHoaDon.Rows[i][3].ToString());
                row.Add(dsHoaDon.Rows[i][6].ToString());
                row.Add(dsHoaDon.Rows[i][7].ToString());
                dgHoaDonThanhToanThieuSauThangGanNhat.Rows.Add(row.ToArray());
            }
        }

        private void btn_Duoi_Click(object sender, EventArgs e)
        {   if(MessageBox.Show("Bạn có muốn mời tất cả các khách thược phòng vi phạm rời phòng ", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //thực hiện thủ tục đuổi các khác vi phạm
                //thủ tục cần thay đổi trạng thái hóa đơn của phòng khác 4 thành 4
                try
                {
                    string sql = "Exec proc_DuoiKhachTroViPhamNoiQuy";
                    int result = new KhachTroBUS().ThucThiSql(sql);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                MessageBox.Show("Đã mời tất cả các khách thuộc các phòng vi phạm rời phòng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);           
                reset();
            }    
        }
    }
}
