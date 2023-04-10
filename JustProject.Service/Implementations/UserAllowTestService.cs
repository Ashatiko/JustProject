using JustProject.DAL.Interfaces;
using JustProject.DAL.Repositories;
using JustProject.Domain.Entity;
using JustProject.Domain.ViewModels;
using JustProject.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Service.Implementations
{
    public class UserAllowTestService : IUserAllowTestService
    {
        private readonly IBaseRepository<UserAllowTest> _repository;
        public UserAllowTestService(IBaseRepository<UserAllowTest> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Login(LoginTestViewModel model)
        {
            try
            {
                var loginTest = (await _repository.GetAll()).FirstOrDefault(x=>x.Login == model.Login && x.Password == model.Password );
                if (loginTest != null) return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
