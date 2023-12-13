using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        // GET: /KhoaHoc/Details/id
        public IActionResult Details(int id)
        {
            var khoaHoc = _context.KhoaHocs.FirstOrDefault(g => g.Id == id);
            if (khoaHoc == null)
            {
                return NotFound();
            }
            return View(khoaHoc);
        }

		// GET: /KhoaHoc/Create
        public IActionResult Create()
		{
			ViewBag.GiangVienList = _context.GiangViens.ToList();
			return View();
        }

        // POST: /KhoaHoc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KhoaHoc khoaHoc)
        { 
            if (ModelState.IsValid)
            {
                _context.KhoaHocs.Add(khoaHoc);
                _context.SaveChanges(); 
                return RedirectToAction(nameof(Index));
            }
            ViewBag.GiangVienList = _context.GiangViens.ToList();
			return View(khoaHoc);
        }

        // GET: /KhoaHoc/Edit/id
        public IActionResult Edit(int id)
        {
            var khoaHoc = _context.KhoaHocs.FirstOrDefault(g => g.Id == id);
            if (khoaHoc == null)
            {
                return NotFound();
            }
            return View(khoaHoc);
        }

        // POST: /KhoaHoc/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, KhoaHoc khoaHoc)
        {
            if (id != khoaHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(khoaHoc);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(khoaHoc);
        }

        // GET: /KhoaHoc/Delete/id
        public IActionResult Delete(int id)
        {
            var khoaHoc = _context.KhoaHocs.FirstOrDefault(g => g.Id == id);
            if (khoaHoc == null)
            {
                return NotFound();
            }
            return View(khoaHoc);
        }

        // POST: /KhoaHoc/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var khoaHoc = _context.KhoaHocs.FirstOrDefault(g => g.Id == id);
            if (khoaHoc == null)
            {
                return NotFound();
            }

            _context.KhoaHocs.Remove(khoaHoc);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}