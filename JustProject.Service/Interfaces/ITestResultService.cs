using JustProject.Domain.Entity;

namespace JustProject.Service.Interfaces
{
    public interface ITestResultService
    {
        Task<bool> SaveTest(TestResult model);
        Task<IEnumerable<TestResult>> GetAll();
        Task<TestResult> Get(int userTestId);
        Task<TestResult> Get(int testId, int userTestId);
        Task<bool> Update(TestResult testVal);
    }
}
