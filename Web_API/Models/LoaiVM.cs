using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Models
{
    public class LoaiVM
    { // lớp này dùng cho đối tượng trả về cho người dùng 
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
    }
}
