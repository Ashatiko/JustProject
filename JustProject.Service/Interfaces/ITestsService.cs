using JustProject.Domain.Entity.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Service.Interfaces
{
    public interface ITestsService
    {
        Task<IEnumerable<Tests>> GetAll();
        Task<int> GetId(string testName);
        Task<IEnumerable<Tests>> GetSchool();
        Task<IEnumerable<Tests>> GetSchoolAuth(int userId);
        Task<IEnumerable<Tests>> GetSet();
        Task<IEnumerable<Tests>> GetSetAuth(int userId);
        Task<IEnumerable<Tests>> GetSpecialist();
        Task<IEnumerable<Tests>> GetSpecialistAuth(int userId);
        Task<Tests> GetTest(int id);
    }
}
