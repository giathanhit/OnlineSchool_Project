using System.ComponentModel.DataAnnotations;

namespace OnlineSchool_Project.Models
{
    public class HocVien
    { 
        public int Id { get; set; }
        public string HoTen { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public string? Sdt { get; set; }
        public string BangCap { get; set; } = null!;
        public string? DiaChi { get; set; }
        public string? GioiTinh { get; set; }
		public DateTime NgaySinh { get; set; }
		public string? UrlImage { get; set; }
    }
}
