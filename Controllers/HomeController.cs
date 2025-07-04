using FoodWasteManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodWasteManager.Controllers
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

        public IActionResult HowToOperate() // returns the HowToOperate view if asp-action is "HowToOperate" and selected
        {
            return View();
        }

        public IActionResult Community() //returns the Community view
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
