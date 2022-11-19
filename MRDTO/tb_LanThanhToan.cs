using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDTO
{
    public class tb_LanThanhToan
    {
        public int IdLanThanhToan { get; set; }
        public int id_ThanhToan_KhachTro { get; set; }

        public int id_ThanhToan_HoaDon { get; set; }
        public decimal SoTienTra { get; set; }

        public DateTime NgayThanhToan { get; set; }
        public string MaLanThanhToan { get; set; }
        public tb_LanThanhToan(int id_ThanhToan_KhachTro, int id_ThanhToan_HoaDon,
            decimal SoTienTra, DateTime NgayThanhToan)
        {
          
            this.id_ThanhToan_KhachTro = id_ThanhToan_KhachTro;
            this.id_ThanhToan_HoaDon = id_ThanhToan_HoaDon;
            this.SoTienTra = SoTienTra;
            this.NgayThanhToan = NgayThanhToan;
      
        }
    }
}
