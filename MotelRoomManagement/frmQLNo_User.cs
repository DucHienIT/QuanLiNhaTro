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
        string connString;
        public frmQLNo_User(int idPhong, string connString)
        {
            InitializeComponent();
            this.idPhong = idPhong;
            this.connString = connString;
        }


        private void Load_datagrid()
        {
            dgvQLLP.Rows.Clear();

            dgvQLLP.ColumnCount = 3;
            dgvQLLP.Columns[0].Name = "Mã Phòng";
            dgvQLLP.Columns[1].Name = "Mã Nợ";
            dgvQLLP.Columns[2].Name = "Tổng số nợ";

            string sql = "Select Distinct vw.MaPhong,vw.MaThongTinNo,vw.SoTienNo From vw_ThongTinHoaDon vw Where vw.idPhong = " + idPhong;
            var dsphong = new Room(this.connString).GetDataPhongConnString(sql);

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
            dgvQLLP.MultiSelect = false;
        }

        private void dgvQLLP_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow currRow = dgvQLLP.CurrentRow;
                txtMaPhong.Text = currRow.Cells[0].Value.ToString();
                txtMaNo.Text = currRow.Cells[1].Value.ToString();
                txtSoNo.Text = currRow.Cells[2].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
