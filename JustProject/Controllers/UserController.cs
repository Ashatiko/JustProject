using JustProject.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ProjectAspMvc.Service.Interfaces;

namespace JustProject.Controllers
{
    public class UserController : Controller
    {

        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Account", "User");
            }
            return RedirectToAction("Account", "User");
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
            return View();
        }

        public async Task<IActionResult> HistoryTests()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Results()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Consultation()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Account()
        {
            return View();
        }
    }
}
