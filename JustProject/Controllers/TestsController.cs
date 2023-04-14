using JustProject.Domain.ViewModels;
using JustProject.Models.Tests;
using JustProject.Service.Implementations;
using JustProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectAspMvc.Service.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JustProject.Controllers
{
    public class TestsController : Controller
    {
        private readonly IUserTestsService _userTests;
        private readonly IUserService _userService;
        private readonly IUserAllowTestService _allowTest;
        private readonly ITestCalculation _testCalculation;
        private readonly ITestsService _testsService;
        public TestsController(IUserTestsService userTests, IUserAllowTestService allowTest, IUserService userService, ITestCalculation testCalculation, ITestsService testsService)
        {
            _userTests = userTests;
            _allowTest = allowTest;
            _userService = userService;
            _testCalculation = testCalculation;
            _testsService = testsService;
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
        public async Task<IActionResult> Analyt(int id)
        {
            var asd = new { SchoolTest.TestsViewModel.AnalyticSkills, id };
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
        public async Task<IActionResult> Example(int id)
        {
            var test = await _userTests.Get(id);
            if (test.Complete == 0)
            {
                await _testCalculation.CreateResult(id, test.NameTest);
                return View(id);
            }
            switch (test.NameTest)
            {
                case "Мотивация":                    
                    return RedirectToAction("Analyt", "Tests", test.NameTest);
                    break;
                case "Социальные качества":                    
                    return RedirectToAction("Verbal", "Tests");
                    break;
                case "Личностные качества":                    
                    return RedirectToAction("Analyt", "Tests");
                    break;
                case "Сила воли":                    
                    return RedirectToAction("Analyt", "Tests");
                    break;
                default:
                    return View();
                    break;
            }            
        }

        [HttpGet]
        public async Task<IActionResult> BuyTests()
        {
            var tests = await _testsService.GetAll();
            return View(tests);
        }        
    }
}
