using JustProject.DAL.Repositories;
using JustProject.Domain.Entity;
using JustProject.Service.Interfaces;

namespace JustProject.Service.Implementations
{
    public class TestResultService : ITestResultService
    {
        private readonly TestResultRepository _testResultRepository;
        public TestResultService(TestResultRepository testResultRepository)
        {
            _testResultRepository = testResultRepository;
        }

        public async Task<TestResult> Get(int userTestId)
        {
            return (await _testResultRepository.GetAll()).FirstOrDefault(x=>x.UserTestId == userTestId);
        }

        public async Task<TestResult> Get(int testId, int userTestId)
        {            
            return (await _testResultRepository.GetAll()).FirstOrDefault(x => x.UserTestId == userTestId && x.TestId == testId);
        }

        public async Task<IEnumerable<TestResult>> GetAll()
        {
            try
            {
                var results = await _testResultRepository.GetAll();
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SaveTest(TestResult model)
        {
            var test = (await _testResultRepository.GetAll()).FirstOrDefault(x=>x.Id == model.TestId);
            if (test == null)
            {
                await _testResultRepository.Create(model);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> Update(TestResult testVal)
        {
            await _testResultRepository.Update(testVal);
            return true;
        }
    }
}
