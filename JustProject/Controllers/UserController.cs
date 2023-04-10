using JustProject.Domain.Response;
using JustProject.Domain.ViewModels;
using JustProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectAspMvc.Service.Interfaces;

namespace JustProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserTestsService _userTests;
        public UserController(IUserService userService, IUserTestsService userTests)
        {
            _userService = userService;
            _userTests = userTests;
        }

        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> LogOut()
        {
            var auther = await _userService.LogOut();
            if (auther == true) return RedirectToAction("Login", "User");
            return RedirectToAction("Account", "User");
        }

        [HttpPost]        
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userbool = await _userService.Login(model);
                if (userbool == false) return View(model);
                return RedirectToAction("Account", "User");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Account()
        {
            var user = await _userService.GetUser();
            return View(user.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Account(AccountViewModel model)
        {
            var user = await _userService.GetEditUser(model);
            return View(user.Data);
        }

        [HttpGet]
        public async Task<ActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string models)
        {
            return RedirectToAction("Account", "User");
        }


        [HttpGet]
        public async Task<ActionResult> LoginTest()
        {
            var user = await _userService.GetUser();
            return View(user.Data);
        }

        [HttpGet]
        public async Task<IActionResult> HistoryTests()
        {            
            var tests = await _userService.GetHistoryTest();

            return View(tests);
        }

        [HttpGet]
        public async Task<IActionResult> Results()
        {
            var user = await _userService.GetUser();
            return View(user.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Consultation()
        {
            var user = await _userService.GetUser();
            return View(user.Data);
        }        
    }
}
