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

        // Phương thức hiển thị danh sách bài học
        public IActionResult Index()
        {
            var baiHocList = _context.BaiHocs.ToList();
            return View(baiHocList);
        }

        // Phương thức hiển thị form tạo mới bài học
        public IActionResult Create()
        {
            return View();
        }

        // Phương thức lưu bài học tạo mới vào cơ sở dữ liệu
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

        // Phương thức hiển thị thông tin chi tiết của một bài học
        public IActionResult Details(int id)
        {
            var baiHoc = _context.BaiHocs.FirstOrDefault(b => b.Id == id);
            if (baiHoc == null)
            {
                return NotFound();
            }
            return View(baiHoc);
        }

        // Phương thức hiển thị form chỉnh sửa thông tin bài học
        public IActionResult Edit(int id)
        {
            var baiHoc = _context.BaiHocs.FirstOrDefault(b => b.Id == id);
            if (baiHoc == null)
            {
                return NotFound();
            }
            return View(baiHoc);
        }

        // Phương thức lưu thông tin bài học sau khi chỉnh sửa vào cơ sở dữ liệu
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

        // Phương thức hiển thị form xác nhận xóa bài học
        public IActionResult Delete(int id)
        {
            var baiHoc = _context.BaiHocs.FirstOrDefault(b => b.Id == id);
            if (baiHoc == null)
            {
                return NotFound();
            }
            return View(baiHoc);
        }

        // Phương thức xóa bài học khỏi cơ sở dữ liệu
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