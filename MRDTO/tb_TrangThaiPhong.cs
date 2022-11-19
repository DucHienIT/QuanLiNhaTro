using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDTO
{
    public class tb_TrangThaiPhong
    {
        public int IdTrangThaiPhong { get; set; }
        public string TrangThaiPhong { get; set; }
        public string MaTrangThaiPhong { get; set; }

        public tb_TrangThaiPhong(int IdTrangThaiPhong, string TrangThaiPhong, string MaTrangThaiPhong)
        {
            this.IdTrangThaiPhong = IdTrangThaiPhong;
            this.TrangThaiPhong = TrangThaiPhong;
            this.MaTrangThaiPhong = MaTrangThaiPhong;
        }
    }
}
