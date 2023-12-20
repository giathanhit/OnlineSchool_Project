using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;
using PagedList.Core;
using OnlineSchool_Project.Helpper;

namespace OnlineSchool_Project.Controllers
{
	public class AdminHocVienController : Controller
	{
		private readonly ApplicationDbContext _context;

		public AdminHocVienController(ApplicationDbContext context)
		{
			_context = context;
		}


		public IActionResult Index(int? page)
		{
			var pageNumber = page == null || page <= 0 ? 1 : page.Value;
			var pageSize = 10;
			var lsHocVien = _context.HocViens
									.AsNoTracking()
									.OrderBy(x => x.Id);
			PagedList<HocVien> models = new PagedList<HocVien>(lsHocVien, pageNumber, pageSize);

			ViewBag.CurrentPage = pageNumber;

			return View(models);
		}


		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.HocViens == null)
			{
				return NotFound();
			}

			var hocVien = await _context.HocViens
				.FirstOrDefaultAsync(m => m.Id == id);
			if (hocVien == null)
			{
				return NotFound();
			}

			return View(hocVien);
		}


		public IActionResult Create()
		{
			ViewBag.NganhHocList = _context.NganhHocs.ToList();
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,HoTen,Email,MatKhau,CCCD,Sdt,BangCap,DiaChi,GioiTinh,UrlImage,NgaySinh")] HocVien hocVien
			, Microsoft.AspNetCore.Http.IFormFile fThumb)
		{

			if (ModelState.IsValid)
			{
				if (fThumb != null)
				{
					string extension = Path.GetExtension(fThumb.FileName);
					string image = Utilities.SEOUrl(hocVien.HoTen) + extension;
					hocVien.UrlImage = await Utilities.UploadFile(fThumb, @"hocvien", image.ToLower());
				}
				_context.Add(hocVien);
				TempData["message"] = "Thêm mới thành công !";
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			ViewBag.NganhHocList = _context.NganhHocs.ToList();
			return View(hocVien);
		}


		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.HocViens == null)
			{
				return NotFound();
			}

			var hocVien = await _context.HocViens.FindAsync(id);
			if (hocVien == null)
			{
				return NotFound();
			}
			ViewBag.NganhHocList = _context.NganhHocs.ToList();
			return View(hocVien);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,HoTen,Email,MatKhau,Sdt,BangCap,DiaChi,GioiTinh,UrlImage,NgaySinh")] HocVien hocVien
			, Microsoft.AspNetCore.Http.IFormFile fThumb)
		{
			if (id != hocVien.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					if (fThumb != null)
					{
						string extension = Path.GetExtension(fThumb.FileName);
						string image = Utilities.SEOUrl(hocVien.HoTen) + extension;
						hocVien.UrlImage = await Utilities.UploadFile(fThumb, @"hocvien", image.ToLower());
					}
					_context.Update(hocVien);
					TempData["message"] = "Cập nhật thông tin thành công !";
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!GiangVienExists(hocVien.Id))
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
			ViewBag.NganhHocList = _context.NganhHocs.ToList();
			return View(hocVien);
		}



		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.HocViens == null)
			{
				return NotFound();
			}

			var hocVien = await _context.HocViens
				.FirstOrDefaultAsync(m => m.Id == id);
			if (hocVien == null)
			{
				return NotFound();
			}

			return View(hocVien);
		}
		  
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.HocViens == null)
			{
				return Problem("Entity set 'ApplicationDbContext.HocViens'  is null.");
			}
			var hocVien = await _context.HocViens.FindAsync(id);
			if (hocVien != null)
			{
				_context.HocViens.Remove(hocVien);
			}

			await _context.SaveChangesAsync();
			TempData["message"] = "Xóa thành công!";
			return RedirectToAction(nameof(Index));
		}

		private bool GiangVienExists(int id)
		{
			return (_context.HocViens?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
