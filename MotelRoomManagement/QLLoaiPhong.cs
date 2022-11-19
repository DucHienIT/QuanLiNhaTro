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
                row.Add(dsphong.Rows[i][3].ToString());
                dgvQLLP.Rows.Add(row.ToArray());
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
                txtGia.Text = data.Rows[0][3].ToString();  
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           /* request = 1;
            //Enable + Clear
            txtMLP.Text = ""; txtTLP.Text = ""; txtDT.Text = ""; txtGia.Text = "";
            txtMLP.Enabled = true; txtTLP.Enabled = true; txtDT.Enabled = true; txtGia.Enabled = true;
            btnLuu.Visible = true; btnHuy.Visible = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;*/
            
        }

        private void disable_textbox()
        {
           /* txtMLP.Enabled = false; txtTLP.Enabled = false; txtDT.Enabled = false; txtGia.Enabled = false;*/
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            /*switch (request)
            {
                case 1:
                    {
                        
                        //Them Loai Phong
                        string sql = "INSERT INTO LoaiPhong (MaLoaiPhong,TenLoaiPhong,DienTichPhong,DonGia) VALUES(@maloaiphong,@tenloaiphong,@dientich,@gia)";
                        string maloaiphong = txtMLP.Text.ToString(),
                                tenloaiphong = txtTLP.Text.ToString();
                        double dientich = Convert.ToDouble(txtDT.Text),
                                gia = Convert.ToDouble(txtGia.Text);

                        int i = new PhongBUS().themloaiphong(sql,tenloaiphong);
                     
                            MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLuu.Visible = false; btnHuy.Visible = false;
                            btnSua.Enabled = true; btnXoa.Enabled = true;
                            disable_textbox();
                            Load_datagrid();
                       
                    }
                    break;
                case 2:
                    {
                       
                        //SuaLoaiPhong

                        string sql = "UPDATE LoaiPhong SET MaLoaiPhong=@maloaiphong, TenLoaiPhong=@tenloaiphong, DienTichPhong=@dientich,DonGia=@gia WHERE MaLoaiPhong='"+maloaiphong+"'";
                        string mlp = txtMLP.Text.ToString(),
                                tenloaiphong = txtTLP.Text.ToString();
                        double dientich = Convert.ToDouble(txtDT.Text),
                                gia = Convert.ToDouble(txtGia.Text);

                        int i = new PhongBUS().themloaiphong(sql,tenloaiphong);
                       
                            MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnLuu.Visible = false; btnHuy.Visible = false;
                            btnThem.Enabled = true; btnXoa.Enabled = true;
                            disable_textbox();
                            Load_datagrid();
                       
                    }
                    break;

                default:
                    break;
            }*/
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            /*request = 2;
            txtMLP.Enabled = true; txtTLP.Enabled = true; txtDT.Enabled = true; txtGia.Enabled = true;
            btnLuu.Visible = true; btnHuy.Visible = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;*/
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            /*if (MessageBox.Show("Bạn có muốn xóa loại phòng: "+txtTLP.Text+" ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "DELETE From LoaiPhong WHERE MaLoaiPhong='" + maloaiphong + "'";
                int i = new PhongBUS().XoaLoaiPhong(sql);
               
                    MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_datagrid();
                
            }*/
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            /*Load_datagrid();
            btnLuu.Visible = false; btnHuy.Visible = false;
            txtMLP.Enabled = false; txtTLP.Enabled = false; txtDT.Enabled = false; txtGia.Enabled = false;
            btnSua.Enabled = true; btnXoa.Enabled = true; btnThem.Enabled = true;*/
        }
    }
}
