using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) {  }
        // kế thửa hàm khởi tạo cơ sở, liên quan tới chuỗi kết nối


        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        #endregion

        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {// xây dựng mô hình thực thể và cấu trúc quan hệ trong CSDL
            // ModelBuilder : API giúp cấu hình các mô hình thực thể,
            // xác định mối quan hệ trong CSDL
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDH);
                e.Property(dh=>dh.NgayDat).HasDefaultValueSql("getutcdate()");
                e.Property(dh => dh.NguoiNhan).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<DonHangChiTiet>(entity =>
            {
                entity.ToTable("ChiTietDonHang");
                entity.HasKey(e => new { e.MaDH, e.MaHH });

                entity.HasOne(e => e.DonHang)
                       .WithMany(e => e.DonHangChiTiets)
                       .HasForeignKey(e => e.MaDH)
                       .HasConstraintName("FK_DonHangCT_DonHang");

                entity.HasOne(e => e.HangHoa)
                       .WithMany(e => e.DonHangChiTiets)
                       .HasForeignKey(e => e.MaHH)
                       .HasConstraintName("FK_DonHangCT_HangHoa");
            });








        }









    }
}
