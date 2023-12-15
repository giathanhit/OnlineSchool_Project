using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSchool_Project.Models
{
    public class BaiHoc
    {
        public int Id { get; set; }
        public string? TenBaiHoc { get; set; }
        public string? MoTa { get; set; }
        public string? UrlVideo { get; set; }
        public string? UrlBaiTap { get; set; }

        [ForeignKey("ChuongHocs")]
        public int idChuongHoc { get; set; }
		public ChuongHoc? ChuongHocs { get; set; }

        [ForeignKey("KhoaHocs")]
        public int idKhoaHoc { get; set; }
		public KhoaHoc? KhoaHocs { get; set; }
    }
}
