﻿namespace OnlineSchool_Project.Models
{
    public class GiangVien
    {
        public int Id { get; set; }
        public string? HoTen { get; set; }
        public string? Email { get; set; }
        public string? Sdt { get; set; }
        public string? BangCap { get; set; }
        public string? DiaChi { get; set; }
        public string? GioiTinh { get; set; }
        public string? UrlImage { get; set; }
        public DateTime NgaySinh { get; set; } 
    }
}