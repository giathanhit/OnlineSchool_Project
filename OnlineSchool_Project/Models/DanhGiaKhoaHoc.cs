namespace OnlineSchool_Project.Models
{
    public class DanhGiaKhoaHoc
    {
        public int Id { get; set; }
        public string? ChiTietDanhGia { get; set; }
        public int DiemDanhGia { get; set; }
		public int idHocVien { get; set; }
		public HocVien HocViens { get; set; } = null!;
		public int idKhoaHoc { get; set; }
		public KhoaHoc KhoaHocs { get; set; } = null!;
    }
}
