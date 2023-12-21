using Microsoft.AspNetCore.Mvc;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models.User;
using System.Security.Cryptography;
using System.Text;

namespace OnlineSchool_Project.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _context;

        public AdminController(ILogger<UserController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var tenDangNhap = HttpContext.Session.GetString("TenDangNhap");  

			if (tenDangNhap != null && tenDangNhap == "admin")
			{
				ViewBag.TenDangNhap = tenDangNhap;

				return View();
			}
			else
			{
				return RedirectToAction("Dangnhap");
			}
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

    }
}
