
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;
using PagedList.Core;

namespace OnlineSchool_Project.Controllers
{
	public class AdminChuongHocController : Controller
	{
		private readonly ApplicationDbContext _context;

		public AdminChuongHocController(ApplicationDbContext context)
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
				var lsChuongHoc = _context.ChuongHocs
										.AsNoTracking()
										.OrderBy(x => x.Id);
				PagedList<ChuongHoc> models = new PagedList<ChuongHoc>(lsChuongHoc, pageNumber, pageSize);

				ViewBag.CurrentPage = pageNumber;

				return View(models);
			}
			else
			{
				return RedirectToAction("Dangnhap", "Admin");
			}
		}


		public async Task<IActionResult> Details(int? id)
		{
			ViewBag.KhoaHocList = _context.KhoaHocs.ToList();
			if (id == null || _context.ChuongHocs == null)
			{
				return NotFound();
			}

			var chuongHoc = await _context.ChuongHocs
				.FirstOrDefaultAsync(m => m.Id == id);
			if (chuongHoc == null)
			{
				return NotFound();
			}

			return View(chuongHoc);
		}

		public IActionResult Create()
		{
			ViewBag.KhoaHocList = _context.KhoaHocs.ToList();
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,TenChuongHoc,MoTa,idKhoaHoc")] ChuongHoc chuongHoc)
		{
			ViewBag.KhoaHocList = _context.KhoaHocs.ToList();
			if (ModelState.IsValid)
			{
				_context.Add(chuongHoc);
				TempData["message"] = "Thêm mới chương học thành công !";
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(chuongHoc);
		}


		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.ChuongHocs == null)
			{
				return NotFound();
			}

			var chuongHoc = await _context.ChuongHocs.FindAsync(id);
			if (chuongHoc == null)
			{
				return NotFound();
			}
			ViewBag.KhoaHocList = _context.KhoaHocs.ToList();
			return View(chuongHoc);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,TenChuongHoc,MoTa,idKhoaHoc")] ChuongHoc chuongHoc)
		{
			if (id != chuongHoc.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(chuongHoc);
					TempData["message"] = "Cập nhật thông tin chương học thành công !";
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ChuongHocExists(chuongHoc.Id))
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
			return View(chuongHoc);
		}


		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.ChuongHocs == null)
			{
				return NotFound();
			}

			var chuongHoc = await _context.ChuongHocs
				.FirstOrDefaultAsync(m => m.Id == id);
			if (chuongHoc == null)
			{
				return NotFound();
			}
			ViewBag.KhoaHocList = _context.KhoaHocs.ToList();
			return View(chuongHoc);
		}


		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.ChuongHocs == null)
			{
				return Problem("Entity set 'ApplicationDbContext.ChuongHocs'  is null.");
			}
			var chuongHoc = await _context.ChuongHocs.FindAsync(id);
			if (chuongHoc != null)
			{
				_context.ChuongHocs.Remove(chuongHoc);
			}

			await _context.SaveChangesAsync();
			TempData["message"] = "Xóa thành công !";
			return RedirectToAction(nameof(Index));
		}

		private bool ChuongHocExists(int id)
		{
			return (_context.ChuongHocs?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
