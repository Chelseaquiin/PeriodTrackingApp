using Microsoft.AspNetCore.Mvc;
using PeriodTracker.BLL.Interfaces;
using PeriodTracker.BLL.Model;

namespace PeriodTrackerMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LogIn(string email, string password)
        {
            if(!ModelState.IsValid)
            {
                return Problem("Incorrect email or Password");
            }

            bool response = await _userService.LogInAsync(email, password);
            return View(response);
        }

        public IActionResult LogOut()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserVM user)
        {

            var response = await _userService.SignUpAsync(user);
            return View();
        }
    }
}
