using JustProject.Domain.Entity;
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
        Task<bool> SaveTest(TestResult model);
        Task<IEnumerable<TestResult>> GetAll();
        Task<TestResult> Get(int id);
        Task<bool> Update(TestResult testVal);
    }
}
