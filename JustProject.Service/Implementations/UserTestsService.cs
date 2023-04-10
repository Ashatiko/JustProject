using JustProject.DAL.Interfaces;
using JustProject.Domain.Entity;
using JustProject.Domain.Response;
using JustProject.Domain.ViewModels;
using JustProject.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Service.Implementations
{
    public class UserTestsService : IUserTestsService
    {
        private readonly IBaseRepository<UserTests> _userTestsRepository;
        public UserTestsService(IBaseRepository<UserTests> repository)
        {
            _userTestsRepository = repository;
        }       

        public async Task<IBaseResponse<IEnumerable<UserTests>>> GetAll()
        {
            try
            {
                var baseResponse = new BaseResponse<IEnumerable<UserTests>>();
                return baseResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
