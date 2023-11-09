using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web_API.Data;
using Web_API.Models;

namespace Web_API.Service
{
    public class LoaiRepository : ILoaiRepository
    {
        private readonly MyDbContext _context;
        public LoaiRepository(MyDbContext context)
        {
            _context = context;
        }
        public LoaiVM Add(LoaiModel loai)
        {
            var _loai = new Loai
            {
                TenLoai = loai.TenLoai,
            }; // tạo đối tượng 

            _context.Add(_loai);

            _context.SaveChanges();

            return new LoaiVM
            {
                MaLoai = _loai.MaLoai,
                TenLoai = _loai.TenLoai
            };

        }

        public void Delete(int id)
        {
            var _loai = _context.Loais.SingleOrDefault(loai => loai.MaLoai == id);
            if (_loai != null)
            {
                _context.Loais.Remove(_loai);

            }
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _context.Loais.Select(loai => new LoaiVM
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai,
            }); // lấy ra danh sách các loại có các trường dữ liệu trên
            return loais.ToList();
        }

        public LoaiVM GetById(int id)
        {
            var loaiID = _context.Loais.SingleOrDefault(loai => loai.MaLoai == id);
            // trả về 1 đối tg nếu có
            if (loaiID != null)
            {
                return new LoaiVM
                {
                    MaLoai = loaiID.MaLoai,
                    TenLoai = loaiID.TenLoai,
                };
            }

            return null;
        }

        public void Update(LoaiVM loai)
        {
            var _loai = _context.Loais.SingleOrDefault(loai => loai.MaLoai == loai.MaLoai);
            if (_loai != null)
            {
                // đã tồn tại thì update
                _loai.TenLoai = loai.TenLoai;
                _context.SaveChanges();

            }

        }
    }
}
