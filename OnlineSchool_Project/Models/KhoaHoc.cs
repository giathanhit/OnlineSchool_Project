namespace OnlineSchool_Project.Models
{
    public class KhoaHoc
    {
        public int Id { get; set; }
        public string TenKhoaHoc { get; set; } = null!;
        public string MoTa { get; set; } = null!; 
        public string HinhThuc { get; set; } = null!;
        public string? UrlImage { get; set; } 
        public NganhHoc NganhHocs { get; set; } = null!;
    }
}
