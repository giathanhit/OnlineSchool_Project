using Microsoft.AspNetCore.Mvc; 
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models; 

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineSchool_Project.Controllers
{
    public class AdminKhoaHocController : Controller
    {
        private readonly ApplicationDbContext _context;
        IWebHostEnvironment _environment;

        public AdminKhoaHocController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
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

        public IActionResult Create()
        {
            ViewBag.NganhHocList = _context.NganhHocs.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KhoaHocViewModel khoaHoc)
        {
            ViewBag.NganhHocList = _context.NganhHocs.ToList();

            if (ModelState.IsValid)
            {
                string fileName = "";
                if(khoaHoc.UrlPicture != null)
                {
                    string uploadFolder = Path.Combine(_environment.WebRootPath, "uploads");
                    fileName = Guid.NewGuid().ToString();
                    string filePath = Path.Combine(uploadFolder, fileName);
                    khoaHoc.UrlPicture.CopyTo(new FileStream(filePath,FileMode.Create));
                }
                KhoaHoc khoaHocs = new KhoaHoc
                {
                    Id = khoaHoc.Id,
                    MoTa = khoaHoc.MoTa,
                    HinhThuc = khoaHoc.HinhThuc,
                    TenKhoaHoc = khoaHoc.TenKhoaHoc,
                    idNganhHoc = khoaHoc.idNganhHoc,
                    UrlImage = fileName
                };

                _context.KhoaHocs.Add(khoaHocs);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(khoaHoc);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.NganhHocList = _context.NganhHocs.ToList();

            var khoaHoc = _context.KhoaHocs.FirstOrDefault(g => g.Id == id);
            if (khoaHoc == null)
            {
                return NotFound();
            }
            return View(khoaHoc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, KhoaHoc khoaHoc)
        {
            ViewBag.NganhHocList = _context.NganhHocs.ToList();

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

        public IActionResult Delete(int id)
        {
            var khoaHoc = _context.KhoaHocs.FirstOrDefault(g => g.Id == id);
            if (khoaHoc == null)
            {
                return NotFound();
            }
            return View(khoaHoc);
        }

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