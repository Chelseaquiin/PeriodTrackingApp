using PeriodTracker.BLL.Interfaces;
using PeriodTracker.BLL.Model;
using Microsoft.AspNetCore.Mvc;
using PeriodTracker.DAL.Models;
using System.Reflection.Metadata.Ecma335;

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
        public async Task<IActionResult> FertilityWindow(PeriodDetailsVM periodDetail)
        {
            var response = await _trackerService.FertilityWindowAsync(periodDetail);
            return View();
        }
        [HttpPost]
        public IActionResult GetNextPeriod(string lastPeriodStartDateString, byte cycleLength, byte periodLength)
        {
            var lastPeriodStartDate = DateTime.Parse(lastPeriodStartDateString);
            var response =  _trackerService.GetNextPeriod(lastPeriodStartDate, cycleLength, periodLength);
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
        public IActionResult NextPeriod()
        {
            var model = TempData["errorMessage"];
            return View(model);
        }
        
        public async Task<IActionResult> SafePeriod(PeriodDetailsVM periodDetail)
        {
            /*var response = await _trackerService.GetNext(periodDetail);
            if (response.IsSuccessful)
            {
                TempData["user"] = response.Result.LastPeriod;
                return View(response);
            }
            else
            {
                TempData["errorMessage"] = response.Message;
                return View("SafePeriod");
            }*/
            return View();
            
        }
        public async Task<IActionResult> OvulationDay(PeriodDetailsVM periodDetail)
        {
            /*var response = await _trackerService.OvulationDayAsync(periodDetail);
            if (response.IsSuccessful)
            {
                TempData["user"] = response.Result.LastPeriod;
                return View(response);
            }
            else
            {
                TempData["errorMessage"] = response.Message;
                return View("SafePeriod");
            }*/
            return View();
        }
    }
}
