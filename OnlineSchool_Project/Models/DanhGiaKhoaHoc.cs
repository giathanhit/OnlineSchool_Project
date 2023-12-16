using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineSchool_Project.Models
{
    public class DanhGiaKhoaHoc
    {
        public int Id { get; set; }
        public string? ChiTietDanhGia { get; set; }
        public int DiemDanhGia { get; set; } 
        public int idHocVien { get; set; }  
        public int idKhoaHoc { get; set; } 
    }
}
