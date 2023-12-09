namespace OnlineSchool_Project.Models
{
    public class KhoaHoc
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? MoTa { get; set; }
        public float Gia { get; set; }
        public string? HinhThuc { get; set; }
        public string? UrlImage { get; set; }
        public DateTime NgayHoc { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int SoLuong { get; set; }
        public string? TrangThai { get; set; }
        public GiangVien GiangViens { get; set; }
    }
}
