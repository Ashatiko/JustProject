using JustProject.Domain.ViewModels;
using JustProject.Models.Tests;
using JustProject.Service.Implementations;
using JustProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectAspMvc.Service.Interfaces;

namespace JustProject.Controllers
{
    public class TestsController : Controller
    {
        private readonly IUserTestsService _userTests;
        private readonly IUserService _userService;
        private readonly IUserAllowTestService _allowTest;
        private readonly ITestCalculation _testCalculation;
        public TestsController(IUserTestsService userTests, IUserAllowTestService allowTest, IUserService userService, ITestCalculation testCalculation)
        {
            _userTests = userTests;
            _allowTest = allowTest;
            _userService = userService;
            _testCalculation = testCalculation; 
        }

        [HttpGet]
        public async Task<IActionResult> LoginTest()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginTest(LoginTestViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool loginTest = await _allowTest.Login(model);
                if (loginTest)
                {
                    await _userService.LoginTest();
                    return RedirectToAction("HistoryTests", "User");
                }
                return View(model);
            }
            return View(model);

        }

        [HttpGet]
        public async Task<IActionResult> TypeTest()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Analyt()
        {
            return View(SchoolTest.TestsViewModel.AnalyticSkills);
        }

        [HttpPost]
        public async Task<IActionResult> Analyt(IFormCollection model )
        {
            if (await _testCalculation.SaveStepTest(model, "Analytical") == true)
            {
                return RedirectToAction("Verbal","Tests");
            }
            return View(SchoolTest.TestsViewModel.AnalyticSkills);
        }

        [HttpGet]
        public async Task<IActionResult> Verbal()
        {
            return View(SchoolTest.TestsViewModel.VerbalSkills);
        }

        [HttpPost]
        public async Task<IActionResult> Verbal(IFormCollection model)
        {
            if (await _testCalculation.SaveStepTest(model, "Verbal") == true)
            {
                return RedirectToAction("Verbal", "Tests");
            }
            return View(SchoolTest.TestsViewModel.AnalyticSkills);
        }

        [HttpGet]
        public async Task<IActionResult> Example()
        {
            return View();
        }
    }
}
