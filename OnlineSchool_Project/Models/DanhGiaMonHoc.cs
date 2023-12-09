namespace OnlineSchool_Project.Models
{
    public class DanhGiaMonHoc
    {
        public int Id { get; set; }
        public string? ChiTietDanhGia { get; set; }
        public int DiemDanhGia { get; set; } 
        public HocVien HocViens { get; set; } 
        public KhoaHoc KhoaHocs { get; set; }
    }
}
