using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Data
{  
    
    [Table("HangHoa")]

    public class HangHoa
    {
      
        [Key]
        public Guid MaHH { get; set; }

        [Required(ErrorMessage ="Tên không trống")]
        [MaxLength(100)]
        public string TenHH { get; set; }
        public string MoTa { get; set; }

        [Range(0,double.MaxValue)]
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }

        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }
        // sử dụng giao diện ICollection thay vì List 
        // vì ICollection nó bao chứa List , linh hoạt trong chuyển đổi kiểu dl thuộc tính
        // ưa chuộng trong OOP
        //hg giải quyết chung chung, dễ dàng thay đổi 
        public HangHoa()
        {
            DonHangChiTiets = new HashSet<DonHangChiTiet>();// danh sách trống, chống trùng lặp phần tử
        }

    }
}
