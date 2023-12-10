using Microsoft.AspNetCore.Mvc;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;

namespace OnlineSchool_Project.Controllers
{ 
    public class AdminTaiKhoanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminTaiKhoanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /TaiKhoan
        public IActionResult Index()
        {
            var giangViens = _context.TaiKhoans.ToList();
            return View(giangViens);
        }

        // GET: /TaiKhoan/Details
        public IActionResult Details(string id)
        {
            var giangVien = _context.TaiKhoans.FirstOrDefault(g => g.TenDangNhap == id);
            if (giangVien == null)
            {
                return NotFound();
            }
            return View(giangVien);
        }

        // GET: /TaiKhoan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /TaiKhoan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaiKhoan giangVien)
        {
            if (ModelState.IsValid)
            {
                _context.TaiKhoans.Add(giangVien);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(giangVien);
        }

		// GET: /TaiKhoan/Edit/id
		public IActionResult Edit(string id)
        {
            var giangVien = _context.TaiKhoans.FirstOrDefault(g => g.TenDangNhap == id);
            if (giangVien == null)
            {
                return NotFound();
            }
            return View(giangVien);
        }

		// POST: /TaiKhoan/Edit/id
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, TaiKhoan giangVien)
        {
            if (id != giangVien.TenDangNhap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(giangVien);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(giangVien);
        }

		// GET: /TaiKhoan/Delete/id
		public IActionResult Delete(string id)
        {
            var giangVien = _context.TaiKhoans.FirstOrDefault(g => g.TenDangNhap == id);
            if (giangVien == null)
            {
                return NotFound();
            }
            return View(giangVien);
        }

		// POST: /TaiKhoan/Delete/id
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var giangVien = _context.TaiKhoans.FirstOrDefault(g => g.TenDangNhap == id);
            if (giangVien == null)
            {
                return NotFound();
            }

            _context.TaiKhoans.Remove(giangVien);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}