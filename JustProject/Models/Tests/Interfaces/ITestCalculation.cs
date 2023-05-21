namespace JustProject.Models.Tests.Interfaces
{
    public interface ITestCalculation
    {
        Task<bool> SaveStepTest(IFormCollection model, string name, int id);
        Task<bool> CreateResult(int userId, string nameTest);
    }
}
