using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Data
{
    public class DonHangChiTiet
    {
        public Guid MaHH { get; set; }
        public Guid MaDH { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }
        // relationShip
        public DonHang DonHang { get; set; }
        public HangHoa HangHoa{get;set;}

    }
}
