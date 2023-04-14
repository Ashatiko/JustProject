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
    }
}
