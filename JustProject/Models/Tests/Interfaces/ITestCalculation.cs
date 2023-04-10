namespace JustProject.Domain.ViewModels
{
    public interface ITestCalculation
    {
        Task<bool> SaveStepTest(IFormCollection model, string name);
    }
}
