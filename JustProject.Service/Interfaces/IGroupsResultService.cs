using JustProject.Domain.Entity.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Service.Interfaces
{
    public interface IGroupsResultService
    {
        Task<bool> CreateGroup(GroupsResult groupsResult);
        Task<bool> GetCheck(int userTestId);
        Task<IEnumerable<GroupsResult>> GetGroup(int userTestId);
        Task<IEnumerable<GroupsResult>> GetGroups();
    }
}
