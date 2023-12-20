using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;

namespace OnlineSchool_Project.Controllers
{
    public class DanhGiaKhoaHocsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DanhGiaKhoaHocsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DanhGiaKhoaHocs
        public async Task<IActionResult> Index()
        {
              return _context.DanhGiaMonHocs != null ? 
                          View(await _context.DanhGiaMonHocs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.DanhGiaMonHocs'  is null.");
        }

        // GET: DanhGiaKhoaHocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DanhGiaMonHocs == null)
            {
                return NotFound();
            }

            var danhGiaKhoaHoc = await _context.DanhGiaMonHocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (danhGiaKhoaHoc == null)
            {
                return NotFound();
            }

            return View(danhGiaKhoaHoc);
        }
         
        public IActionResult Create()
        {
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChiTietDanhGia,DiemDanhGia,idHocVien,idKhoaHoc")] DanhGiaKhoaHoc danhGiaKhoaHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhGiaKhoaHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhGiaKhoaHoc);
        }
         
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DanhGiaMonHocs == null)
            {
                return NotFound();
            }

            var danhGiaKhoaHoc = await _context.DanhGiaMonHocs.FindAsync(id);
            if (danhGiaKhoaHoc == null)
            {
                return NotFound();
            }
            return View(danhGiaKhoaHoc);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ChiTietDanhGia,DiemDanhGia,idHocVien,idKhoaHoc")] DanhGiaKhoaHoc danhGiaKhoaHoc)
        {
            if (id != danhGiaKhoaHoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhGiaKhoaHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhGiaKhoaHocExists(danhGiaKhoaHoc.Id))
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
            return View(danhGiaKhoaHoc);
        }
         
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DanhGiaMonHocs == null)
            {
                return NotFound();
            }

            var danhGiaKhoaHoc = await _context.DanhGiaMonHocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (danhGiaKhoaHoc == null)
            {
                return NotFound();
            }

            return View(danhGiaKhoaHoc);
        }
         
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DanhGiaMonHocs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DanhGiaMonHocs'  is null.");
            }
            var danhGiaKhoaHoc = await _context.DanhGiaMonHocs.FindAsync(id);
            if (danhGiaKhoaHoc != null)
            {
                _context.DanhGiaMonHocs.Remove(danhGiaKhoaHoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhGiaKhoaHocExists(int id)
        {
          return (_context.DanhGiaMonHocs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
