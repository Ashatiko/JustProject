using JustProject.Domain.ViewModels;
using JustProject.Models.Tests.ViewModel;
using JustProject.Service.Interfaces;

namespace JustProject.Models.Tests
{
    public class TestCalculation : ITestCalculation
    {
        private readonly ITestResultService _resultService;
        public TestCalculation(ITestResultService resultService)
        {
            _resultService = resultService;
        }

        public async Task<bool> SaveStepTest(IFormCollection model, string name)
        {
            var saveModel = new TestStepViewModel();
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
            saveModel.Step = result;
            saveModel.NameTest = name;
            await _resultService.SaveStepTest(saveModel);
            return true;
        }
    }
}
