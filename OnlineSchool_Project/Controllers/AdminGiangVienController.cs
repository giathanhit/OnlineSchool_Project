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

        public IActionResult Index()
        {
            var giangViens = _context.GiangViens.ToList();
            return View(giangViens);
        }

        public IActionResult Details(int id)
        {
            var giangVien = _context.GiangViens.FirstOrDefault(g => g.Id == id);
            if (giangVien == null)
            {
                return NotFound();
            }
            return View(giangVien);
        }

        public IActionResult Create()
        {
            ViewBag.NganhHocList = _context.NganhHocs.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GiangVien giangVien)
        {
            ViewBag.NganhHocList = _context.NganhHocs.ToList();

            if (ModelState.IsValid)
            {
                // Tìm NganhHoc tương ứng với idNganhHoc
                var nganhHoc = _context.NganhHocs.Find(giangVien.idNganhHoc);

                // Gán giá trị cho thuộc tính NganhHocs
                //giangVien.NganhHocs = nganhHoc;
                _context.GiangViens.Add(giangVien);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(giangVien);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.NganhHocList = _context.NganhHocs.ToList();

            var giangVien = _context.GiangViens.FirstOrDefault(g => g.Id == id);
            if (giangVien == null)
            {
                return NotFound();
            }

            return View(giangVien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, GiangVien giangVien)
        {
            ViewBag.NganhHocList = _context.NganhHocs.ToList();

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


        public IActionResult Delete(int id)
        {
            var giangVien = _context.GiangViens.FirstOrDefault(g => g.Id == id);
            if (giangVien == null)
            {
                return NotFound();
            }
            return View(giangVien);
        }

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