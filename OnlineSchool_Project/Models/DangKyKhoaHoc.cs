using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSchool_Project.Models
{
	public class DangKyKhoaHoc
    {
        [ForeignKey("GiangViens")]
        public int idGiangVien { get; set; }
		public GiangVien? GiangViens { get; set; }

        [ForeignKey("KhoaHocs")]
        public int idKhoaHoc { get; set; }
		public KhoaHoc? KhoaHocs { get; set; }
		public DateTime NgayHoc { get; set; }
		public DateTime NgayKetThuc { get; set; }
		public float? GiaKhoaHoc { get; set; }
		public int? SoLuongKhoaHoc { get; set; } 
	}
}
