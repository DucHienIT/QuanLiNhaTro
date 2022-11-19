using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDTO
{
    public class tb_Phong
    {
        public int IdPhong { get; set; }
        public string TenPhong { get; set; }
        public int id_Phong_TrangThaiPhong { get; set; }
        public int id_Phong_DonGia { get; set; }
        public string LoaiPhong { get; set; }
        public tb_Phong(int IdPhong, string TenPhong, int id_Phong_TrangThaiPhong, int id_Phong_DonGia, string LoaiPhong)
        {
            this.IdPhong = IdPhong;
            this.TenPhong = TenPhong;
            this.id_Phong_TrangThaiPhong = id_Phong_TrangThaiPhong;
            this.id_Phong_DonGia = id_Phong_DonGia;
            this.LoaiPhong = LoaiPhong;
        }
    }
}
