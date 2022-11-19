using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRDTO
{
    public class tb_ThongTinNo
    {
        public int IdThongTinNo { get; set; }
        public decimal SoTienNo { get; set; }
        public int id_ThongTinNo_Phong { get; set; }
        public string MaThongTinNo { get; set; }
        public tb_ThongTinNo(int id_ThongTinNo_Phong, decimal SoTienNo)
        {
          
            this.SoTienNo = SoTienNo;
            this.id_ThongTinNo_Phong = id_ThongTinNo_Phong;
        }
    }
}
