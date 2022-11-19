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
    public partial class frmCustomerReport : Form
    {
        public frmCustomerReport()
        {
            InitializeComponent();
        }

        private void frmCustomerReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLPT.ThongTinKhach' table. You can move, or remove it, as needed.
            this.ThongTinKhachTableAdapter.Fill(this.QLPT.ThongTinKhach);

            this.reportViewer1.RefreshReport();
        }
    }
}
