 
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;
using PagedList.Core;

namespace OnlineSchool_Project.Controllers
{
    public class AdminBaiHocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminBaiHocController(ApplicationDbContext context)
        {
            _context = context;
        }
         
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsBaiHoc = _context.BaiHocs
                                    .AsNoTracking()
                                    .OrderBy(x => x.Id);
            PagedList<BaiHoc> models = new PagedList<BaiHoc>(lsBaiHoc, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;

            return View(models);
        }
         
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BaiHocs == null)
            {
                return NotFound();
            }

            var baiHoc = await _context.BaiHocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baiHoc == null)
            {
                return NotFound();
            }
            ViewBag.KhoaHocList = _context.KhoaHocs.ToList();
            ViewBag.ChuongHocList = _context.ChuongHocs.ToList();
            return View(baiHoc);
        }


        public IActionResult Create()
        {
            ViewBag.KhoaHocList = _context.KhoaHocs.ToList();
            ViewBag.ChuongHocList = _context.ChuongHocs.ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenBaiHoc,MoTa,UrlVideo,UrlBaiTap,idChuongHoc,idKhoaHoc")] BaiHoc baiHoc)
        {
            ViewBag.KhoaHocList = _context.KhoaHocs.ToList();
            ViewBag.ChuongHocList = _context.ChuongHocs.ToList();
            if (ModelState.IsValid)
            {
                _context.Add(baiHoc);
                TempData["message"] = "Thêm mới thành công !";
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baiHoc);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.KhoaHocList = _context.KhoaHocs.ToList();
            ViewBag.ChuongHocList = _context.ChuongHocs.ToList();
            if (id == null || _context.BaiHocs == null)
            {
                return NotFound();
            }

            var baiHoc = await _context.BaiHocs.FindAsync(id);
            if (baiHoc == null)
            {
                return NotFound();
            }
            return View(baiHoc);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenBaiHoc,MoTa,UrlVideo,UrlBaiTap,idChuongHoc,idKhoaHoc")] BaiHoc baiHoc)
        {

            if (id != baiHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baiHoc);
                    TempData["message"] = "Cập nhật thông tin thành công !";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaiHocExists(baiHoc.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.KhoaHocList = _context.KhoaHocs.ToList();
            ViewBag.ChuongHocList = _context.ChuongHocs.ToList();
            return View(baiHoc);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BaiHocs == null)
            {
                return NotFound();
            }

            var baiHoc = await _context.BaiHocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baiHoc == null)
            {
                return NotFound();
            }
            ViewBag.KhoaHocList = _context.KhoaHocs.ToList();
            ViewBag.ChuongHocList = _context.ChuongHocs.ToList();
            return View(baiHoc);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BaiHocs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BaiHocs'  is null.");
            }
            var baiHoc = await _context.BaiHocs.FindAsync(id);
            if (baiHoc != null)
            {
                _context.BaiHocs.Remove(baiHoc);
            }

            await _context.SaveChangesAsync();
            TempData["message"] = "Xóa thành công !";
            return RedirectToAction(nameof(Index));
        }

        private bool BaiHocExists(int id)
        {
            return (_context.BaiHocs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
