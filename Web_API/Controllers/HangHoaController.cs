using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]")] // xác định đường dẫn Url , api/[controller]: chuỗi đg dẫn Controller sẽ là tên cụ thể của controller đc gọi 
    [ApiController]// đánh dấu xd đây là API controller, xử lý các yêu cầu HTTP và trả về dữ liệu dạng Json
    public class HangHoaController : ControllerBase
    {
        public static List<HangHoa> hanghoas = new List<HangHoa>();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(hanghoas);// dữ liệu đc chuyển về dạng Json

        }
        [HttpGet("{id}")]
        public IActionResult GetByID(string id)
        {
            try
            {
                var hanghoa = hanghoas.SingleOrDefault(x => x.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                return Ok(hanghoa);
            }
            catch
            {
                return BadRequest();
            }
          
            

        }





        [HttpPost]

        public IActionResult Create(HangHoaVM hanghoaVM)
        {
            var hanghoa = new HangHoa
            {
                MaHangHoa = Guid.NewGuid(), // tạo ID có tính duy nh
                TenHangHoa = hanghoaVM.TenHangHoa,
                DonGia = hanghoaVM.DonGia
            };
            hanghoas.Add(hanghoa);

            return Ok(new
            {
                Success = true,Data = hanghoa
            });

            
        }





        [HttpPut("{id}")]

        public IActionResult Edit(string id,HangHoa hanghoaEdit)
        {
            try
            {
                var hanghoa = hanghoas.SingleOrDefault(x => x.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                //update
                if(id != hanghoa.MaHangHoa.ToString())
                {
                    return BadRequest();

                }
             
                hanghoa.TenHangHoa = hanghoaEdit.TenHangHoa;
                hanghoa.DonGia = hanghoaEdit.DonGia;
                return Ok();
            }
            catch
            {
                return BadRequest();
            }




        }




        [HttpDelete("{id}")]

        public IActionResult Delete(string id)
        {
            try
            {
            // tôi mới thêm ở đây
                var hanghoa = hanghoas.SingleOrDefault(x => x.MaHangHoa == Guid.Parse(id));
                if (hanghoa == null)
                {
                    return NotFound();
                }
                //update

                hanghoas.Remove(hanghoa);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }






    }
}
