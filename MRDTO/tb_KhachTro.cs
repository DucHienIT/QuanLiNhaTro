using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDTO
{
    public class tb_KhachTro
    {
        public int IdKhachTro { get; set; }
        public string CCCD { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public int NamSinh { get; set; }
        public string QueQuan { get; set; }
        public string NgheNghiep { get; set; }
        public int id_KhachTro_Phong { get; set; }
        public string MaKhachTro { get; set; }
        public string TenDangNhap { get; set; }

        public tb_KhachTro(string CCCD, string HoTen, string SoDienThoai,
            int NamSinh, string QueQuan, string NgheNghiep, int id_KhachTro_Phong, string TenDangNhap)
        {
            this.CCCD = CCCD;
            this.HoTen = HoTen;
            this.SoDienThoai = SoDienThoai;
            this.NamSinh = NamSinh;
            this.QueQuan = QueQuan;
            this.NgheNghiep = NgheNghiep;
            this.id_KhachTro_Phong = id_KhachTro_Phong;
            this.TenDangNhap = TenDangNhap;
        }
    }
}
