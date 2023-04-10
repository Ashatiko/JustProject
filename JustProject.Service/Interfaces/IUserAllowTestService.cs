using JustProject.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Service.Interfaces
{
    public interface IUserAllowTestService
    {
        Task<bool> Login(LoginTestViewModel model);
    }
}
