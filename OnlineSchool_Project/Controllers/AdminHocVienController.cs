using Microsoft.AspNetCore.Mvc;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;

namespace OnlineSchool_Project.Controllers
{ 
    public class AdminHocVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminHocVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /HocVien
        public IActionResult Index()
        {
            var hocViens = _context.HocViens.ToList();
            return View(hocViens);
        }

        // GET: /HocVien/Details/id
        public IActionResult Details(int id)
        {
            var hocVien = _context.HocViens.FirstOrDefault(g => g.Id == id);
            if (hocVien == null)
            {
                return NotFound();
            }
            return View(hocVien);
        }

        // GET: /HocVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /HocVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HocVien hocVien)
        {
            if (ModelState.IsValid)
            {
                _context.HocViens.Add(hocVien);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(hocVien);
        }

        // GET: /HocVien/Edit/id
        public IActionResult Edit(int id)
        {
            var hocVien = _context.HocViens.FirstOrDefault(g => g.Id == id);
            if (hocVien == null)
            {
                return NotFound();
            }
            return View(hocVien);
        }

        // POST: /HocVien/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, HocVien hocVien)
        {
            if (id != hocVien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(hocVien);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(hocVien);
        }

        // GET: /HocVien/Delete/id
        public IActionResult Delete(int id)
        {
            var hocVien = _context.HocViens.FirstOrDefault(g => g.Id == id);
            if (hocVien == null)
            {
                return NotFound();
            }
            return View(hocVien);
        }

        // POST: /HocVien/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var hocVien = _context.HocViens.FirstOrDefault(g => g.Id == id);
            if (hocVien == null)
            {
                return NotFound();
            }

            _context.HocViens.Remove(hocVien);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}