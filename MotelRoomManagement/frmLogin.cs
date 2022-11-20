using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using MRBUS;
using MRDTO;
using System.Collections;

namespace MotelRoomManagement
{
    public partial class frmLogin : Form
    {
        SqlConnection cn = new SqlConnection("Data Source = DUCTHINHPC;Initial Catalog = db_QuanLyPhongTro; Integrated Security = True");


        public frmLogin()
        {
            InitializeComponent();
        }

        public void Connect()
        {
            try
            {
                if (cn != null && cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void Disconnect()
        {
            if (cn != null && cn.State != ConnectionState.Closed)
                cn.Close();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
           
            try
            {
                Connect();
                //DataTable ds = ExecuteAdapter("Select * from tb_TaiKhoan Where TenDangNhap = N'" + txtLogin.Text + "' AND MatKhau = '" + txtPassword.Text + "'");
                //if (ds.Rows.Count == 1)
                if (txtLogin.Text == "admin" && txtPassword.Text == "admin") 
                {
                    MessageBox.Show("Đăng nhập thành công tài khoản người quản trị: " + txtLogin.Text);
                    FrmGeneral frmM = new FrmGeneral();
                    frmM.ShowDialog();
                }
                

                SqlCommand cmd = new SqlCommand("Select dbo.func_DangNhap('" + txtLogin.Text + "')", cn);
                cmd.CommandType = CommandType.Text;
                int idKhachTroDangNhap = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                if (idKhachTroDangNhap != 0)
                {
                    MessageBox.Show("Đăng nhập Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DangNhap(txtLogin.Text, txtPassword.Text);
                }
                else
                {
                    MessageBox.Show("Thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Disconnect();
            }
            catch
            {

            }
            

                
        }
        private void DangNhap(string username, string password)
        {
            frmGeneralUser U = new frmGeneralUser(username, password);
            U.Show();
        }
        public DataTable ExecuteAdapter(string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        private void btReset_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmLogin_Load_1(object sender, EventArgs e)
        {

        }
    }
}
