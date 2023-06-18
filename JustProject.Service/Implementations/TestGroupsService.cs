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
    public class TestGroupsService : ITestGroupsService
    {
        private readonly TestGroupsRepository _repository;
        public TestGroupsService(TestGroupsRepository repository) 
        {
            _repository = repository; 
        }

        public async Task<IEnumerable<TestGroups>> GetTestGroup(int id)
        {            
            return (await _repository.GetAll()).Where(x => x.TestId == id);
        }

        public async Task<IEnumerable<TestGroups>> GetTestGroups()
        {
            return await _repository.GetAll();
        }
    }
}
