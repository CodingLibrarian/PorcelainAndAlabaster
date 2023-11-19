using Microsoft.AspNetCore.Mvc;
using PorcelainAndAlabaster.Models;
using System.Diagnostics;

namespace PorcelainAndAlabaster.Controllers
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
        public IActionResult About()
        {
            return View();
        }
        public IActionResult ILLRequest()
        {
            return View();
        }
        public IActionResult PatronItemsView()
        {
            return View();
        }
        public IActionResult ReferenceGuide()
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