using JustProject.DAL.Repositories;
using JustProject.Domain.Entity.Test;
using JustProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Service.Implementations
{
    public class TestsService : ITestsService
    {
        private readonly TestsRepository _repository;
        private readonly UserTestsRepository _userTestsRepository;
        public TestsService(TestsRepository repository, UserTestsRepository userTestsRepository)
        {
            _repository = repository;
            _userTestsRepository = userTestsRepository;
        }
        public async Task<IEnumerable<Tests>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<int> GetId(string testName)
        {
            return (await _repository.GetAll()).FirstOrDefault(x=>x.NameTest == testName).Id;
        }

        public async Task<IEnumerable<Tests>> GetSchool()
        {
            return (await _repository.GetAll()).Where(x=>x.Type == "Школьник");
        }

        public async Task<IEnumerable<Tests>> GetSchoolAuth(int userId)
        {
            var testAdded = (await _userTestsRepository.GetAll())
                .Where(x => x.UserTestId == userId)
                .Select(x => x.NameTest);

            var allTests = await _repository.GetAll();
            IEnumerable<string> allTestNames = allTests.Select(x => x.NameTest);
            IEnumerable<string> rightTestNames = allTestNames.Except(testAdded);
            return allTests.Where(x => rightTestNames.Contains(x.NameTest) && x.Type == "Школьник");
        }

        public async Task<IEnumerable<Tests>> GetSet()
        {
            return (await _repository.GetAll()).Where(x => x.Type == "Организация");
        }

        public async Task<IEnumerable<Tests>> GetSetAuth(int userId)
        {
            var testAdded = (await _userTestsRepository.GetAll())
                .Where(x => x.UserTestId == userId)
                .Select(x => x.NameTest);

            var allTests = await _repository.GetAll();
            IEnumerable<string> allTestNames = allTests.Select(x => x.NameTest);
            IEnumerable<string> rightTestNames = allTestNames.Except(testAdded);
            return allTests.Where(x => rightTestNames.Contains(x.NameTest) && x.Type == "Организация");
        }

        public async Task<IEnumerable<Tests>> GetSpecialist()
        {
            return (await _repository.GetAll()).Where(x => x.Type == "Специалисты");
        }

        public async Task<IEnumerable<Tests>> GetSpecialistAuth(int userId)
        {
            var testAdded = (await _userTestsRepository.GetAll())
                .Where(x => x.UserTestId == userId)
                .Select(x => x.NameTest);

            var allTests = await _repository.GetAll();
            IEnumerable<string> allTestNames = allTests.Select(x => x.NameTest);
            IEnumerable<string> rightTestNames = allTestNames.Except(testAdded);
            return allTests.Where(x => rightTestNames.Contains(x.NameTest) && x.Type == "Специалисты");
        }

        public async Task<Tests> GetTest(int id)
        {
            return (await _repository.GetAll()).FirstOrDefault(test => test.Id == id);
        }
    }
}
