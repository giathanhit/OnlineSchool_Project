﻿using System.ComponentModel.DataAnnotations;

namespace OnlineSchool_Project.Models
{
    public class TaiKhoan
    { 
        public string TenDangNhap { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public string LoaiTaiKhoan { get; set; } = null!;
    }
}
