using System.ComponentModel.DataAnnotations;

namespace OnlineSchool_Project.Models.Admin
{
    public class KhoaHocViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên khóa học là bắt buộc.")]
        public string TenKhoaHoc { get; set; } = null!;

        public string MoTa { get; set; } = null!;

        public string HinhThuc { get; set; } = null!;

        public IFormFile? UrlPicture { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngành học.")]
        public int idNganhHoc { get; set; }
    }
}
