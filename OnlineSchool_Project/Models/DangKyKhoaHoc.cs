namespace OnlineSchool_Project.Models
{
	public class DangKyKhoaHoc
	{
		public int GiangVienId { get; set; }
		public GiangVien GiangViens { get; set; }
		public int KhoaHocId { get; set; }
		public KhoaHoc KhoaHocs { get; set; }
		public DateTime NgayHoc { get; set; }
		public DateTime NgayKetThuc { get; set; }
		public float? GiaKhoaHoc { get; set; }
		public int? SoLuongKhoaHoc { get; set; } 
	}
}
