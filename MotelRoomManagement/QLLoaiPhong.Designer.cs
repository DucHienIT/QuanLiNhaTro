namespace MotelRoomManagement
{
    partial class QLLoaiPhong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.txtDienTich = new System.Windows.Forms.TextBox();
            this.txtLoaiPhong = new System.Windows.Forms.TextBox();
            this.txtMaDonGia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvQLLP = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbDienTich = new System.Windows.Forms.ComboBox();
            this.cbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.txtNhapGia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnHuy = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLLP)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 614);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnXoa);
            this.groupBox3.Controls.Add(this.btnSua);
            this.groupBox3.Controls.Add(this.btnThem);
            this.groupBox3.ForeColor = System.Drawing.Color.Blue;
            this.groupBox3.Location = new System.Drawing.Point(509, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(459, 81);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức năng:";
            // 
            // btnXoa
            // 
            this.btnXoa.ForeColor = System.Drawing.Color.Black;
            this.btnXoa.Location = new System.Drawing.Point(302, 26);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(98, 35);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.ForeColor = System.Drawing.Color.Black;
            this.btnSua.Location = new System.Drawing.Point(179, 26);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(98, 35);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.ForeColor = System.Drawing.Color.Black;
            this.btnThem.Location = new System.Drawing.Point(56, 26);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(98, 35);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGia);
            this.groupBox2.Controls.Add(this.txtDienTich);
            this.groupBox2.Controls.Add(this.txtLoaiPhong);
            this.groupBox2.Controls.Add(this.txtMaDonGia);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(509, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(459, 234);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin đơn giá";
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(179, 181);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(221, 32);
            this.txtGia.TabIndex = 3;
            this.txtGia.Click += new System.EventHandler(this.txtGia_Click);
            this.txtGia.TextChanged += new System.EventHandler(this.txtGia_TextChanged);
            // 
            // txtDienTich
            // 
            this.txtDienTich.Enabled = false;
            this.txtDienTich.Location = new System.Drawing.Point(179, 135);
            this.txtDienTich.Name = "txtDienTich";
            this.txtDienTich.Size = new System.Drawing.Size(221, 32);
            this.txtDienTich.TabIndex = 2;
            // 
            // txtLoaiPhong
            // 
            this.txtLoaiPhong.Enabled = false;
            this.txtLoaiPhong.Location = new System.Drawing.Point(179, 89);
            this.txtLoaiPhong.Name = "txtLoaiPhong";
            this.txtLoaiPhong.Size = new System.Drawing.Size(221, 32);
            this.txtLoaiPhong.TabIndex = 1;
            // 
            // txtMaDonGia
            // 
            this.txtMaDonGia.Enabled = false;
            this.txtMaDonGia.Location = new System.Drawing.Point(179, 43);
            this.txtMaDonGia.Name = "txtMaDonGia";
            this.txtMaDonGia.Size = new System.Drawing.Size(221, 32);
            this.txtMaDonGia.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(15, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Giá:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(15, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Diện tích (m2):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Loại phòng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đơn giá:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvQLLP);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 614);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách đơn giá phòng";
            // 
            // dgvQLLP
            // 
            this.dgvQLLP.AllowUserToAddRows = false;
            this.dgvQLLP.AllowUserToDeleteRows = false;
            this.dgvQLLP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQLLP.BackgroundColor = System.Drawing.Color.White;
            this.dgvQLLP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQLLP.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvQLLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQLLP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvQLLP.Location = new System.Drawing.Point(3, 28);
            this.dgvQLLP.Name = "dgvQLLP";
            this.dgvQLLP.ReadOnly = true;
            this.dgvQLLP.RowHeadersWidth = 51;
            this.dgvQLLP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQLLP.Size = new System.Drawing.Size(497, 583);
            this.dgvQLLP.TabIndex = 0;
            this.dgvQLLP.SelectionChanged += new System.EventHandler(this.dgvQLLP_SelectionChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbDienTich);
            this.groupBox4.Controls.Add(this.cbLoaiPhong);
            this.groupBox4.Controls.Add(this.txtNhapGia);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.btnLuu);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.btnHuy);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(509, 358);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(447, 253);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Nhập liệu";
            this.groupBox4.Visible = false;
            // 
            // cbDienTich
            // 
            this.cbDienTich.FormattingEnabled = true;
            this.cbDienTich.Location = new System.Drawing.Point(179, 85);
            this.cbDienTich.Name = "cbDienTich";
            this.cbDienTich.Size = new System.Drawing.Size(221, 32);
            this.cbDienTich.TabIndex = 8;
            // 
            // cbLoaiPhong
            // 
            this.cbLoaiPhong.FormattingEnabled = true;
            this.cbLoaiPhong.Location = new System.Drawing.Point(179, 39);
            this.cbLoaiPhong.Name = "cbLoaiPhong";
            this.cbLoaiPhong.Size = new System.Drawing.Size(221, 32);
            this.cbLoaiPhong.TabIndex = 7;
            this.cbLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cbLoaiPhong_SelectedIndexChanged);
            // 
            // txtNhapGia
            // 
            this.txtNhapGia.Location = new System.Drawing.Point(179, 131);
            this.txtNhapGia.Name = "txtNhapGia";
            this.txtNhapGia.Size = new System.Drawing.Size(221, 32);
            this.txtNhapGia.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(15, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Giá:";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(19, 175);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(126, 61);
            this.btnLuu.TabIndex = 0;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(15, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 24);
            this.label6.TabIndex = 5;
            this.label6.Text = "Diện tích (m2):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(15, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 24);
            this.label7.TabIndex = 6;
            this.label7.Text = "Loại phòng:";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(296, 175);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(126, 61);
            this.btnHuy.TabIndex = 1;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // QLLoaiPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(995, 638);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QLLoaiPhong";
            this.Text = "QLLoaiPhong";
            this.Load += new System.EventHandler(this.QLLoaiPhong_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLLP)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvQLLP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.TextBox txtDienTich;
        private System.Windows.Forms.TextBox txtLoaiPhong;
        private System.Windows.Forms.TextBox txtMaDonGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbDienTich;
        private System.Windows.Forms.ComboBox cbLoaiPhong;
        private System.Windows.Forms.TextBox txtNhapGia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnHuy;
    }
}