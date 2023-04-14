
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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using JustProject.Domain.Helpers;
using Microsoft.AspNetCore.Authentication;
using JustProject.DAL.Repositories;
using System.Security.Principal;

namespace JustProject.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IBaseRepository<UserTests> _userTestsRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(UserRepository userRepository, IHttpContextAccessor context, IBaseRepository<UserTests> userTestsRepository)
        {
            _userRepository = userRepository;
            _httpContextAccessor = context;
            _userTestsRepository = userTestsRepository;
        }

        public async Task<bool> Register(RegisterViewModel model)
        {
            if (model.Email != null || model.Password != null)
            {
                User user = new User
                {
                    Name = "DefaultName",
                    Surname = "DefaultSurname",
                    Patronumic = "DefaultPatronumic",
                    Phone = 0,
                    AuthorizedTest = false,
                    Role = "User",
                    Email = model.Email,
                    Password = HashPassword.HashPasswordHelper(model.Password)
                };
                if (await _userRepository.Create(user))
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Login(LoginViewModel model)
        {
            if (model.Email == null || model.Password == null)
            {
                return false;
            }

            var user = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == model.Email && x.Password == HashPassword.HashPasswordHelper(model.Password));

            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.UserData, Convert.ToString(user.AuthorizedTest)),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)                    
            };

                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await _httpContextAccessor.HttpContext.SignInAsync(claimsPrincipal);

                return true;
            }
            return false;
        }

        public async Task<bool> LogOut()
        {
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return true;
        }

        public async Task<bool> LoginTest()
        {
            var user = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value);

            if (user != null)
            {
                user.AuthorizedTest = true;
                user.UserTests = user.Id;
                await _userRepository.Update(user);

                var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

                identity.RemoveClaim(identity.FindFirst(ClaimTypes.UserData));

                identity.AddClaim(new Claim(ClaimTypes.UserData, Convert.ToString(user.AuthorizedTest)));

                var principal = new ClaimsPrincipal(identity);

                await _httpContextAccessor.HttpContext.SignInAsync(principal);

                return true;
            }
            return false;
        }

        public async Task<IBaseResponse<User>> GetUser()
        {
            var baseResponse = new BaseResponse<User>();            
            baseResponse.Data = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email ==  _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value);
            return baseResponse;
        }

        public async Task<IBaseResponse<User>> GetEditUser(AccountViewModel model)
        {
            var baseResponse = new BaseResponse<User>();
            var user = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == model.Email);
            if (user == null)
            {
                return baseResponse;
            }
            string[] fullName = model.FullName.Split(' ');
            if (fullName[1] != "" && fullName[0] != "" && fullName[0] != " " && fullName[1] != " ")
            {
                user.Surname = fullName[0];
                user.Name = fullName[1];
            }
            else
            {
                baseResponse.Data = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == _httpContextAccessor.HttpContext.User.Identity.Name);
                return baseResponse;
            }
            user.Patronumic = fullName[2];
            user.Phone = model.Phone;
            user.Email = model.Email;
            user.Password = HashPassword.HashPasswordHelper(model.Password);            
            baseResponse.Data = await _userRepository.Update(user);
            if (ClaimTypes.Name != fullName[0])
            {
                var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;

                identity.RemoveClaim(identity.FindFirst(ClaimTypes.Name));

                identity.AddClaim(new Claim(ClaimTypes.Name, fullName[1]));

                var principal = new ClaimsPrincipal(identity);

                await _httpContextAccessor.HttpContext.SignInAsync(principal);
            }
            return baseResponse;            
        }

        public async Task<IEnumerable<UserTests>> GetHistoryTest()
        {
            try
            {
                var user = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value);                

                return (await _userTestsRepository.GetAll()).Where(x => x.UserTestId == user.UserTests);                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<UserTests>> GetHistoryTestAdd(int id)
        {
            try
            {
                var user = (await _userRepository.GetAll()).FirstOrDefault(x => x.Email == _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value);

                var ass = (await _userTestsRepository.GetAll()).FirstOrDefault(x=>x.Id == id);
                ass.UserTestId = user.Id;
                ass.Complete = 0;
                ass.Date = DateTime.Now;
                ass.Id = Convert.ToInt32(null);
                await _userTestsRepository.Create(ass);
                return (await _userTestsRepository.GetAll()).Where(x => x.UserTestId == user.UserTests);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> GetHistoryTestDelete(int id)
        {
            try
            {
                var test = (await _userTestsRepository.GetAll()).FirstOrDefault(x => x.Id == id);
                if (test == null)
                {
                    return false;
                }
                if (await _userTestsRepository.Delete(test))
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
