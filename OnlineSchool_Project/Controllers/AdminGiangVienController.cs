using Microsoft.AspNetCore.Mvc;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;

namespace OnlineSchool_Project.Controllers
{ 
    public class AdminGiangVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminGiangVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /GiangVien
        public IActionResult Index()
        {
            var giangViens = _context.GiangViens.ToList();
            return View(giangViens);
        }

        // GET: /GiangVien/Details/id
        public IActionResult Details(int id)
        {
            var giangVien = _context.GiangViens.FirstOrDefault(g => g.Id == id);
            if (giangVien == null)
            {
                return NotFound();
            }
            return View(giangVien);
        }

        // GET: /GiangVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /GiangVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GiangVien giangVien)
        {
            if (ModelState.IsValid)
            {
                _context.GiangViens.Add(giangVien);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(giangVien);
        }

        // GET: /GiangVien/Edit/id
        public IActionResult Edit(int id)
        {
            var giangVien = _context.GiangViens.FirstOrDefault(g => g.Id == id);
            if (giangVien == null)
            {
                return NotFound();
            }
            return View(giangVien);
        }

        // POST: /GiangVien/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, GiangVien giangVien)
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

        // GET: /GiangVien/Delete/id
        public IActionResult Delete(int id)
        {
            var giangVien = _context.GiangViens.FirstOrDefault(g => g.Id == id);
            if (giangVien == null)
            {
                return NotFound();
            }
            return View(giangVien);
        }

        // POST: /GiangVien/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var giangVien = _context.GiangViens.FirstOrDefault(g => g.Id == id);
            if (giangVien == null)
            {
                return NotFound();
            }

            _context.GiangViens.Remove(giangVien);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}