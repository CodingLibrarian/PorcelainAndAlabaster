using Microsoft.AspNetCore.Mvc;

namespace PorcelainAndAlabaster.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly ILogger<HomeController> _logger;

        public AdminController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Acquisitons()
        {
            return View();
        }
        public IActionResult Cataloger()
        {
            return View();
        }
        public IActionResult ILLReview()
        {
            return View();
        }
        public IActionResult PatronEdit()
        {
            return View();
        }
        public IActionResult ReferenceGuideEdit()
        {
            return View();
        }
        public IActionResult Settings()
        {
            return View();
        }
        public IActionResult Statistics()
        {
            return View();
        }
        public IActionResult Weeding()
        {
            return View();
        }
    }
}
