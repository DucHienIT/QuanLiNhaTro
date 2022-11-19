using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotelRoomManagement
{
    public partial class AccountInformation : Form
    {
        private string USER, PASS;
        public AccountInformation()
        {
            InitializeComponent();
        }
        public AccountInformation(string username, string password)
            : this()
        {
            USER = username;
            PASS = password;
        }

        private void AccountInformation_Load(object sender, EventArgs e)
        {
           /* label3.Text = USER;
            for (int i = 0; i < PASS.Length; i++)
                label5.Text += "*";
            label7.Text = "Đã kích hoạt";*/
        }
    }
}
