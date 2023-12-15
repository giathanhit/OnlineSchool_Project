namespace OnlineSchool_Project.Models
{
    public class ChuongHoc
    {
        public int Id { get; set; }
        public string? TenChuongHoc { get; set; }
        public string? MoTa { get; set; }
		public int idKhoaHoc { get; set; }
		public KhoaHoc KhoaHocs { get; set; }  
    }
}
