using Microsoft.AspNetCore.Mvc;
using PeriodTracker.BLL.Interfaces;

namespace PeriodTrackerMVC.Controllers
{
    public class TrackerController : Controller
    {
        private readonly ITrackerService _trackerService;
        public TrackerController(ITrackerService trackerService)
        {
            _trackerService = trackerService;
        }
        public IActionResult Index()
        {
            var model = TempData["period"];
            return View(model);
        }
        [HttpPost]
        public IActionResult GetFertilityWindow(string lastPeriodStartDateString)
        {
            var lastPeriodStartDate = DateTime.Parse(lastPeriodStartDateString);
            var response = _trackerService.GetFertilityWindow(lastPeriodStartDate);
            if (response.IsSuccessful)
            {
                TempData["fertilityPeriod"] = $"Your fertility window starts on {response.Result.startDate} and ends on {response.Result.endDate}";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["errorMessage"] = response.Message;
                return View("NextPeriod");
            }
        }
        [HttpPost]
        public IActionResult GetNextPeriod(string lastPeriodStartDateString, byte cycleLength, byte periodLength)
        {
            var lastPeriodStartDate = DateTime.Parse(lastPeriodStartDateString);
            var response = _trackerService.GetNextPeriod(lastPeriodStartDate, cycleLength, periodLength);
            if (response.IsSuccessful)
            {
                TempData["period"] = $"Your next period starts on {response.Result.startDate} and ends on {response.Result.endDate}";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["errorMessage"] = response.Message;
                return View("NextPeriod");
            }

        }
        public IActionResult GetNextPeriod()
        {
            var model = TempData["errorMessage"];
            return View(model);
        }
        public IActionResult GetOvulationDay()
        {
            var model = TempData["errorMessage"];
            return View(model);
        }
        public IActionResult GetSafePeriod()
        {
            var model = TempData["errorMessage"];
            return View(model);
        }
        public IActionResult GetFertilityWindow()
        {
            var model = TempData["errorMessage"];
            return View(model);
        }

        [HttpPost]
        public IActionResult GetSafePeriod(string lastPeriodStartDateString, byte cycleLength)
        {
            var safeDate = DateTime.Parse(lastPeriodStartDateString);
            var response = _trackerService.GetSafePeriod(safeDate, cycleLength);
            if (response.IsSuccessful)
            {
                TempData["safePeriod"] = $"Your safe period starts on {response.Result.Item1} and ends on {response.Result.Item2}";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["errorMessage"] = response.Message;
                return View("NextPeriod");
            }

        }
        [HttpPost]
        public IActionResult GetOvulationDay(string lastPeriodStartDateString)
        {
            var ovulationDate = DateTime.Parse(lastPeriodStartDateString);
            var response = _trackerService.GetOvulationDay(ovulationDate);
            if (response.IsSuccessful)
            {
                TempData["ovulationPeriod"] = $"Your ovulation day is on {response.Result}";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["errorMessage"] = response.Message;
                return View("NextPeriod");
            }

        }
    }
}
