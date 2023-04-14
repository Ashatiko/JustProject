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
    }
}
