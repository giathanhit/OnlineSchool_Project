using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSchool_Project.Models
{
	public class ThamGiaKhoaHoc
    { 
        public int idKhoaHoc { get; set; }   
        public int idHocVien { get; set; }   
		public DateTime NgayDangKy { get; set; }
	}
}
