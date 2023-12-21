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
	public class AdminGiangVienController : Controller
	{
		private readonly ApplicationDbContext _context;

		public AdminGiangVienController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index(int? page)
		{
			var tenDangNhap = HttpContext.Session.GetString("TenDangNhap");

			if (tenDangNhap != null && tenDangNhap == "admin")
			{
				ViewBag.TenDangNhap = tenDangNhap;

				var pageNumber = page == null || page <= 0 ? 1 : page.Value;
				var pageSize = 10;
				var lsGiangVien = _context.GiangViens
										.AsNoTracking()
										.OrderBy(x => x.Id);
				PagedList<GiangVien> models = new PagedList<GiangVien>(lsGiangVien, pageNumber, pageSize);

				ViewBag.CurrentPage = pageNumber;

				return View(models);
			}
			else
			{
				return RedirectToAction("Dangnhap","Admin");
			}
		}


		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.GiangViens == null)
			{
				return NotFound();
			}

			var giangVien = await _context.GiangViens
				.FirstOrDefaultAsync(m => m.Id == id);
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
		public async Task<IActionResult> Create([Bind("Id,HoTen,Email,CCCD,Sdt,BangCap,DiaChi,GioiTinh,UrlImage,NgaySinh,idNganhHoc")] GiangVien giangVien
			, Microsoft.AspNetCore.Http.IFormFile fThumb)
		{

			if (ModelState.IsValid)
			{
				if (fThumb != null)
				{
					string extension = Path.GetExtension(fThumb.FileName);
					string image = Utilities.SEOUrl(giangVien.HoTen) + extension;
					giangVien.UrlImage = await Utilities.UploadFile(fThumb, @"giangvien", image.ToLower());
				}
				_context.Add(giangVien);
				TempData["message"] = "Thêm mới thành công !";
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			ViewBag.NganhHocList = _context.NganhHocs.ToList();
			return View(giangVien);
		}


		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.GiangViens == null)
			{
				return NotFound();
			}

			var giangVien = await _context.GiangViens.FindAsync(id);
			if (giangVien == null)
			{
				return NotFound();
			}
			ViewBag.NganhHocList = _context.NganhHocs.ToList();
			return View(giangVien);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,HoTen,Email,CCCD,Sdt,BangCap,DiaChi,GioiTinh,UrlImage,NgaySinh,idNganhHoc")] GiangVien giangVien
			, Microsoft.AspNetCore.Http.IFormFile fThumb)
		{
			if (id != giangVien.Id)
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
						string image = Utilities.SEOUrl(giangVien.HoTen) + extension;
						giangVien.UrlImage = await Utilities.UploadFile(fThumb, @"giangvien", image.ToLower());
					}
					_context.Update(giangVien);
					TempData["message"] = "Cập nhật thông tin thành công !";
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!GiangVienExists(giangVien.Id))
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
			return View(giangVien);
		}



		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.GiangViens == null)
			{
				return NotFound();
			}

			var giangVien = await _context.GiangViens
				.FirstOrDefaultAsync(m => m.Id == id);
			if (giangVien == null)
			{
				return NotFound();
			}

			return View(giangVien);
		}



		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.GiangViens == null)
			{
				return Problem("Entity set 'ApplicationDbContext.GiangViens'  is null.");
			}
			var giangVien = await _context.GiangViens.FindAsync(id);
			if (giangVien != null)
			{
				_context.GiangViens.Remove(giangVien);
			}

			await _context.SaveChangesAsync();
			TempData["message"] = "Xóa thành công !";
			return RedirectToAction(nameof(Index));
		}

		private bool GiangVienExists(int id)
		{
			return (_context.GiangViens?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
