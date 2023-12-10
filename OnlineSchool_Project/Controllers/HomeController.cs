using Microsoft.AspNetCore.Mvc;
using OnlineSchool_Project.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace OnlineSchool_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }  
        
        public IActionResult Dangnhap()
        {
            return View();
        }
        
        public IActionResult Dangky()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}