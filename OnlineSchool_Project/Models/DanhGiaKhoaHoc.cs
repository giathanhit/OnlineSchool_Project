namespace OnlineSchool_Project.Models
{
    public class DanhGiaKhoaHoc
    {
        public int Id { get; set; }
        public string? ChiTietDanhGia { get; set; }
        public int DiemDanhGia { get; set; } 
        public HocVien HocViens { get; set; } = null!; 
        public KhoaHoc KhoaHocs { get; set; } = null!;
    }
}
