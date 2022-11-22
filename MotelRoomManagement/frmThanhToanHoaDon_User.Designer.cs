namespace MotelRoomManagement
{
    partial class frmThanhToanHoaDon_User
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
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listHoaDon = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbTienPhong = new System.Windows.Forms.Label();
            this.lbLoaiphong = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.lbTienDien = new System.Windows.Forms.Label();
            this.lbDienSK = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbNuocSK = new System.Windows.Forms.Label();
            this.lbTienNuoc = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbTT = new System.Windows.Forms.Label();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grCTHD = new System.Windows.Forms.GroupBox();
            this.lbTT2 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grDSTT = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbTienConLai = new System.Windows.Forms.Label();
            this.lbTCL = new System.Windows.Forms.Label();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.grCTHD.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grDSTT.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 4;
            this.columnHeader2.Text = "Kì hạn thanh toán";
            this.columnHeader2.Width = 208;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tổng tiền";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 143;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ngày xuất hóa đơn";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 188;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "MãHD";
            this.columnHeader3.Width = 66;
            // 
            // listHoaDon
            // 
            this.listHoaDon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader4});
            this.listHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listHoaDon.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listHoaDon.FullRowSelect = true;
            this.listHoaDon.GridLines = true;
            this.listHoaDon.HideSelection = false;
            this.listHoaDon.Location = new System.Drawing.Point(4, 33);
            this.listHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.listHoaDon.Name = "listHoaDon";
            this.listHoaDon.Size = new System.Drawing.Size(929, 451);
            this.listHoaDon.TabIndex = 2;
            this.listHoaDon.UseCompatibleStateImageBehavior = false;
            this.listHoaDon.View = System.Windows.Forms.View.Details;
            this.listHoaDon.Click += new System.EventHandler(this.listHoaDon_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 3;
            this.columnHeader1.Text = "Trạng thái";
            this.columnHeader1.Width = 148;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.listHoaDon);
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.ForestGreen;
            this.groupBox6.Location = new System.Drawing.Point(10, 25);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(937, 488);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Hóa đơn";
            // 
            // lbTienPhong
            // 
            this.lbTienPhong.AutoSize = true;
            this.lbTienPhong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTienPhong.ForeColor = System.Drawing.Color.Black;
            this.lbTienPhong.Location = new System.Drawing.Point(132, 65);
            this.lbTienPhong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTienPhong.Name = "lbTienPhong";
            this.lbTienPhong.Size = new System.Drawing.Size(0, 21);
            this.lbTienPhong.TabIndex = 1;
            // 
            // lbLoaiphong
            // 
            this.lbLoaiphong.AutoSize = true;
            this.lbLoaiphong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoaiphong.ForeColor = System.Drawing.Color.Black;
            this.lbLoaiphong.Location = new System.Drawing.Point(132, 28);
            this.lbLoaiphong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLoaiphong.Name = "lbLoaiphong";
            this.lbLoaiphong.Size = new System.Drawing.Size(0, 21);
            this.lbLoaiphong.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(10, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giá tiền:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Loại phòng: ";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lbTienPhong);
            this.groupBox8.Controls.Add(this.lbLoaiphong);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox8.Location = new System.Drawing.Point(14, 37);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox8.Size = new System.Drawing.Size(417, 95);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Phòng";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.lbTienDien);
            this.groupBox9.Controls.Add(this.lbDienSK);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox9.Location = new System.Drawing.Point(14, 140);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox9.Size = new System.Drawing.Size(417, 86);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Điện";
            // 
            // lbTienDien
            // 
            this.lbTienDien.AutoSize = true;
            this.lbTienDien.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTienDien.ForeColor = System.Drawing.Color.Black;
            this.lbTienDien.Location = new System.Drawing.Point(323, 48);
            this.lbTienDien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTienDien.Name = "lbTienDien";
            this.lbTienDien.Size = new System.Drawing.Size(0, 21);
            this.lbTienDien.TabIndex = 1;
            // 
            // lbDienSK
            // 
            this.lbDienSK.AutoSize = true;
            this.lbDienSK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDienSK.ForeColor = System.Drawing.Color.Black;
            this.lbDienSK.Location = new System.Drawing.Point(87, 48);
            this.lbDienSK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDienSK.Name = "lbDienSK";
            this.lbDienSK.Size = new System.Drawing.Size(0, 21);
            this.lbDienSK.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Số kí:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(182, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "Thành tiền: ";
            // 
            // lbNuocSK
            // 
            this.lbNuocSK.AutoSize = true;
            this.lbNuocSK.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNuocSK.ForeColor = System.Drawing.Color.Black;
            this.lbNuocSK.Location = new System.Drawing.Point(124, 48);
            this.lbNuocSK.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbNuocSK.Name = "lbNuocSK";
            this.lbNuocSK.Size = new System.Drawing.Size(0, 21);
            this.lbNuocSK.TabIndex = 1;
            // 
            // lbTienNuoc
            // 
            this.lbTienNuoc.AutoSize = true;
            this.lbTienNuoc.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTienNuoc.ForeColor = System.Drawing.Color.Black;
            this.lbTienNuoc.Location = new System.Drawing.Point(324, 48);
            this.lbTienNuoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTienNuoc.Name = "lbTienNuoc";
            this.lbTienNuoc.Size = new System.Drawing.Size(0, 21);
            this.lbTienNuoc.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(10, 38);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "Số khối:";
            // 
            // lbTT
            // 
            this.lbTT.AutoSize = true;
            this.lbTT.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTT.ForeColor = System.Drawing.Color.Black;
            this.lbTT.Location = new System.Drawing.Point(160, 479);
            this.lbTT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTT.Name = "lbTT";
            this.lbTT.Size = new System.Drawing.Size(0, 29);
            this.lbTT.TabIndex = 4;
            // 
            // line1
            // 
            this.line1.Location = new System.Drawing.Point(8, 325);
            this.line1.Margin = new System.Windows.Forms.Padding(4);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(416, 12);
            this.line1.TabIndex = 3;
            this.line1.Text = "line1";
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.ForeColor = System.Drawing.Color.Red;
            this.lbTongTien.Location = new System.Drawing.Point(17, 338);
            this.lbTongTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(129, 29);
            this.lbTongTien.TabIndex = 2;
            this.lbTongTien.Text = "Tổng tiền: ";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.lbTienNuoc);
            this.groupBox10.Controls.Add(this.label8);
            this.groupBox10.Controls.Add(this.lbNuocSK);
            this.groupBox10.Controls.Add(this.label9);
            this.groupBox10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox10.Location = new System.Drawing.Point(14, 234);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox10.Size = new System.Drawing.Size(417, 83);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Nước";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(183, 38);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "Thành tiền: ";
            // 
            // grCTHD
            // 
            this.grCTHD.Controls.Add(this.lbTCL);
            this.grCTHD.Controls.Add(this.lbTienConLai);
            this.grCTHD.Controls.Add(this.lbTT2);
            this.grCTHD.Controls.Add(this.lbTT);
            this.grCTHD.Controls.Add(this.line1);
            this.grCTHD.Controls.Add(this.lbTongTien);
            this.grCTHD.Controls.Add(this.groupBox10);
            this.grCTHD.Controls.Add(this.groupBox9);
            this.grCTHD.Controls.Add(this.groupBox8);
            this.grCTHD.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grCTHD.ForeColor = System.Drawing.Color.DodgerBlue;
            this.grCTHD.Location = new System.Drawing.Point(955, 58);
            this.grCTHD.Margin = new System.Windows.Forms.Padding(4);
            this.grCTHD.Name = "grCTHD";
            this.grCTHD.Padding = new System.Windows.Forms.Padding(4);
            this.grCTHD.Size = new System.Drawing.Size(431, 416);
            this.grCTHD.TabIndex = 5;
            this.grCTHD.TabStop = false;
            this.grCTHD.Text = "Chi tiết hóa đơn số:";
            // 
            // lbTT2
            // 
            this.lbTT2.AutoSize = true;
            this.lbTT2.Location = new System.Drawing.Point(183, 341);
            this.lbTT2.Name = "lbTT2";
            this.lbTT2.Size = new System.Drawing.Size(0, 29);
            this.lbTT2.TabIndex = 5;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonX1.Location = new System.Drawing.Point(31, 35);
            this.buttonX1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(188, 74);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.Symbol = "";
            this.buttonX1.TabIndex = 0;
            this.buttonX1.Text = "Đã đóng";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonX1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(23, 530);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(254, 117);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xác nhận đóng tiền";
            // 
            // grDSTT
            // 
            this.grDSTT.CanvasColor = System.Drawing.SystemColors.Control;
            this.grDSTT.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.grDSTT.Controls.Add(this.panel1);
            this.grDSTT.DisabledBackColor = System.Drawing.Color.Empty;
            this.grDSTT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grDSTT.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDSTT.Location = new System.Drawing.Point(0, 0);
            this.grDSTT.Margin = new System.Windows.Forms.Padding(4);
            this.grDSTT.Name = "grDSTT";
            this.grDSTT.Size = new System.Drawing.Size(1396, 706);
            // 
            // 
            // 
            this.grDSTT.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.grDSTT.Style.BackColorGradientAngle = 90;
            this.grDSTT.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.grDSTT.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grDSTT.Style.BorderBottomWidth = 1;
            this.grDSTT.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.grDSTT.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grDSTT.Style.BorderLeftWidth = 1;
            this.grDSTT.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grDSTT.Style.BorderRightWidth = 1;
            this.grDSTT.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.grDSTT.Style.BorderTopWidth = 1;
            this.grDSTT.Style.CornerDiameter = 4;
            this.grDSTT.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.grDSTT.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.grDSTT.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.grDSTT.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.grDSTT.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.grDSTT.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.grDSTT.TabIndex = 1;
            this.grDSTT.Text = "Thanh toán hóa đơn";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.grCTHD);
            this.panel1.Controls.Add(this.groupBox6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1390, 800);
            this.panel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(963, 481);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(170, 28);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Đóng một phần";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(963, 523);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(374, 116);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhập số tiền đóng";
            this.groupBox2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 50);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(328, 49);
            this.textBox1.TabIndex = 0;
            // 
            // lbTienConLai
            // 
            this.lbTienConLai.AutoSize = true;
            this.lbTienConLai.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTienConLai.ForeColor = System.Drawing.Color.Red;
            this.lbTienConLai.Location = new System.Drawing.Point(17, 383);
            this.lbTienConLai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTienConLai.Name = "lbTienConLai";
            this.lbTienConLai.Size = new System.Drawing.Size(150, 29);
            this.lbTienConLai.TabIndex = 6;
            this.lbTienConLai.Text = "Tiền còn lại: ";
            // 
            // lbTCL
            // 
            this.lbTCL.AutoSize = true;
            this.lbTCL.Location = new System.Drawing.Point(178, 383);
            this.lbTCL.Name = "lbTCL";
            this.lbTCL.Size = new System.Drawing.Size(0, 29);
            this.lbTCL.TabIndex = 7;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số tiền còn lại";
            this.columnHeader4.Width = 168;
            // 
            // frmThanhToanHoaDon_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 706);
            this.Controls.Add(this.grDSTT);
            this.Name = "frmThanhToanHoaDon_User";
            this.Text = "frmThanhToanHoaDon_User";
            this.Load += new System.EventHandler(this.frmThanhToanHoaDon_User_Load);
            this.groupBox6.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.grCTHD.ResumeLayout(false);
            this.grCTHD.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.grDSTT.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listHoaDon;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lbTienPhong;
        private System.Windows.Forms.Label lbLoaiphong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label lbTienDien;
        private System.Windows.Forms.Label lbDienSK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbNuocSK;
        private System.Windows.Forms.Label lbTienNuoc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbTT;
        private DevComponents.DotNetBar.Controls.Line line1;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grCTHD;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.GroupPanel grDSTT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lbTT2;
        private System.Windows.Forms.Label lbTCL;
        private System.Windows.Forms.Label lbTienConLai;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}