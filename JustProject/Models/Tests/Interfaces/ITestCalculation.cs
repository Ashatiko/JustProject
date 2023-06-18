namespace JustProject.Models.Tests.Interfaces
{
    public interface ITestCalculation
    {
        Task<bool> SaveStepCommonTest(int testId, int numGroup, int userTestId, IFormCollection model, string groupName);        
    }
}
