namespace MotelRoomManagement
{
    partial class frmCustomerReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ThongTinKhachBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLPT = new MotelRoomManagement.QLPT();
            this.ThongTinKhachTableAdapter = new MotelRoomManagement.QLPTTableAdapters.ThongTinKhachTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ThongTinKhachBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLPT)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.ThongTinKhachBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MotelRoomManagement.KhachTroReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(904, 562);
            this.reportViewer1.TabIndex = 0;
            // 
            // ThongTinKhachBindingSource
            // 
            this.ThongTinKhachBindingSource.DataMember = "ThongTinKhach";
            this.ThongTinKhachBindingSource.DataSource = this.QLPT;
            // 
            // QLPT
            // 
            this.QLPT.DataSetName = "QLPT";
            this.QLPT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ThongTinKhachTableAdapter
            // 
            this.ThongTinKhachTableAdapter.ClearBeforeFill = true;
            // 
            // frmCustomerReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(904, 562);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "frmCustomerReport";
            this.Text = "frmCustomerReport";
            this.Load += new System.EventHandler(this.frmCustomerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ThongTinKhachBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLPT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ThongTinKhachBindingSource;
        private QLPT QLPT;
        private QLPTTableAdapters.ThongTinKhachTableAdapter ThongTinKhachTableAdapter;
    }
}