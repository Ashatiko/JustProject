using JustProject.DAL.Interfaces;
using JustProject.Domain.Entity;
using JustProject.Models.Tests.ViewModel;
using JustProject.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Service.Implementations
{
    public class TestResultService : ITestResultService
    {
        private readonly IBaseRepository<TestResult> _testResultRepository;
        public TestResultService(IBaseRepository<TestResult> testResultRepository)
        {
            _testResultRepository = testResultRepository;
        }

        public async Task<bool> SaveStepTest(TestStepViewModel model)
        {
            TestResult test = new TestResult()
            {
                NameTest = model.NameTest,
                FirstStep = model.Step,
                SecondStep = model.Step,
                ThirdStep = model.Step,
                FourthStep = model.Step,
                Result = model.Result
            };
            await _testResultRepository.Create(test);
            return true;
        }
    }
}
