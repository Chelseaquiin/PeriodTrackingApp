using Microsoft.AspNetCore.Mvc;

namespace PeriodTrackerMVC.Controllers
{
    public class DisplayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DisplaySafePeriod()
        {
            return View();
        }
        public IActionResult DisplayOvulationDay()
        {
            return View();
        }
        public IActionResult DisplayNextPeriod()
        {
            return View();
        }
        public IActionResult DisplayFertilityWindow()
        {
            return View();
        }
    }
}
