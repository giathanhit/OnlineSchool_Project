using Microsoft.AspNetCore.Mvc;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;
using OnlineSchool_Project.Models.User;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace OnlineSchool_Project.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _context;

        public UserController(ILogger<UserController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
			var tenDangNhap = HttpContext.Session.GetString("TenDangNhap");

			if (tenDangNhap != null)
            {
				ViewBag.TenDangNhap = tenDangNhap;
				return View();
            }
            else
            {
                return RedirectToAction("Dangnhap");
            }
        }  
        
        public IActionResult Khoahoc()
		{
			var tenDangNhap = HttpContext.Session.GetString("TenDangNhap");

			if (tenDangNhap != null)
			{
				ViewBag.TenDangNhap = tenDangNhap;
				var khoaHocs = _context.KhoaHocs.ToList();
				return View(khoaHocs);
			}
			else
			{
				return RedirectToAction("Dangnhap");
			}
        }  
         
        public IActionResult Chitietkhoahoc()
        {
            return View();
        }  
        
        public IActionResult Dangnhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dangnhap(DangNhapModel taiKhoan)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(taiKhoan);
                }

                taiKhoan.MatKhau = GetMD5(taiKhoan.MatKhau);

                var user = _context.TaiKhoans
                    .FirstOrDefault(u => u.TenDangNhap == taiKhoan.TenDangNhap && u.MatKhau == taiKhoan.MatKhau);

                if (user != null)
                {
                    // Đăng nhập thành công, có thể thực hiện các hành động cần thiết
                    // Ví dụ: Lưu thông tin đăng nhập vào session
                    HttpContext.Session.SetString("TenDangNhap", user.TenDangNhap);

                    return RedirectToAction("Index"); // Chuyển hướng sau khi đăng nhập thành công
                }
                else
                {
                    // Đăng nhập thất bại, hiển thị thông báo lỗi
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                    return View(taiKhoan);
                }
            }
            catch (Exception ex)
            {
                // Ghi log nếu có lỗi xảy ra
                _logger.LogError(ex, "Lỗi khi đăng nhập");
                return View(taiKhoan); // Trả về view với model để hiển thị lỗi
            }
        }

        public IActionResult Dangky()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Dangky(DangKyModel taiKhoan1)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(taiKhoan1);
                }

                if(taiKhoan1.MatKhau != taiKhoan1.re_MatKhau)
                {
                    ViewBag.error = "Mật khẩu không trùng khớp vui lòng nhập lại";
                    ViewBag.showErrorDialog = true;
                    return View();
                }

                var checkEmail = _context.TaiKhoans.FirstOrDefault(x => x.Email == taiKhoan1.Email);
                if(checkEmail != null)
                {
                    ViewBag.error = "Email đã tồn tại";
                    ViewBag.showErrorDialog = true;
                    return View();
                }

                var checkUserName = _context.TaiKhoans.FirstOrDefault(x => x.TenDangNhap == taiKhoan1.TenDangNhap);
                if (checkUserName != null)
                {
                    ViewBag.error = "Tên tài khoản đã tồn tại, vui lòng chọn tên khác";
                    ViewBag.showErrorDialog = true;
                    return View();
                }
                else
                {
                    taiKhoan1.MatKhau = GetMD5(taiKhoan1.MatKhau);

                    var user = new TaiKhoan
                    {
                        ID = Guid.NewGuid(),
                        Email = taiKhoan1.Email,
                        TenDangNhap = taiKhoan1.TenDangNhap,
                        MatKhau = taiKhoan1.MatKhau
                    };

                    // Thêm đối tượng user mới vào database
                    _context.TaiKhoans.Add(user);

                    // Lưu thay đổi vào database
                    _context.SaveChanges();

                    return RedirectToAction("Dangnhap");
                }
            }
            catch (Exception ex)
            {
                // Ghi log nếu có lỗi xảy ra
                ViewBag.error(ex, "Lỗi khi đăng ký tài khoản");
                ViewBag.showErrorDialog = true;
                return View(taiKhoan1); // Trả về view với model để hiển thị lỗi
            }
        }

        public ActionResult DangXuat()
        {
            HttpContext.Session.Clear();//remove session
            return RedirectToAction("Dangnhap");
        }

        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}