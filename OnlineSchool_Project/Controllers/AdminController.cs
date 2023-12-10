using Microsoft.AspNetCore.Mvc;
using OnlineSchool_Project.Data;

namespace OnlineSchool_Project.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        { 
            return View();
        }

        public IActionResult Dangnhap()
        {
            return View();
        }
         
    }
}
