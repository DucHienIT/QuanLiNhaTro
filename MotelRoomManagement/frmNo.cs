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

            string sql = "SELECT tb_Phong.MaPhong, tb_ThongTinNo.MaThongTinNo, tb_ThongTinNo.SoTienNo From tb_ThongTinNo, tb_Phong where tb_ThongTinNo.id_ThongTinNo_Phong = tb_Phong.IdPhong";
            var dsphong = new Room().GetDataPhong(sql);

            for (int i = 0; i < dsphong.Rows.Count; i++)
            {
                ArrayList row = new ArrayList();
                row.Add(dsphong.Rows[i][0].ToString());
                row.Add(dsphong.Rows[i][1].ToString());
                row.Add(dsphong.Rows[i][2].ToString());
                dgvQLLP.Rows.Add(row.ToArray());
            }

        }

        private void dgvQLLP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQLLP.SelectedCells.Count > 0)
            {
                int index = dgvQLLP.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dgvQLLP.Rows[index];
                maphong = Convert.ToString(selectedrow.Cells["Mã Phòng"].Value);

                var data = new Room().GetDataPhong("SELECT tb_Phong.MaPhong, tb_ThongTinNo.MaThongTinNo, tb_ThongTinNo.SoTienNo, tb_Phong.IdPhong From tb_ThongTinNo, tb_Phong where tb_ThongTinNo.id_ThongTinNo_Phong = tb_Phong.IdPhong AND tb_Phong.MaPhong = N'" + maphong + "'");
                txtMaPhong.Text = data.Rows[0][0].ToString();
                txtMaNo.Text = data.Rows[0][1].ToString();
                txtSoNo.Text = data.Rows[0][2].ToString();
                idPhong = int.Parse(data.Rows[0][3].ToString());
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtSoNo.Enabled = true;
            btnLuu.Visible = true; btnHuy.Visible = true;
            btnXoa.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Load_datagrid();
            btnLuu.Visible = false; btnHuy.Visible = false;
            txtSoNo.Enabled = false;
            btnSua.Enabled = true; btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "Exec proc_GanNoMoiHoacXoaNo 0, @id_ThongTinNo_Phong";
            decimal no = 0;

            int i = new ThongTinNoBUS().Insert(sql, new tb_ThongTinNo(idPhong, no));

            MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnXoa.Enabled = true;
            Load_datagrid();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "Exec proc_GanNoMoiHoacXoaNo @SoTienNo, @id_ThongTinNo_Phong";
            decimal no = Convert.ToDecimal(txtSoNo.Text);

            int i = new ThongTinNoBUS().Insert(sql, new tb_ThongTinNo(idPhong, no));

            MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnLuu.Visible = false;
            btnHuy.Visible = false;
            btnXoa.Enabled = true;
            Load_datagrid();
        }
    }
}
