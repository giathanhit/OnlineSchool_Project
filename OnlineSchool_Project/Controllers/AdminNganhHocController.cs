using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineSchool_Project.Controllers
{ 
    public class AdminNganhHocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminNganhHocController(ApplicationDbContext context)
        {
            _context = context;
        } 


        public IActionResult Index()
        {
            var giangViens = _context.NganhHocs.ToList();
            return View(giangViens);
        }
         
        public IActionResult Details(int id)
        {
            var nganhHoc = _context.NganhHocs.FirstOrDefault(g => g.Id == id);
            if (nganhHoc == null)
            {
                return NotFound();
            }
            return View(nganhHoc);
        }
         
        public IActionResult Create()
		{
			ViewBag.NganhHocList = _context.NganhHocs.ToList();
			return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NganhHoc nganhHoc)
        { 
            if (ModelState.IsValid)
            {
                _context.NganhHocs.Add(nganhHoc);
                _context.SaveChanges(); 
                return RedirectToAction(nameof(Index));
            }
            ViewBag.NganhHocList = _context.NganhHocs.ToList();
			return View(nganhHoc);
        }
         
        public IActionResult Edit(int id)
        {
            var nganhHoc = _context.NganhHocs.FirstOrDefault(g => g.Id == id);
            if (nganhHoc == null)
            {
                return NotFound();
            }
            return View(nganhHoc);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, NganhHoc nganhHoc)
        {
            if (id != nganhHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(nganhHoc);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(nganhHoc);
        }
         
        public IActionResult Delete(int id)
        {
            var nganhHoc = _context.NganhHocs.FirstOrDefault(g => g.Id == id);
            if (nganhHoc == null)
            {
                return NotFound();
            }
            return View(nganhHoc);
        }
         
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var nganhHoc = _context.NganhHocs.FirstOrDefault(g => g.Id == id);
            if (nganhHoc == null)
            {
                return NotFound();
            }

            _context.NganhHocs.Remove(nganhHoc);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}