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
	public class AdminKhoaHocController : Controller
	{
		private readonly ApplicationDbContext _context;

		public AdminKhoaHocController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index(int? page)
		{
			var pageNumber = page == null || page <= 0 ? 1 : page.Value;
			var pageSize = 10;
			var lsKhoaHoc = _context.KhoaHocs
									.AsNoTracking()
									.OrderBy(x => x.Id);
			PagedList<KhoaHoc> models = new PagedList<KhoaHoc>(lsKhoaHoc, pageNumber, pageSize);

			ViewBag.CurrentPage = pageNumber;

			return View(models);
		}


		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.KhoaHocs == null)
			{
				return NotFound();
			}

			var khoaHoc = await _context.KhoaHocs
				.FirstOrDefaultAsync(m => m.Id == id);
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
		public async Task<IActionResult> Create([Bind("Id,TenKhoaHoc,MoTa,HinhThuc,UrlImage,idNganhHoc")] KhoaHoc khoaHoc
			, Microsoft.AspNetCore.Http.IFormFile fThumb)
		{

			if (ModelState.IsValid)
			{
				if (fThumb != null)
				{
					string extension = Path.GetExtension(fThumb.FileName);
					string image = Utilities.SEOUrl(khoaHoc.TenKhoaHoc) + extension;
					khoaHoc.UrlImage = await Utilities.UploadFile(fThumb, @"khoahoc", image.ToLower());
				}
				_context.Add(khoaHoc);
				TempData["message"] = "Thêm mới thành công !";
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			ViewBag.NganhHocList = _context.NganhHocs.ToList();
			return View(khoaHoc);
		}


		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.KhoaHocs == null)
			{
				return NotFound();
			}

			var khoaHoc = await _context.KhoaHocs.FindAsync(id);
			if (khoaHoc == null)
			{
				return NotFound();
			}
			ViewBag.NganhHocList = _context.NganhHocs.ToList();
			return View(khoaHoc);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,TenKhoaHoc,MoTa,HinhThuc,UrlImage,idNganhHoc")] KhoaHoc khoaHoc
			, Microsoft.AspNetCore.Http.IFormFile fThumb)
		{
			if (id != khoaHoc.Id)
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
						string image = Utilities.SEOUrl(khoaHoc.TenKhoaHoc) + extension;
						khoaHoc.UrlImage = await Utilities.UploadFile(fThumb, @"khoahoc", image.ToLower());
					}
					_context.Update(khoaHoc);
					TempData["message"] = "Cập nhật thông tin thành công !";
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!KhoaHocExists(khoaHoc.Id))
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
			return View(khoaHoc);
		}



		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.KhoaHocs == null)
			{
				return NotFound();
			}

			var khoaHoc = await _context.KhoaHocs
				.FirstOrDefaultAsync(m => m.Id == id);
			if (khoaHoc == null)
			{
				return NotFound();
			}

			return View(khoaHoc);
		}



		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.KhoaHocs == null)
			{
				return Problem("Entity set 'ApplicationDbContext.KhoaHocs'  is null.");
			}
			var khoaHoc = await _context.KhoaHocs.FindAsync(id);
			if (khoaHoc != null)
			{
				_context.KhoaHocs.Remove(khoaHoc);
			}

			await _context.SaveChangesAsync();
			TempData["message"] = "Xóa thành công !";
			return RedirectToAction(nameof(Index));
		}

		private bool KhoaHocExists(int id)
		{
			return (_context.KhoaHocs?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
