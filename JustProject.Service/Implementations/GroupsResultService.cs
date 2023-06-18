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
    public class GroupsResultService : IGroupsResultService
    {
        private readonly GroupsResultRepository _repository;
        public GroupsResultService(GroupsResultRepository groupsResultRepository) 
        {
            _repository = groupsResultRepository;
        }

        public async Task<bool> CreateGroup(GroupsResult groupsResult)
        {
            if (await _repository.Create(groupsResult))
                return true;
            return false;
            
        }

        public async Task<bool> GetCheck(int userTestId)
        {
            if ((await _repository.GetAll()).FirstOrDefault(x => x.UserTestsId == userTestId) == null)
                return true;
            return false;
        }

        public async Task<IEnumerable<GroupsResult>> GetGroup(int userTestId)
        {
            return (await _repository.GetAll()).Where(x => x.UserTestsId == userTestId);
        }

        public async Task<IEnumerable<GroupsResult>> GetGroups()
        {
            return await _repository.GetAll();
        }
    }
}
