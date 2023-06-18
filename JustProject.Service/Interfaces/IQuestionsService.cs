using JustProject.Domain.Entity.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Service.Interfaces
{
    public interface IQuestionsService
    {
        Task<IEnumerable<Questions>> GetQuestions(int testGroupsId);
    }
}
