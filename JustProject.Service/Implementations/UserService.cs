
using Microsoft.EntityFrameworkCore;
using JustProject.DAL.Interfaces;
using JustProject.Domain.Entity;
using JustProject.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustProject;
using JustProject.Domain.ViewModels;
using ProjectAspMvc.Service.Interfaces;

namespace JustProject.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;                
        public UserService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IBaseResponse<User>> Login(LoginViewModel model)
        {
            var baseResponse = new BaseResponse<User>();
            if (model.Email == null || model.Password == null)
            {
                return baseResponse;
            }

            //var user = (await _userRepository.GetAll()).FirstOrDefaultAsync(x => x.Email == model.Email /*&& x.Password == HashPassword.HashPasswordHelper(model.Password)*/);

            //var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);


            //if (user is null)
            //{
            //    return baseResponse;
            //}

            return baseResponse;
        }

        public Task<IBaseResponse<bool>> LogOut()
        {
            throw new NotImplementedException();
        }
    }
}
