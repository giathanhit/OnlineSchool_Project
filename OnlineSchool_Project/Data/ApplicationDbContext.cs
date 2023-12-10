using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineSchool_Project.Models;

namespace OnlineSchool_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<GiangVien> GiangViens { get; set; }
        public DbSet<HocVien> HocViens { get; set; }
        public DbSet<BaiHoc> BaiHocs { get; set; }
        public DbSet<ChuongHoc> ChuongHocs { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<ThamGiaKhoaHoc> ThamGiaKhoaHocs { get; set; }
        public DbSet<DanhGiaMonHoc> DanhGiaMonHocs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ThamGiaKhoaHoc>().HasNoKey();
            modelBuilder.Entity<TaiKhoan>().HasNoKey();

            // Cấu hình các quan hệ, chỉnh sửa tên bảng, khóa chính, khóa ngoại, v.v. tại đây
        }
    }
}