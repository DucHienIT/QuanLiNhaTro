using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDTO
{
    public class tb_DonGiaPhong
    {
        public int IdDonGiaPhong { get; set; }
        public decimal DonGia { get; set; }
        public int id_DonGia_DienTich { get; set; }
        public int id_DonGia_LoaiPhong { get; set; }
        public string MaDonGiaPhong { get; set; }

        public tb_DonGiaPhong(int IdDonGiaPhong, decimal DonGia, int id_DonGia_DienTich, int id_DonGia_LoaiPhong, string MaDonGiaPhong)
        {
            this.IdDonGiaPhong = IdDonGiaPhong;
            this.DonGia = DonGia;
            this.id_DonGia_DienTich = id_DonGia_DienTich;
            this.id_DonGia_LoaiPhong = id_DonGia_LoaiPhong;
            this.MaDonGiaPhong = MaDonGiaPhong;
        }
    }
}
