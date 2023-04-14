using JustProject.Domain.Response;
using JustProject.Domain.ViewModels;
using JustProject.Service.Implementations;
using JustProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectAspMvc.Service.Interfaces;
using static System.Net.Mime.MediaTypeNames;

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

        [AllowAnonymous]
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
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
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
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _userService.Register(model);
                return RedirectToAction("Login", "User");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<ActionResult> LoginTest()
        {
            var user = await _userService.GetUser();
            return View(user.Data);
        }

        [HttpGet]
        public async Task<IActionResult> HistoryTests(int id)
        {
            if (id == 0)
            {
                var tests = await _userService.GetHistoryTest();

                return View(tests);
            }
            var testsAdd = await _userService.GetHistoryTestAdd(id);

            return View(testsAdd);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var tests = await _userService.GetHistoryTestDelete(id);
            if (tests == true)
            {
                return RedirectToAction("HistoryTests");
            }
            return RedirectToAction("HistoryTests");
        }

        [Authorize]        
        public async Task<IActionResult> Results()
        {
            var user = await _userService.GetUser();
            return View(user.Data);
        }

        
        public async Task<IActionResult> Consultation()
        {
            var user = await _userService.GetUser();
            return View(user.Data);
        }        
    }
}
