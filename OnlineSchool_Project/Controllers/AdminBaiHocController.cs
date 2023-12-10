using Microsoft.AspNetCore.Mvc;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;

namespace OnlineSchool_Project.Controllers
{ 
    public class AdminBaiHocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminBaiHocController(ApplicationDbContext context)
        {
            _context = context;
        }
         
        public IActionResult Index()
        {
            var baiHocList = _context.BaiHocs.ToList();
            return View(baiHocList);
        }
         
        public IActionResult Create()
        {
            return View();
        }
         
        [HttpPost]
        public IActionResult Create(BaiHoc baiHoc)
        {
            if (ModelState.IsValid)
            {
                _context.BaiHocs.Add(baiHoc);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baiHoc);
        }
         
        public IActionResult Details(int id)
        {
            var baiHoc = _context.BaiHocs.FirstOrDefault(b => b.Id == id);
            if (baiHoc == null)
            {
                return NotFound();
            }
            return View(baiHoc);
        }
         
        public IActionResult Edit(int id)
        {
            var baiHoc = _context.BaiHocs.FirstOrDefault(b => b.Id == id);
            if (baiHoc == null)
            {
                return NotFound();
            }
            return View(baiHoc);
        }
         
        [HttpPost]
        public IActionResult Edit(int id, BaiHoc baiHoc)
        {
            if (id != baiHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.BaiHocs.Update(baiHoc);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(baiHoc);
        }
         
        public IActionResult Delete(int id)
        {
            var baiHoc = _context.BaiHocs.FirstOrDefault(b => b.Id == id);
            if (baiHoc == null)
            {
                return NotFound();
            }
            return View(baiHoc);
        }
         
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var baiHoc = _context.BaiHocs.FirstOrDefault(b => b.Id == id);
            if (baiHoc == null)
            {
                return NotFound();
            }

            _context.BaiHocs.Remove(baiHoc);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}