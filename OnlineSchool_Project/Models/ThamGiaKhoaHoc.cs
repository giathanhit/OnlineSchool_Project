namespace OnlineSchool_Project.Models
{
	public class ThamGiaKhoaHoc
	{
		public int KhoaHocId { get; set; } 
		public KhoaHoc KhoaHocs { get; set; } = null!; 
		public int HocVienId { get; set; }  
		public HocVien HocViens { get; set; } = null!; 
		public DateTime NgayDangKy { get; set; }
	}
}
