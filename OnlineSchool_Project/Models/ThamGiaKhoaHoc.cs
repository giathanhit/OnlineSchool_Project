namespace OnlineSchool_Project.Models
{
	public class ThamGiaKhoaHoc
	{
		public int idKhoaHoc { get; set; } 
		public KhoaHoc KhoaHocs { get; set; } = null!; 
		public int idHocVien { get; set; }  
		public HocVien HocViens { get; set; } = null!; 
		public DateTime NgayDangKy { get; set; }
	}
}
