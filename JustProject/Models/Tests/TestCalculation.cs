using JustProject.Domain.Entity;
using JustProject.Domain.Entity.Test;
using JustProject.Models.Tests.Interfaces;
using JustProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectAspMvc.Service.Interfaces;

namespace JustProject.Models.Tests
{
    public class TestCalculation : ITestCalculation
    {
        private readonly ITestResultService _resultService;        
        private readonly IUserTestsService _userTestsService;
        private readonly ITestGroupsService _groupsService;
        private readonly IAnswersService _answersService;
        private readonly IGroupsResultService _groupsResultService;

        public TestCalculation(ITestResultService resultService, IUserTestsService userTestsService,
            ITestGroupsService groupsService, IAnswersService answersService, IGroupsResultService groupsResult)
        {
            _resultService = resultService;            
            _userTestsService = userTestsService;
            _groupsService = groupsService;
            _answersService = answersService;
            _groupsResultService = groupsResult;
        }

        public async Task<bool> SaveStepCommonTest(int testId, int numGroup, int userTestId, IFormCollection model, string groupName)
        {
            var countGroup = await _groupsService.GetTestGroup(testId);            
            var userTest = (await _userTestsService.GetAll()).FirstOrDefault(x => x.Id == userTestId);
            var percent = countGroup.Count() - numGroup;
            double result = (double)percent / countGroup.Count() * 100;
            userTest.Complete = ((int)result - 100) * -1;
            if (await _userTestsService.Update(userTest))
            {
                await SaveResultCommonTest(model, groupName, userTestId, testId, userTest.NameTest);
                return true;
            }                
            return false;
        }
        async Task<bool> SaveResultCommonTest(IFormCollection model, string groupName, int userTestId, int testId, string nameTest)
        {
            int correctCount = 0;            
            foreach (var item in model)
            {
                if (await _answersService.GetCorrectChoose(Convert.ToInt32(item.Value)))
                    correctCount++;
            }
            if (await _groupsResultService.GetCheck(userTestId))
            {
                TestResult saveModel = new TestResult()
                {
                    NameTest = nameTest,
                    UserTestId = userTestId,
                    TestId = testId,                                  
                };
                await _resultService.SaveTest(saveModel);                

                GroupsResult groupsResult = new GroupsResult()
                {
                    GroupCorrectAns = correctCount,
                    GroupName = groupName,
                    UserTestsId = userTestId,
                    TestResultId = saveModel.Id,
                };
                await _groupsResultService.CreateGroup(groupsResult);
            }
            else
            {
                var testResult =  await _resultService.Get(testId, userTestId);

                GroupsResult groupsResult = new GroupsResult()
                {
                    GroupCorrectAns = correctCount,
                    GroupName = groupName,
                    UserTestsId = userTestId,
                    TestResultId = testResult.Id,
                };
                await _groupsResultService.CreateGroup(groupsResult);
            }
            return true;
        }

    }
}
