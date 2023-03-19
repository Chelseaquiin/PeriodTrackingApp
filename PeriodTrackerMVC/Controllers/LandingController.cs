using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetNextPeriod(PeriodDetailsVM periodDetails)
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
    }
}
