using JustProject.Domain.Entity;
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
        Task<IEnumerable<Tests>> GetSchool();
        Task<IEnumerable<Tests>> GetSet();
        Task<IEnumerable<Tests>> GetSpecialist();
        Task<Tests> GetTest(int id);
    }
}
