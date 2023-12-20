namespace OnlineSchool_Project.Models.User
{
    public class DangKyModel
    {
        public Guid ID { get; set; }
        public string Email { get; set; } = null!;
        public string TenDangNhap { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public string re_MatKhau { get; set; } = null!;
    }
}
