using JustProject.Domain.Entity;
using JustProject.Domain.Response;
using JustProject.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAspMvc.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<User>> GetEditUser(AccountViewModel model);
        Task<IBaseResponse<User>> GetUser();   
        Task<IEnumerable<UserTests>> GetHistoryTest();
        Task<IEnumerable<UserTests>> GetHistoryTestAdd(int id);
        Task<bool> GetHistoryTestDelete(int id);
        Task<bool> Login(LoginViewModel model);
        Task<bool> Register(RegisterViewModel model);
        Task<bool> LoginTest();
        Task<bool> LogOut();        
    }
}
