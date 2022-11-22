using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

using MRBUS;

namespace MotelRoomManagement
{
    public partial class FrmGeneral : DevComponents.DotNetBar.RibbonForm
    {
        private string USER, PASS;
        public FrmGeneral()
        {
            InitializeComponent();
        }
        public FrmGeneral(string username, string password): this()
        {
            USER = username;
            PASS = password;
        }
     
    
        private void FrmGeneral_Load(object sender, EventArgs e)
        {
           
            TabTrangThai();
        }

        //Load Side Bar


        private void TabTrangThai()
        {
            //Khoi tao 
            TrangThai ucTrangThai = new TrangThai();
            TabControlPanel newTabPanel = new DevComponents.DotNetBar.TabControlPanel();
            TabItem newTabPage = new TabItem(this.components);
            newTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            newTabPanel.Location = new System.Drawing.Point(0, 26);
            newTabPanel.Name = "panel TrangThaiThue";
            newTabPanel.Padding = new System.Windows.Forms.Padding(1);
            newTabPanel.Size = new System.Drawing.Size(1230, 384);
            newTabPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            newTabPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            newTabPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            newTabPanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            newTabPanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            newTabPanel.Style.GradientAngle = 90;
            newTabPanel.TabIndex = 2;
            newTabPanel.TabItem = newTabPage;
            
            //-------------Them tab page---------------------
            Random ran = new Random();
            newTabPage.Name = "TrangThaiThue" + ran.Next(100000) + ran.Next(22342);
            newTabPage.AttachedControl = newTabPanel;
            newTabPage.Text = "Trạng thái thuê";
            ucTrangThai.Dock = DockStyle.Fill;
            newTabPanel.Controls.Add(ucTrangThai);
            //------------Them Tab page vao Tab control-------------
            tabMain.Controls.Add(newTabPanel);
            tabMain.Tabs.Add(newTabPage);
            tabMain.SelectedTab = newTabPage;
            newTabPage.ImageIndex = 1;
            newTabPage.CloseButtonVisible = false;
            
        }

