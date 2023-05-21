using JustProject.Domain.Entity;
using JustProject.Models.Tests.Interfaces;
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

        public async Task<bool> SaveStepTest(IFormCollection model, string name, int id)
        {
            var user = await _userService.GetUser();
            var testVal = (await _resultService.GetAll()).FirstOrDefault(x=>x.UserTestId == user.Data.Id && x.TestId == id);
            var userTest = (await _userTestsService.GetAll()).FirstOrDefault(x => x.Id == id);
            int result = 0;
            foreach (var answer in model)
            {
                if (answer.Key != "stepName")
                {
                    foreach (var test in SchoolTest.TestsViewModel.AnalyticSkills)
                    {
                        if (Convert.ToInt32(answer.Value) == test.CorrectChoiceIndex)
                        {
                            result++;
                        }
                    }
                }
            }
            if (testVal == null)
            {                
                TestResult saveModel = new TestResult()
                {
                    NameTest = name,
                    UserTestId = user.Data.Id,
                    TestId = id,
                    FirstStep = result,
                    SecondStep = 77,
                    ThirdStep = 77,
                    FourthStep = 77,
                };
                userTest.Complete = 25;
                await _userTestsService.Update(userTest);
                await _resultService.SaveTest(saveModel);
                return true;
            }
            else
            {
                if (testVal.SecondStep == 77)
                {
                    testVal.SecondStep = result;
                    userTest.Complete = 50;
                }
                else if (testVal.ThirdStep == 77)
                {
                    testVal.ThirdStep = result;
                    userTest.Complete = 75;
                }
                else if (testVal.FourthStep == 77)
                {
                    testVal.FourthStep = result;
                    userTest.Complete = 100;
                    testVal.Result = testVal.FirstStep + testVal.SecondStep + testVal.ThirdStep + testVal.FourthStep;
                }
                else 
                {
                    testVal.Result = testVal.FirstStep + testVal.SecondStep + testVal.ThirdStep + testVal.FourthStep;
                    userTest.Complete = 100;
                }
                await _resultService.Update(testVal);
                await _userTestsService.Update(userTest);
                return true;
            }            
        }
    }
}
