using Microsoft.AspNetCore.Mvc;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;
using System.Security.Cryptography;
using System.Text;

namespace OnlineSchool_Project.Controllers
{
    public class AdminTaiKhoanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminTaiKhoanController(ApplicationDbContext context)
        {
            _context = context;
        }
         
        public IActionResult Index()
        {
            var taiKhoans = _context.TaiKhoans.ToList();
            return View(taiKhoans);
        }
         
        public IActionResult Details(string id)
        {
            var taiKhoans = _context.TaiKhoans.FirstOrDefault(g => g.TenDangNhap == id);
            if (taiKhoans == null)
            {
                return NotFound();
            }
            return View(taiKhoans);
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

		public IActionResult Create()
        {
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaiKhoan taiKhoans)
        {
            if (ModelState.IsValid)
            {
                taiKhoans.ID = Guid.NewGuid(); 
				taiKhoans.MatKhau = GetMD5(taiKhoans.MatKhau);
				_context.TaiKhoans.Add(taiKhoans);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(taiKhoans);
        } 

		public IActionResult Edit(string id)
        {
            var taiKhoans = _context.TaiKhoans.FirstOrDefault(g => g.TenDangNhap == id);
            if (taiKhoans == null)
            {
                return NotFound();
            }
            return View(taiKhoans);
        }
         
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, TaiKhoan taiKhoans)
        {
            if (id != taiKhoans.TenDangNhap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
			{
				taiKhoans.MatKhau = GetMD5(taiKhoans.MatKhau);
				_context.Update(taiKhoans);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(taiKhoans);
        }
         
		public IActionResult Delete(string id)
        {
            var taiKhoans = _context.TaiKhoans.FirstOrDefault(g => g.TenDangNhap == id);
            if (taiKhoans == null)
            {
                return NotFound();
            }
            return View(taiKhoans);
        }
         
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var taiKhoans = _context.TaiKhoans.FirstOrDefault(g => g.TenDangNhap == id);
            if (taiKhoans == null)
            {
                return NotFound();
            }

            _context.TaiKhoans.Remove(taiKhoans);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}