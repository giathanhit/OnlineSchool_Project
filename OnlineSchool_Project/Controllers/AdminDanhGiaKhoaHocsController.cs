
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using Microsoft.EntityFrameworkCore;
using OnlineSchool_Project.Data;
using OnlineSchool_Project.Models;


namespace OnlineSchool_Project.Controllers
{
	public class AdminDanhGiaKhoaHocsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public AdminDanhGiaKhoaHocsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: AdminDanhGiaKhoaHocs
		public IActionResult Index(int? page)
		{
			var tenDangNhap = HttpContext.Session.GetString("TenDangNhap");

			if (tenDangNhap != null && tenDangNhap == "admin")
			{
				ViewBag.TenDangNhap = tenDangNhap;

				var pageNumber = page == null || page <= 0 ? 1 : page.Value;
				var pageSize = 20;
				var lsDanhGiaMonHoc = _context.DanhGiaMonHocs
										.AsNoTracking()
										.OrderBy(x => x.Id);
				PagedList<DanhGiaKhoaHoc> models = new PagedList<DanhGiaKhoaHoc>(lsDanhGiaMonHoc, pageNumber, pageSize);

				ViewBag.CurrentPage = pageNumber;

				return View(models);
			}
			else
			{
				return RedirectToAction("Dangnhap", "Admin");
			}
		}


		// GET: AdminDanhGiaKhoaHocs/Details/5
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

		// GET: AdminDanhGiaKhoaHocs/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: AdminDanhGiaKhoaHocs/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

		// GET: AdminDanhGiaKhoaHocs/Edit/5
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

		// POST: AdminDanhGiaKhoaHocs/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

		// GET: AdminDanhGiaKhoaHocs/Delete/5
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

		// POST: AdminDanhGiaKhoaHocs/Delete/5
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
			TempData["message"] = "Xóa đánh giá khóa học thành công !";
			ViewBag.message = TempData["message"];
			return RedirectToAction(nameof(Index));
		}

		private bool DanhGiaKhoaHocExists(int id)
		{
			return (_context.DanhGiaMonHocs?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
