namespace MotelRoomManagement
{
    partial class QLKhachTro_User
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listKhach = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listKhach
            // 
            this.listKhach.BackColor = System.Drawing.Color.LightBlue;
            this.listKhach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listKhach.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader9,
            this.columnHeader8,
            this.columnHeader5});
            this.listKhach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listKhach.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listKhach.FullRowSelect = true;
            this.listKhach.GridLines = true;
            this.listKhach.HideSelection = false;
            this.listKhach.Location = new System.Drawing.Point(0, 0);
            this.listKhach.Margin = new System.Windows.Forms.Padding(4);
            this.listKhach.MultiSelect = false;
            this.listKhach.Name = "listKhach";
            this.listKhach.Size = new System.Drawing.Size(947, 529);
            this.listKhach.TabIndex = 1;
            this.listKhach.UseCompatibleStateImageBehavior = false;
            this.listKhach.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã khách";
            this.columnHeader1.Width = 99;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CCCD";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Họ và tên";
            this.columnHeader2.Width = 127;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số điện thoại";
            this.columnHeader4.Width = 129;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Năm sinh";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Quê quán";
            this.columnHeader9.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Nghề nghiệp";
            this.columnHeader8.Width = 136;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Mã phòng";
            this.columnHeader5.Width = 110;
            // 
            // QLKhachTro_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listKhach);
            this.Name = "QLKhachTro_User";
            this.Size = new System.Drawing.Size(947, 529);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listKhach;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
