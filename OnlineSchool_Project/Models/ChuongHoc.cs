namespace OnlineSchool_Project.Models
{
    public class ChuongHoc
    {
        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? MoTa { get; set; }
        public KhoaHoc KhoaHocs { get; set; }  
    }
}
