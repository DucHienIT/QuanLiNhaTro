using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using MRBUS;
using MRDTO;

namespace MotelRoomManagement
{
    public partial class TrangThai : UserControl
    {
        public TrangThai()
        {
            InitializeComponent();
        }

   

        private void TrangThai_Load(object sender, EventArgs e)
        {
            Load_Data_TreeView1();
            Load_Data_TreeView2();
            Load_Data_TreeView3();


        }

        //Load du lieu
        private void cbKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Room _CbData = new Room();
                var phongtrong = _CbData.GetDataTWChild("Vacant");
                var phongdathue = _CbData.GetDataTWChild("NoVacant");
            }
            catch
            {

            }
           
        }

        private void Load_Data_TreeView1()
        {
            try
            {
                Room _TW = new Room();
                treeView1.ImageList = TwImgList;
                DataTable tb_NoVacantRooms = _TW.GetDataTWChild("NoVacant");
                int noVacantRoomsCount = tb_NoVacantRooms.Rows.Count;
                numRent.Text = noVacantRoomsCount.ToString();

                for (int j = 0; j < noVacantRoomsCount; j++)
                {
                    TreeNode nodecon = treeView1.Nodes.Add(tb_NoVacantRooms.Rows[j][1].ToString());
                    treeView1.Nodes[j].Tag = "1";
                    treeView1.Nodes[j].Name = tb_NoVacantRooms.Rows[j][0].ToString();
                    nodecon.ImageIndex = 1;
                    nodecon.SelectedImageIndex = 1;
                }

            }
            catch
            {

            }



        }
        private void Load_Data_TreeView3()
        {
            try
            {
                Room _TW = new Room();
                treeView3.ImageList = TwImgList;
                DataTable tb_FullRooms = _TW.GetDataTWChild("Full");
                int fullRoomsCount = tb_FullRooms.Rows.Count;
                numDay.Text = fullRoomsCount.ToString();


                for (int j = 0; j < fullRoomsCount; j++)
                {
                    TreeNode nodecon = treeView3.Nodes.Add(tb_FullRooms.Rows[j][1].ToString());
                    treeView3.Nodes[j].Tag = "1";
                    treeView3.Nodes[j].Name = tb_FullRooms.Rows[j][0].ToString();
                    nodecon.ImageIndex = 1;
                    nodecon.SelectedImageIndex = 1;
                }
            }
            catch
            {

            }



        }
        private void Load_Data_TreeView2()
        {
            try
            {
                Room _TW = new Room();
                treeView2.ImageList = TwImgList;
                DataTable tb_VacantRooms = _TW.GetDataTWChild("Vacant");
                int vacantRoomsCount = tb_VacantRooms.Rows.Count;
                numTrong.Text = vacantRoomsCount.ToString();

                for (int j = 0; j < vacantRoomsCount; j++)
                {
                    TreeNode nodecon = treeView2.Nodes.Add(tb_VacantRooms.Rows[j][1].ToString());
                    treeView2.Nodes[j].Tag = "1";
                    treeView2.Nodes[j].Name = tb_VacantRooms.Rows[j][0].ToString();
                    nodecon.ImageIndex = 1;
                    nodecon.SelectedImageIndex = 1;
                }
            }
            catch
            {

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            try
            {
                listKhach.Items.Clear();
                TreeNode theNode = treeView1.SelectedNode;
                KhachTroBUS _ListKT = new KhachTroBUS();
                if (theNode.Tag.ToString() == "1")
                {
                    panel2.Visible = false;
                    string node = theNode.Name.ToString();

                    var list_khach = _ListKT.GetKhach(node);

                    for (int i = 0; i < list_khach.Rows.Count; i++)
                    {

                        ListViewItem item = new ListViewItem(list_khach.Rows[i][0].ToString());
                        item.ImageIndex = 3;
                        item.SubItems.Add(list_khach.Rows[i][1].ToString());
                        item.SubItems.Add(list_khach.Rows[i][2].ToString());
                        item.SubItems.Add(list_khach.Rows[i][3].ToString());
                        item.SubItems.Add(list_khach.Rows[i][4].ToString());
                        item.SubItems.Add(list_khach.Rows[i][5].ToString());
                        item.SubItems.Add(list_khach.Rows[i][6].ToString());
                        item.SubItems.Add(list_khach.Rows[i][7].ToString());
                        listKhach.Items.Add(item);
                    }
                }
            }
            catch
            {

            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                listKhach.Items.Clear();

                Room p = new Room();
                TreeNode theNode = this.treeView2.SelectedNode;
                string dkphong = theNode.Name.ToString();
                var ttp = p.GetDataPhong("SELECT MaPhong, LoaiPhong, DienTich, DonGia FROM tb_Phong, tb_DonGiaPhong, tb_DienTich, tb_LoaiPhong WHERE tb_Phong.MaPhong= N'" + dkphong + "' AND tb_Phong.id_Phong_DonGia = tb_DonGiaPhong.IdDonGiaPhong AND tb_DonGiaPhong.id_DonGia_DienTich = tb_DienTich.IdDienTich AND tb_DonGiaPhong.id_DonGia_LoaiPhong = tb_LoaiPhong.IdLoaiPhong");


                if (theNode.Tag.ToString() == "1")
                {
                    label1.Text = dkphong;
                    lbLoaiPhong.Text = ttp.Rows[0][1].ToString();
                    lbDienTich.Text = ttp.Rows[0][2].ToString();
                    lbgia.Text = ttp.Rows[0][3].ToString();
                    panel2.Visible = true;
                }
            }
            catch
            {

            }
        }

       

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                treeView1.Nodes.Clear();
                treeView2.Nodes.Clear();
                listKhach.Items.Clear();
                Load_Data_TreeView1();
                Load_Data_TreeView2();
                panel2.Visible = false;
            }
            catch
            {

            }
        }

        private void treeView3_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listKhach.Items.Clear();
            TreeNode theNode = treeView3.SelectedNode;
            KhachTroBUS _ListKT = new KhachTroBUS();
            if (theNode.Tag.ToString() == "1")
            {
                panel2.Visible = false;
                string node = theNode.Name.ToString();

                var list_khach = _ListKT.GetKhach(node);

                for (int i = 0; i < list_khach.Rows.Count; i++)
                {

                    ListViewItem item = new ListViewItem(list_khach.Rows[i][0].ToString());
                    item.ImageIndex = 3;
                    item.SubItems.Add(list_khach.Rows[i][1].ToString());
                    item.SubItems.Add(list_khach.Rows[i][2].ToString());
                    item.SubItems.Add(list_khach.Rows[i][3].ToString());
                    item.SubItems.Add(list_khach.Rows[i][4].ToString());
                    item.SubItems.Add(list_khach.Rows[i][5].ToString());
                    item.SubItems.Add(list_khach.Rows[i][6].ToString());
                    item.SubItems.Add(list_khach.Rows[i][7].ToString());
                    listKhach.Items.Add(item);
                }
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
