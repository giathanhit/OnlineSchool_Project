using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSchool_Project.Models
{
    public class DanhGiaKhoaHoc
    {
        public int Id { get; set; }
        public string? ChiTietDanhGia { get; set; }
        public int DiemDanhGia { get; set; }

        [ForeignKey("HocViens")]
        public int idHocVien { get; set; }
		public HocVien? HocViens { get; set; }

        [ForeignKey("KhoaHocs")]
        public int idKhoaHoc { get; set; }
		public KhoaHoc? KhoaHocs { get; set; }
    }
}
