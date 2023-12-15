namespace OnlineSchool_Project.Models
{
    public class BaiHoc
    {
        public int Id { get; set; }
        public string? TenBaiHoc { get; set; }
        public string? MoTa { get; set; }
        public string? UrlVideo { get; set; }
        public string? UrlBaiTap { get; set; } 
        public ChuongHoc ChuongHocs { get; set; }
        public KhoaHoc KhoaHocs { get; set; }
    }
}
