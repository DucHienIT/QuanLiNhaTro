using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MRBUS;
using MRDTO;
using System.Collections;

namespace MotelRoomManagement
{
    public partial class QLLoaiPhong : Form
    {
        int request;
        string madongia;
        public QLLoaiPhong()
        {
            InitializeComponent();
        }

        private void QLLoaiPhong_Load(object sender, EventArgs e)
        {
            Load_datagrid();
            loadComboBox();
        }

        private void Load_datagrid()
        {
            dgvQLLP.Rows.Clear();

            dgvQLLP.ColumnCount = 4;
            dgvQLLP.Columns[0].Name = "Mã Đơn Giá";
            dgvQLLP.Columns[1].Name = "Loại Phòng";
            dgvQLLP.Columns[2].Name = "Diện tích";
            dgvQLLP.Columns[3].Name = "Giá";

            string sql = "select dg.MaDonGiaPhong, lp.LoaiPhong, dt.DienTich, dg.DonGia from tb_DonGiaPhong dg, tb_DienTich dt, tb_LoaiPhong lp where dg.id_DonGia_DienTich = dt.IdDienTich and dg.id_DonGia_LoaiPhong = lp.IdLoaiPhong";
            var dsphong = new Room().GetDataPhong(sql);

            for (int i = 0; i < dsphong.Rows.Count; i++)
            {
                ArrayList row = new ArrayList();
                row.Add(dsphong.Rows[i][0].ToString());
                row.Add(dsphong.Rows[i][1].ToString());
                row.Add(dsphong.Rows[i][2].ToString());
                row.Add(string.Format("{0:#,##0}", Int32.Parse(dsphong.Rows[i][3].ToString().TrimEnd())));
                dgvQLLP.Rows.Add(row.ToArray());
            }
        }

        void loadComboBox()
        {
            string sql = "select * from tb_LoaiPhong";
            var dsphong = new Room().GetDataPhong(sql);
            for (int i = 0; i < dsphong.Rows.Count; i++)
            {
                cbLoaiPhong.Items.Add(dsphong.Rows[i][1].ToString());
            }


            string sql2 = "select * from tb_DienTich";
            var dsDienTich = new Room().GetDataPhong(sql2);
            for (int i = 0; i < dsDienTich.Rows.Count; i++)
            {
                cbDienTich.Items.Add(dsDienTich.Rows[i][1].ToString());
            }
        }

        private void dgvQLLP_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvQLLP.SelectedCells.Count > 0)
            {
                int index = dgvQLLP.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dgvQLLP.Rows[index];
                madongia = Convert.ToString(selectedrow.Cells["Mã Đơn Giá"].Value);

                var data = new Room().GetDataPhong("select dg.MaDonGiaPhong, lp.LoaiPhong, dt.DienTich, dg.DonGia from tb_DonGiaPhong dg, tb_DienTich dt, tb_LoaiPhong lp where dg.id_DonGia_DienTich = dt.IdDienTich and dg.id_DonGia_LoaiPhong = lp.IdLoaiPhong and dg.MaDonGiaPhong = N'" + madongia + "'");
                txtMaDonGia.Text = data.Rows[0][0].ToString();
                txtLoaiPhong.Text = data.Rows[0][1].ToString();
                txtDienTich.Text = data.Rows[0][2].ToString();
                txtGia.Text = string.Format("{0:#,##0}", Int32.Parse(data.Rows[0][3].ToString().TrimEnd()));  
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;

        }


        private void btnLuu_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Bạn có muốn thêm đơn giá mới?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string dongia = txtNhapGia.Text;
                    string dienTich = cbDienTich.Items[int.Parse(cbDienTich.SelectedIndex.ToString())].ToString();
                    string LoaiPhong = cbLoaiPhong.Items[int.Parse(cbLoaiPhong.SelectedIndex.ToString())].ToString();

                    string sql = "select IdLoaiPhong from tb_LoaiPhong where LoaiPhong = N'" + LoaiPhong + "'";
                    var loaiPhong = new Room().GetDataPhong(sql);
                    int idloaiPhong = int.Parse(loaiPhong.Rows[0][0].ToString());

                    string sql2 = "select IdDienTich from tb_DienTich where DienTich = " + dienTich;
                    var dt = new Room().GetDataPhong(sql2);
                    int idDienTich = int.Parse(dt.Rows[0][0].ToString());

                    string sql3 = "INSERT INTO tb_DonGiaPhong (DonGia, id_DonGia_DienTich, id_DonGia_LoaiPhong) VALUES(" + dongia + ", " + idDienTich + ", " + idloaiPhong + ")";

                    var i = new Room().GetDataPhong(sql3);
                    MessageBox.Show("Thêm thành công đơn giá mới");
                    groupBox4.Visible = false;
                    groupBox2.Visible = true;
                    groupBox3.Visible = true;
                    Load_datagrid();

                }

            }
            catch
            {
                MessageBox.Show("Vui lòng nhập thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn sửa đơn giá: " + txtMaDonGia.Text + " ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sql = "UPDATE tb_DonGiaPhong SET DonGia = " + txtGia.Text + " WHERE tb_DonGiaPhong.MaDonGiaPhong = N'" + txtMaDonGia.Text + "'";
                    var dsPhong = new Room().GetDataPhong(sql);
                    MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_datagrid();
                }
            }
            catch
            {
                MessageBox.Show("Nhập đúng đơn giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa đơn giá: "+txtMaDonGia.Text+" ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "select p.IdPhong from tb_DonGiaPhong dg, tb_Phong p where p.id_Phong_DonGia = dg.IdDonGiaPhong and dg.MaDonGiaPhong = N'" + txtMaDonGia.Text +"'";

                var dsPhong = new Room().GetDataPhong(sql);
                if (dsPhong.Rows.Count > 0)
                {
                    MessageBox.Show("Không thể xóa đơn giá do đơn giá đang được dùng", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string lenh = "DELETE FROM tb_DonGiaPhong WHERE tb_DonGiaPhong.MaDonGiaPhong = N'" + txtMaDonGia.Text + "'";
                    int i = new PhongBUS().XoaLoaiPhong(lenh);
                    MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_datagrid();
                }

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Load_datagrid();
            groupBox4.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = true;
        }

        private void cbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtGia_Click(object sender, EventArgs e)
        {
            txtGia.Text = "";
        }
    }
}
