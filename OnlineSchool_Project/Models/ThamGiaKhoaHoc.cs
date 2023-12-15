using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSchool_Project.Models
{
	public class ThamGiaKhoaHoc
    {
        [ForeignKey("KhoaHocs")]
        public int idKhoaHoc { get; set; } 
		public KhoaHoc KhoaHocs { get; set; } = null!;

        [ForeignKey("HocViens")]
        public int idHocVien { get; set; }  
		public HocVien HocViens { get; set; } = null!; 
		public DateTime NgayDangKy { get; set; }
	}
}
