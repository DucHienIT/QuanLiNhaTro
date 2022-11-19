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
    public partial class frmLoginOption : Form
    {
        private string id, pass;

        public frmLoginOption()
        {
            InitializeComponent();
        }
        public frmLoginOption(string username, string Pass): this()
        {
            id = username;
            pass = Pass;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmLoginOption_Load(object sender, EventArgs e)
        {
            lbU.Text = id;
            string a = "";
            for (int i = 0; i < int.Parse(pass.Count().ToString()); i++)
                a += "*";
            lbP.Text = a;
        }

        private void btChangePass_Click(object sender, EventArgs e)
        {
           
        }
    }
}
