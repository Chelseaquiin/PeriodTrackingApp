using Microsoft.AspNetCore.Mvc;
using PeriodTracker.BLL.Interfaces;
using PeriodTracker.BLL.Model;

namespace PeriodTrackerMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(string email, string password)
        {

            var response = await _authService.LogInAsync(email, password);
            if (response.IsSuccessful)
            {
                HttpContext.Session.SetInt32("UserId", response.Result.Id);
                TempData["user"] = response.Result.UserName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["errorMessage"] = response.Message;
                return View("LogIn");
            }
            
        }
        public IActionResult LogIn()
        {
            var model = TempData["errorMessage"];
            return View(model);
        }

        public IActionResult LogOut()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserVM user)
        {

            var response = await _authService.SignUpAsync(user);
            if (!response.IsSuccessful)
            {
                return Ok(response.Message);
            }
            else
            {
                HttpContext.Session.SetInt32("UserId", response.Result.Id);
                TempData["user"] = response.Result.UserName;

                return RedirectToAction("Index", "Home");
            }

        }
        public IActionResult SignUp()
        {
            return View();
        }

    }
}
