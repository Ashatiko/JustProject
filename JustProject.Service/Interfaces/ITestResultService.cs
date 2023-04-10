using JustProject.Models.Tests.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Service.Interfaces
{
    public interface ITestResultService
    {
        Task<bool> SaveStepTest(TestStepViewModel model);
    }
}
