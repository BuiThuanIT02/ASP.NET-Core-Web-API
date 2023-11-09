using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Data;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private readonly MyDbContext _context;// chỉ đọc 1 lần, tức gán 1 lần duy nhất không thay đổi

        public LoaiController(MyDbContext context)
        {// mỗi yêu cầu request qua HTTp thì hàm khởi tạo 1 lần
            _context = context;
        }
        [HttpGet]

        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }
        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(x => x.MaLoai == id);
            if(loai != null)
            {
                return Ok(loai);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Create(LoaiModel model)
        {
            try
            {
                var loai = new Loai
                {
                    TenLoai = model.TenLoai
                };
                _context.Loais.Add(loai);
                _context.SaveChanges();
                return Ok(loai);
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost("{id}")]

        public IActionResult UpdateById(int id, LoaiModel model)
        {
            var loai = _context.Loais.SingleOrDefault(x => x.MaLoai == id);
            if (loai != null)
            {
                loai.TenLoai = model.TenLoai;
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
           
                var model = _context.Loais.Find(id);
            if(model == null)
            {// không có đối tg loại
                return NotFound();
            }
            _context.Loais.Remove(model);
            _context.SaveChanges();
            return Ok();
            }
        }


    }

