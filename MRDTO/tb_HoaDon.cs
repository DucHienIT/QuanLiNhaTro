using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDTO
{
    public class tb_HoaDon
    {
        public int IdHoaDon { get; set; }
        public int id_HoaDon_Phong { get; set; }

        public DateTime NgayXuatHoaDon { get; set; }
        public DateTime KiHanThanhToan { get; set; }
        public int SoDien { get; set; }
        public int SoNuoc { get; set; }
        public decimal SoTienConLaiPhaiThanhToan { get; set; }
        public decimal TongTienPhaiThanhToan { get; set; }
        public string MaHoaDon { get; set; }
        public int TrangThaiHoaDon { get; set; }
        public tb_HoaDon(int id_HoaDon_Phong, DateTime NgayXuatHoaDon,
            DateTime KiHanThanhToan, int SoDien, int SoNuoc, decimal SoTienConLaiPhaiThanhToan,
            decimal TongTienPhaiThanhToan, int TrangThaiHoaDon)
        {
            this.id_HoaDon_Phong = id_HoaDon_Phong;
            this.NgayXuatHoaDon = NgayXuatHoaDon;
            this.KiHanThanhToan = KiHanThanhToan;
            this.SoDien = SoDien;
            this.SoNuoc = SoNuoc;
            this.SoTienConLaiPhaiThanhToan = SoTienConLaiPhaiThanhToan;
            this.TongTienPhaiThanhToan = TongTienPhaiThanhToan;
            this.TrangThaiHoaDon = TrangThaiHoaDon;
        }
    }
}
