using JustProject.DAL.Interfaces;
using JustProject.DAL.Repositories;
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
        private readonly TestResultRepository _testResultRepository;
        public TestResultService(TestResultRepository testResultRepository)
        {
            _testResultRepository = testResultRepository;
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
            var test = (await _testResultRepository.GetAll()).FirstOrDefault(x=>x.NameTest == model.NameTest && x.UserTestId == model.UserTestId);
            if (test == null)
            {
                await _testResultRepository.Create(model);
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}
