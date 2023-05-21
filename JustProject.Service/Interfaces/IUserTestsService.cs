using JustProject.DAL.Interfaces;
using JustProject.Domain.Entity;
using JustProject.Domain.Response;
using JustProject.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Service.Interfaces
{
    public interface IUserTestsService
    {
        Task<IEnumerable<UserTests>> GetAll();
        Task<UserTests> Get(int id);
        Task<bool> Update(UserTests userTests);
    }
}
