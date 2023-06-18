using JustProject.DAL.Repositories;
using JustProject.Domain.Entity.Test;
using JustProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Service.Implementations
{
    public class QuestionsService : IQuestionsService
    {
        private readonly QuestionsRepository _repository;
        public QuestionsService(QuestionsRepository repository) 
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Questions>> GetQuestions(int testGroupsId)
        {
            return (await _repository.GetAll()).Where(x=>x.GroupId == testGroupsId);
        }
    }
}
