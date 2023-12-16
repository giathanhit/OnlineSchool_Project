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
        public int idChuongHoc { get; set; }  
        public int idKhoaHoc { get; set; } 
    }
}
