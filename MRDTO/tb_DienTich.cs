using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDTO
{
    public class tb_DienTich
    {
        public int IdDienTich { get; set; }
        public float DienTich { get; set; }
        public string MaDienTich { get; set; }

        public tb_DienTich(int IdDienTich, float DienTich, string MaDienTich)
        {
            this.IdDienTich = IdDienTich;
            this.DienTich = DienTich;
            this.MaDienTich = MaDienTich;
        }
    }
}
