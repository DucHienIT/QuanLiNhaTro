using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRDTO
{
    public class tb_LoaiPhong
    {
        public int IdLoaiPhong { get; set; }
        public string LoaiPhong { get; set; }
        public string MaLoaiPhong { get; set; }
        public tb_LoaiPhong(int IdLoaiPhong, string LoaiPhong, string MaLoaiPhong)
        {
            this.IdLoaiPhong = IdLoaiPhong;
            this.LoaiPhong = LoaiPhong;
            this.MaLoaiPhong = MaLoaiPhong;
        }
    }
}
