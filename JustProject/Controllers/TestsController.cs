using JustProject.Domain.Entity;
using JustProject.Domain.ViewModels;
using JustProject.Models.Tests;
using JustProject.Models.Tests.Interfaces;
using JustProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAspMvc.Service.Interfaces;

namespace JustProject.Controllers
{
    [Authorize]
    public class TestsController : Controller
    {
        private readonly IUserTestsService _userTests;
        private readonly IUserService _userService;
        private readonly IUserAllowTestService _allowTest;
        private readonly ITestCalculation _testCalculation;
        private readonly ITestsService _testsService;
        private readonly ITestResultService _resultService;
        
        public TestsController(IUserTestsService userTests, IUserAllowTestService allowTest, IUserService userService, ITestCalculation testCalculation, ITestsService testsService, ITestResultService resultService)
        {
            _userTests = userTests;
            _allowTest = allowTest;
            _userService = userService;
            _testCalculation = testCalculation;
            _testsService = testsService;
            _resultService = resultService;
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
        public async Task<IActionResult> TypeTest(int id)
        {
            TempData["TestIdBuy"] = id;
            var test = await _testsService.GetTest(id);
            return View(test);
        }

        public async Task<IActionResult> MotivationTest()
        {
            ViewData["Step"] = "first";
            return View(SchoolTest.TestsViewModel);
        }

        public async Task<IActionResult> Result()
        {
            int? id = HttpContext.Session.GetInt32("ID");

            var test = await _resultService.Get((int)id);
            return View(test);
        }

        [HttpPost]
        public async Task<IActionResult> MotivationTest(IFormCollection model, string stepName)
        {            
            var test = await _userTests.Get((int)HttpContext.Session.GetInt32("ID"));            
            await _testCalculation.SaveStepTest(model, test.NameTest, test.Id);
            if (stepName == "first")
            {
                ViewData["Step"] = "second";
            }
            else if (stepName == "second")
            {
                ViewData["Step"] = "third";
            }
            else if (stepName == "third")
            {
                ViewData["Step"] = "fourth"; 
            }
            else if (stepName == "fourth")
            {
                return RedirectToAction("Result","Tests");
            }
            return View(SchoolTest.TestsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Example(int id)
        {
            var test = await _userTests.Get(id);            
            HttpContext.Session.SetInt32("ID", id);
            if (test.Complete == 100)
            {
                return RedirectToAction("Result", "Tests");
            }
            return View();            
        }

        [HttpGet]
        public async Task<IActionResult> StartTest()
        {
            var test = await _userTests.Get((int)HttpContext.Session.GetInt32("ID"));            
            switch (test.NameTest)
            {
                case "Мотивация":
                    return RedirectToAction("MotivationTest", "Tests");
                case "Социальные качества":
                    return RedirectToAction("Verbal", "Tests");
                case "Личностные качества":
                    return RedirectToAction("Analyt", "Tests");
                case "Сила воли":
                    return RedirectToAction("Analyt", "Tests");
                default:
                    return View();
            }
        }
        
        [AllowAnonymous]
        public async Task<IActionResult> BuyTests(string type)
        {
            IEnumerable<Tests> typeTest;
            if (type != null)
            {
                HttpContext.Session.SetString("Type", type);
            }
            ViewData["Request"] = HttpContext.Session.GetString("Type");
            switch (HttpContext.Session.GetString("Type"))
            {
                case "Специалисты":
                    typeTest = await _testsService.GetSpecialist();
                    break;
                case "Школьники":
                    typeTest = await _testsService.GetSchool();
                    break;
                case "Организация":
                    typeTest = await _testsService.GetSet();
                    break;
                default:
                    typeTest = await _testsService.GetSpecialist();
                    break;
            }
            return View(typeTest );
        }

        [AllowAnonymous]
        public async Task<RedirectToActionResult> BuyTestsType(string type)
        {            
            HttpContext.Session.SetString("Type", type);
            return RedirectToAction("BuyTests","Tests");
        }
    }
}
