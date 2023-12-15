namespace OnlineSchool_Project.Models
{
	public class DangKyKhoaHoc
	{
		public int idGiangVien { get; set; }
		public GiangVien GiangViens { get; set; }
		public int idKhoaHoc { get; set; }
		public KhoaHoc KhoaHocs { get; set; }
		public DateTime NgayHoc { get; set; }
		public DateTime NgayKetThuc { get; set; }
		public float? GiaKhoaHoc { get; set; }
		public int? SoLuongKhoaHoc { get; set; } 
	}
}