        //Ham thoat
        public void CloseThis()
        {
            TabItem selectedTab = tabMain.SelectedTab;
            if (MessageBox.Show("Bạn có muốn tắt trang: \"" + selectedTab.Text + "\"?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
               if(tabMain.SelectedTabIndex!=0)
                tabMain.Tabs.Remove(selectedTab);
        }

   
     

        // chuột phải đóng trang
        private void tabMain_TabItemClose(object sender, TabStripActionEventArgs e)
        {
            CloseThis();
        }

        private void ctmCloseThis_Click(object sender, EventArgs e)
        {
            CloseThis();
        }

        private void ctmRM_Opening(object sender, CancelEventArgs e)
        {
            bool isShow = (tabMain.SelectedTabIndex == 0) ? false : true;
            ctmCloseThis.Enabled = isShow;
        }

        private void ctmCloseOthers_Click(object sender, EventArgs e)
        {
            int index = tabMain.SelectedTabIndex;
            for (int i = tabMain.Tabs.Count - 1; i > 0; i--)
                if (index != i)
                    tabMain.Tabs.RemoveAt(i);
            tabMain.Refresh();
        }

        private void ctmCloseAll_Click(object sender, EventArgs e)
        {
            int index = tabMain.SelectedTabIndex;
            for (int i = tabMain.Tabs.Count - 1; i > 0; i--)
                tabMain.Tabs.RemoveAt(i);
            tabMain.Refresh();
        }

        // Ham Add-Tab
        public void addNewTab(string strTabName, UserControl ucContent,int imgindex)
        {
            //-----------If exist tabpage then exit---------------
            foreach (TabItem tabPage in tabMain.Tabs)
                if (tabPage.Text == strTabName)
                {
                    tabMain.SelectedTab = tabPage;
                    return;
                }
            //-------------------------Clear Tab Before---------------
            //if (tabMain.Tabs.Count > 1)
            //    tabMain.Tabs.RemoveAt(1);

            TabControlPanel newTabPanel = new DevComponents.DotNetBar.TabControlPanel();
            TabItem newTabPage = new TabItem(this.components);
            //newTabPage.MouseDown += new System.Windows.Forms.MouseEventHandler(tabItem_MouseDown);
            newTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            newTabPanel.Location = new System.Drawing.Point(0, 26);
            newTabPanel.Name = "panel" + strTabName;
            newTabPanel.Padding = new System.Windows.Forms.Padding(1);
            newTabPanel.Size = new System.Drawing.Size(1230, 384);
            newTabPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            newTabPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            newTabPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            newTabPanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            newTabPanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            newTabPanel.Style.GradientAngle = 90;
            newTabPanel.TabIndex = 2;
            newTabPanel.TabItem = newTabPage;
            //-------------New  tab page---------------------
            Random ran = new Random();
            newTabPage.Name = strTabName + ran.Next(100000) + ran.Next(22342);
            newTabPage.AttachedControl = newTabPanel;
            newTabPage.Text = strTabName;
            ucContent.Dock = DockStyle.Fill;
            newTabPanel.Controls.Add(ucContent);
            //------------add Tab page to Tab control-------------
            tabMain.Controls.Add(newTabPanel);
            tabMain.Tabs.Add(newTabPage);
            tabMain.SelectedTab = newTabPage;
            newTabPage.ImageIndex = imgindex;
        }

        //Xu li Menu Button
        private void btnDSTT_Click(object sender, EventArgs e)
        {
            DSThuTien dstt = new DSThuTien();
            addNewTab("Danh sách thu tiền", dstt,0);
        }

        private void btnTrangThai_Click(object sender, EventArgs e)
        {
            TrangThai uc = new TrangThai();
            addNewTab("Trạng thái thuê", uc,1);
        }

 

        private void btnThemNguoi_Click(object sender, EventArgs e)
        {
            ThemNguoi uc = new ThemNguoi();
            addNewTab("Thêm người", uc, 5);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

      

        private void FrmGeneral_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                e.Cancel = true;
        }
        private void buttonItem21_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Updating...");
        }
          
        

       

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //AccountInformation frm = new AccountInformation(USER, PASS);
            //frm.Show();
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            //AccountInformation frm = new AccountInformation(USER, PASS);
            //frm.Show();
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            frmCustomerReport frm = new frmCustomerReport();
            frm.Show();
        }

        private void buttonItem35_Click(object sender, EventArgs e)
        {
            TinhTienThang uc = new TinhTienThang();
            addNewTab("Tính tiền phòng", uc, 2);
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            DoanhThu uc = new DoanhThu();
            addNewTab("Doanh thu", uc, 6);
        }

        private void btnTraPhong_Click(object sender, EventArgs e)
        {
            TraPhong uc = new TraPhong();
            addNewTab("Trả phòng", uc, 4);
        }

        private void buttonItem16_Click(object sender, EventArgs e)
        {
            QuanLiPhong uc = new QuanLiPhong();
            addNewTab("Quản lí phòng", uc, 8);
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Updating...");
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            QLLoaiPhong form = new QLLoaiPhong();
            form.Show();
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Updating...");
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Updating...");
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Updating...");
        }

        private void buttonItem31_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Updating...");
        }

       

        

        private void btnDSKhach_Click(object sender, EventArgs e)
        {
            QuanLiKhach uc = new QuanLiKhach();
            addNewTab("Quản lí khách trọ", uc, 7);
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("updating...");
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            MessageBox.Show("updating...");
        }

        private void btnDKP_Click(object sender, EventArgs e)
        {
            SapPhong uc = new SapPhong();
            addNewTab("Đăng kí phòng", uc, 3);
        }

        private void ribbonPanel2_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            frmNo frm = new frmNo();
            frm.Show();
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            //ThemTK frm = new ThemTK();
            //frm.Show();
        }
    }
}