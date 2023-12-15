using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSchool_Project.Models
{
	public class KhoaHoc
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Tên khóa học là bắt buộc.")]
		public string TenKhoaHoc { get; set; } = null!;

		public string MoTa { get; set; } = null!;

		public string HinhThuc { get; set; } = null!;

		public string? UrlImage { get; set; }

		[Required(ErrorMessage = "Vui lòng chọn ngành học.")]
        [ForeignKey("NganhHocs")]
        public int idNganhHoc { get; set; } 
		public NganhHoc? NganhHocs { get; set; }
	}
}
