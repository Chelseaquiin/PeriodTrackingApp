using Microsoft.AspNetCore.Mvc;
using PeriodTracker.BLL.Interfaces;
using PeriodTrackerMVC.Models;
using System.Diagnostics;

namespace PeriodTrackerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITrackerService trackerService;

        public HomeController(ILogger<HomeController> logger, ITrackerService trackerService)
        {
            _logger = logger;
            this.trackerService = trackerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetMyNextPeriod()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                var response = await trackerService.GetSafePeriodAsync(userId.Value);
                ViewData["nextPeriod"] = $"your period starts on {response.Result.Item1} and ends on {response.Result.Item2}";

                return View();
            }
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> GetMyFertilityWindow()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                var response = await trackerService.GetFertilityWindowAsync(userId.Value);
                ViewData["nextPeriod"] = $"your period is on {response.Result.Item2}";

                return View();
            }
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> GetMyOvulationDay()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                var response = await trackerService.GetOvulationDayAsync(userId.Value);
                ViewData["nextPeriod"] = $"your period is on {response.Result.Item2}";

                return View();
            }
            return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> GetMySafePeriod()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                var response = await trackerService.GetSafePeriodAsync(userId.Value);
                ViewData["nextPeriod"] = $"your period is on {response.Result.Item2}";

                return View();
            }
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult LogIn()
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