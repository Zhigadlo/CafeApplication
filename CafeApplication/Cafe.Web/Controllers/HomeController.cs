using Cafe.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cafe.Web.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error(string[] errors)
        {
            return View(errors);
        }

    }
}