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
        Task<IBaseResponse<User>> Login(LoginViewModel model);
        Task<IBaseResponse<bool>> LogOut();
    }
}
