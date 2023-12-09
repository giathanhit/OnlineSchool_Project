using Microsoft.AspNetCore.Mvc;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;

namespace OnlineSchool_Project.Controllers
{ 
    public class AdminKhoaHocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminKhoaHocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /KhoaHoc
        public IActionResult Index()
        {
            var giangViens = _context.KhoaHocs.ToList();
            return View(giangViens);
        }

        // GET: /KhoaHoc/Details/5
        public IActionResult Details(int id)
        {
            var giangVien = _context.KhoaHocs.FirstOrDefault(g => g.Id == id);
            if (giangVien == null)
            {
                return NotFound();
            }
            return View(giangVien);
        }

        // GET: /KhoaHoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /KhoaHoc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KhoaHoc giangVien)
        {
            if (ModelState.IsValid)
            {
                _context.KhoaHocs.Add(giangVien);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(giangVien);
        }

        // GET: /KhoaHoc/Edit/5
        public IActionResult Edit(int id)
        {
            var giangVien = _context.KhoaHocs.FirstOrDefault(g => g.Id == id);
            if (giangVien == null)
            {
                return NotFound();
            }
            return View(giangVien);
        }

        // POST: /KhoaHoc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, KhoaHoc giangVien)
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

        // GET: /KhoaHoc/Delete/5
        public IActionResult Delete(int id)
        {
            var giangVien = _context.KhoaHocs.FirstOrDefault(g => g.Id == id);
            if (giangVien == null)
            {
                return NotFound();
            }
            return View(giangVien);
        }

        // POST: /KhoaHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var giangVien = _context.KhoaHocs.FirstOrDefault(g => g.Id == id);
            if (giangVien == null)
            {
                return NotFound();
            }

            _context.KhoaHocs.Remove(giangVien);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}