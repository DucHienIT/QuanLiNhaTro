using MRBUS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotelRoomManagement
{
    public partial class frmQLNo_User : Form
    {
        int idPhong;
        public frmQLNo_User(int idPhong)
        {
            InitializeComponent();
            this.idPhong = idPhong;
        }


        private void Load_datagrid()
        {
            dgvQLLP.Rows.Clear();

            dgvQLLP.ColumnCount = 3;
            dgvQLLP.Columns[0].Name = "Mã Phòng";
            dgvQLLP.Columns[1].Name = "Mã Nợ";
            dgvQLLP.Columns[2].Name = "Tổng số nợ";

            string sql = "SELECT tb_Phong.MaPhong, tb_ThongTinNo.MaThongTinNo, tb_ThongTinNo.SoTienNo From tb_ThongTinNo, tb_Phong where tb_ThongTinNo.id_ThongTinNo_Phong = tb_Phong.IdPhong AND tb_Phong.IdPhong = " + idPhong;
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

        private void frmQLNo_User_Load(object sender, EventArgs e)
        {
            Load_datagrid();
        }
    }
}
