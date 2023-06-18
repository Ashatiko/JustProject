using JustProject.Domain.Entity.Test;
using JustProject.Domain.ViewModels;
using JustProject.Domain.ViewModels.Tests;
using JustProject.Models.Tests;
using JustProject.Models.Tests.Interfaces;
using JustProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectAspMvc.Service.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

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

        private readonly IAnswersService _answersService;
        private readonly ITestGroupsService _testGroupsService;
        private readonly IQuestionsService _questionsService;
        private readonly IGroupsResultService _groupsResultService;
        
        public TestsController(IUserTestsService userTests, IUserAllowTestService allowTest, IUserService userService,
            ITestCalculation testCalculation, ITestsService testsService, ITestResultService resultService, 
            IAnswersService answersService, ITestGroupsService testGroupsService, IQuestionsService questionsService,
            IGroupsResultService groupsResultService)
        {
            _userTests = userTests;
            _allowTest = allowTest;
            _userService = userService;
            _testCalculation = testCalculation;
            _testsService = testsService;
            _resultService = resultService;
            _answersService = answersService;
            _testGroupsService = testGroupsService;
            _questionsService = questionsService;
            _groupsResultService = groupsResultService;
        }
                
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
                
        public async Task<IActionResult> TypeTest(int id)
        {
            TempData["TestIdBuy"] = id;
            var test = await _testsService.GetTest(id);
            return View(test);
        }

        public async Task<IActionResult> Result()
        {
            int userTestId = (int)HttpContext.Session.GetInt32("UserTestId");
            
            CommonTestResultViewModel resultViewModel = new CommonTestResultViewModel()
            {
                TestResult = await _resultService.Get(userTestId),
                GroupsResult = await _groupsResultService.GetGroup(userTestId)
            };
            return View(resultViewModel);
        }
                
        public async Task<IActionResult> Example(int id)
        {
            var userTest = await _userTests.Get(id);
            HttpContext.Session.SetInt32("UserTestId", id);
            HttpContext.Session.SetInt32("NumGroup", 0);

            if (userTest.Complete > 0)
            {
                List<TestGroups> testGroupsList = (await _testGroupsService.GetTestGroup(await _testsService.GetId(userTest.NameTest))).ToList();                
                
                HttpContext.Session.SetInt32("NumGroup", (int)Math.Ceiling(userTest.Complete * testGroupsList.Count / 100.0));
            }
            else if (userTest.Complete == 100)
                return RedirectToAction("Result", "Tests");            
            return RedirectToAction("CommonTest", "Tests");

        }

        public async Task<IActionResult> CommonTest()    
        {                  
            IEnumerable<Answers> answers = await _answersService.GetAnswers();
            string nameTest = await _userTests.GetName((int)HttpContext.Session.GetInt32("UserTestId"));                       

            List<TestGroups> testGroupsList = (await _testGroupsService.GetTestGroup(await _testsService.GetId(nameTest))).ToList();
            int index = (int)HttpContext.Session.GetInt32("NumGroup");
            if (index >= 0 && index < testGroupsList.Count)
            {
                TestGroups selectedGroup = testGroupsList[index];
                HttpContext.Session.SetString("NameGroup", selectedGroup.GroupName);
                CommonTestsViewModel test = new CommonTestsViewModel()
                {
                    Answers = await _answersService.GetAnswers(),
                    TestGroups = selectedGroup,
                    Questions = await _questionsService.GetQuestions(selectedGroup.TestGroupsId)
                };
                int numGroup = (int)HttpContext.Session.GetInt32("NumGroup");
                HttpContext.Session.SetInt32("NumGroup", ++numGroup);
                return View(test);
            }
            else
            {
                return RedirectToAction("Result", "Tests");
            }
        }

        public async Task<IActionResult> CommonTestResponse(IFormCollection model)
        {            
            await _testCalculation.SaveStepCommonTest(await _testsService.GetId(await _userTests.GetName((int)HttpContext.Session.GetInt32("UserTestId"))),
                (int)HttpContext.Session.GetInt32("NumGroup"), 
                (int)HttpContext.Session.GetInt32("UserTestId"), model,
                HttpContext.Session.GetString("NameGroup"));
            return RedirectToAction("CommonTest","Tests");            
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
            if (User.Identity.IsAuthenticated)
            {                
                switch (HttpContext.Session.GetString("Type"))
                {
                    case "Специалисты":
                        typeTest = await _testsService.GetSpecialistAuth(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
                        break;
                    case "Школьники":
                        typeTest = await _testsService.GetSchoolAuth(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
                        break;
                    case "Организация":
                        typeTest = await _testsService.GetSetAuth(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
                        break;
                    default:
                        typeTest = await _testsService.GetSpecialistAuth(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
                        break;
                }
                return View(typeTest);
            }
            else
            {
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
                return View(typeTest);
            }
            
        }

        [AllowAnonymous]
        public async Task<RedirectToActionResult> BuyTestsType(string type)
        {            
            HttpContext.Session.SetString("Type", type);
            return RedirectToAction("BuyTests","Tests");
        }
    }
}
