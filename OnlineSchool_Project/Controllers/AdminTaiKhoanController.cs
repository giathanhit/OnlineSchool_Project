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

        // GET: /TaiKhoan/Details/5
        public IActionResult Details(int id)
        {
            var giangVien = _context.TaiKhoans.FirstOrDefault(g => g.Id == id);
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

        // GET: /TaiKhoan/Edit/5
        public IActionResult Edit(int id)
        {
            var giangVien = _context.TaiKhoans.FirstOrDefault(g => g.Id == id);
            if (giangVien == null)
            {
                return NotFound();
            }
            return View(giangVien);
        }

        // POST: /TaiKhoan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TaiKhoan giangVien)
        {
            if (id != giangVien.Id)
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

        // GET: /TaiKhoan/Delete/5
        public IActionResult Delete(int id)
        {
            var giangVien = _context.TaiKhoans.FirstOrDefault(g => g.Id == id);
            if (giangVien == null)
            {
                return NotFound();
            }
            return View(giangVien);
        }

        // POST: /TaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var giangVien = _context.TaiKhoans.FirstOrDefault(g => g.Id == id);
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