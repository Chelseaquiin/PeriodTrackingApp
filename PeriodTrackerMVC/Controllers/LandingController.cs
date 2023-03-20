using Microsoft.AspNetCore.Mvc;
using PeriodTracker.BLL.Implementation;
using PeriodTracker.BLL.Interfaces;
using PeriodTracker.BLL.Model;

namespace PeriodTrackerMVC.Controllers
{
    public class LandingController : Controller
    {
        private readonly ITrackerService _trackerService;
        public LandingController(ITrackerService trackerService)
        {
            _trackerService = trackerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetNextPeriod(BasePeriodDetailsVM periodDetails)
        {
            if (!ModelState.IsValid)
                return View("Index", periodDetails);

            var lastPeriodStartDate = DateTime.Parse(periodDetails.LastPeriod);

            var response = _trackerService.GetNextPeriod(
                lastPeriodStartDate,
                periodDetails.CycleLength,
                periodDetails.PeriodLength);

            if (response.IsSuccessful)
            {
                ViewBag.nextPeriod = $"Your next period starts on {response.Result.startDate} and ends on {response.Result.endDate}";
                return View("Index");

            }
            else
            {
                ViewData["errorMessage"] = response.Message;
                return View("Index");
            }

        }
        public IActionResult GetFertilityWindow(BasePeriodDetailsVM periodDetails)
        {
            if (!ModelState.IsValid)
                return View("Index", periodDetails);

            var lastPeriodStartDate = DateTime.Parse(periodDetails.LastPeriod);

            var response = _trackerService.GetFertilityWindow(lastPeriodStartDate);
            if (response.IsSuccessful)
            {

                ViewBag.fertilityWindow = $"Your fertility window starts on {response.Result.startDate} and ends on {response.Result.endDate}";
                return View("Index");

            }
            else
            {
                ViewData["errorMessage"] = response.Message;
                return View("Index");
            }

        }
        public async Task<IActionResult> GetMyOvulationDay()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                var response = await _trackerService.GetOvulationDayAsync(userId.Value);
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
                var response = await _trackerService.GetSafePeriodAsync(userId.Value);
                ViewData["nextPeriod"] = $"your period is on {response.Result.Item2}";

                return View();
            }
            return View("Index");
        }


    }
}
