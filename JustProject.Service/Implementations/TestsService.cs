using JustProject.DAL.Repositories;
using JustProject.Domain.Entity;
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
        public TestsService(TestsRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Tests>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<IEnumerable<Tests>> GetSchool()
        {
            return (await _repository.GetAll()).Where(x=>x.Type == "Школьник");
        }

        public async Task<IEnumerable<Tests>> GetSet()
        {
            return (await _repository.GetAll()).Where(x => x.Type == "Организация");
        }

        public async Task<IEnumerable<Tests>> GetSpecialist()
        {
            return (await _repository.GetAll()).Where(x => x.Type == "Специалисты");
        }

        public async Task<Tests> GetTest(int id)
        {
            return (await _repository.GetAll()).FirstOrDefault(test => test.Id == id);
        }
    }
}
