using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MRBUS;
using System.Data.SqlClient;
using MRDTO;

namespace MotelRoomManagement
{
    public partial class TraPhong : UserControl
    {
        int idPhong;
        public TraPhong()
        {
            InitializeComponent();
        }

        private void lvPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TraPhong_Load(object sender, EventArgs e)
        {
            Load_listPhong();
        }
        private void Load_listPhong()
        {
            lvPhong.Items.Clear();
            Room data = new Room();
            var sql = data.GetDataPhong("SELECT * FROM tb_Phong WHERE id_Phong_TrangThaiPhong <> 1");
            for (int i = 0; i < sql.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(sql.Rows[i][0].ToString());
                item.SubItems.Add(sql.Rows[i][4].ToString());
                item.SubItems.Add(sql.Rows[i][1].ToString());

                lvPhong.Items.Add(item);
            }
        }

        private void lvPhong_Click(object sender, EventArgs e)
        {
            lvKhach.Items.Clear();
            ListViewItem a = lvPhong.SelectedItems[0];
            string map = a.Text;

            string id;
            idPhong = int.Parse(map);
            //string map = lvPhong.SelectedItems[0].ToString().TrimEnd();
            string sqll = "SELECT * FROM tb_KhachTro WHERE id_KhachTro_Phong = " + map;
            KhachTroBUS data = new KhachTroBUS();
            DataTable sql = data.GetKhachTheoMaPhong(sqll);
            for (int i = 0; i < sql.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(sql.Rows[i][8].ToString());
                item.SubItems.Add(sql.Rows[i][2].ToString());
                item.SubItems.Add(sql.Rows[i][3].ToString());
                lvKhach.Items.Add(item);
            }


            id = sql.Rows[0][8].ToString();

        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            string lenh = "SELECT * FROM tb_HoaDon WHERE id_HoaDon_Phong = " + idPhong;
            HoadonBUS data = new HoadonBUS();
            DataTable bang = data.GetInfo(lenh);

            if (bang.Rows.Count > 0)
            {
                MessageBox.Show("Chưa thể trả phòng do còn hóa đơn chưa thanh toán");
            }
            else
            {
                string sql = "Exec proc_XoaCacKhachThuocPhong " + idPhong;
                int i = new HoadonBUS().XNDongTien2(sql);
                MessageBox.Show("Trả phòng thành công!!");
                Load_listPhong();

            }


        }
    }
}
