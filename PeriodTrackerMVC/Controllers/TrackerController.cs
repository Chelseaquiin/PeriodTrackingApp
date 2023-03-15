using PeriodTracker.BLL.Interfaces;
using PeriodTracker.BLL.Model;
using Microsoft.AspNetCore.Mvc;
using PeriodTracker.DAL.Models;

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
            return View();
        }
        public async Task<IActionResult> FertilityWindow(PeriodDetail periodDetail)
        {
            var response = await _trackerService.FertilityWindowAsync(periodDetail);
            return View();
        }
        public async Task<IActionResult> NextPeriod(PeriodDetail periodDetail)
        {
            var response = await _trackerService.NextPeriodAsync(periodDetail);
            return View();
        }
        public async Task<IActionResult> SafePeriod(PeriodDetail periodDetail)
        {
            var response = await _trackerService.NextPeriodAsync(periodDetail); 
            return View();
        }
        public async Task<IActionResult> OvulationDay(PeriodDetail periodDetail)
        {
            var response = await _trackerService.OvulationDayAsync(periodDetail);
            return View();
        }
    }
}
