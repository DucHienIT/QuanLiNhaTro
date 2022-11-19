using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MRDTO;
using MRBUS;

namespace MotelRoomManagement
{
    public partial class frmAddRoom : Form
    {
        public frmAddRoom()
        {
            InitializeComponent();
        }

        private void frmAddRoom_Load(object sender, EventArgs e)
        {
            Load_ComboBox();
        }

        private void Load_ComboBox()
        {
            Room data = new Room();
            var lp = data.GetDataPhong("SELECT idDonGiaPhong, DonGia From tb_DonGiaPhong");
            cbDonGia.ValueMember = "idDonGiaPhong";
            cbDonGia.DisplayMember = "DonGia";
            cbDonGia.DataSource = lp;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO tb_Phong (TenPhong,id_Phong_TrangThaiPhong,id_Phong_DonGia) VALUES(@TenPhong,@id_Phong_TrangThaiPhong,@id_Phong_DonGia)";
            int id_Phong_TrangThaiPhong = Int32.Parse(cbTrangThai.SelectedIndex.ToString()) + 1;
            //MessageBox.Show(id_Phong_TrangThaiPhong.ToString());
            int id_Phong_DonGia = Int32.Parse(cbDonGia.SelectedValue.ToString());
            string TenPhong = txtTenPhong.Text.ToString();
            int i = new PhongBUS().themphong(sql, TenPhong, id_Phong_TrangThaiPhong, id_Phong_DonGia);
            if (i == 1)
            {
                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Không thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
