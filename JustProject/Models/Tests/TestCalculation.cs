using JustProject.Domain.Entity;
using JustProject.Domain.ViewModels;
using JustProject.Models.Tests.ViewModel;
using JustProject.Service.Interfaces;
using ProjectAspMvc.Service.Interfaces;

namespace JustProject.Models.Tests
{
    public class TestCalculation : ITestCalculation
    {
        private readonly ITestResultService _resultService;
        private readonly IUserService _userService;
        private readonly IUserTestsService _userTestsService;
        public TestCalculation(ITestResultService resultService,IUserService userService, IUserTestsService userTestsService)
        {
            _resultService = resultService;
            _userService = userService;
            _userTestsService = userTestsService;
        }

        public async Task<bool> CreateResult(int userId, string nameTest)
        {
            TestResult saveModel = new TestResult()
            {
                NameTest = nameTest,
                UserTestId = userId,                
            };
            await _resultService.SaveTest(saveModel);
            return true;
        }

        public async Task<bool> SaveStepTest(IFormCollection model, string name)
        {
            var user = await _userService.GetUser();
            var testVal = (await _resultService.GetAll()).FirstOrDefault(x=>x.UserTestId == user.Data.Id && x.NameTest == name);
            int result = 0;
            foreach (var answer in model)
            {
                foreach (var test in SchoolTest.TestsViewModel.AnalyticSkills)
                {
                    if (Convert.ToInt32(answer.Value) == test.CorrectChoiceIndex)
                    {
                        result++;
                    }
                }
            }
            if (testVal == null)
            {                
                TestResult saveModel = new TestResult()
                {
                    NameTest = name,
                    UserTestId = user.Data.Id,
                    FirstStep = result
                };
                await _resultService.SaveTest(saveModel);
                return true;
            }
            else
            {
                var userTest = (await _userTestsService.GetAll()).FirstOrDefault(x=>x.UserTestId == user.Data.Id);
                if (testVal.FirstStep == 0)
                {
                    testVal.SecondStep = result;
                    userTest.Complete = 25;                    
                }
                return true;
            }            
        }
    }
}
