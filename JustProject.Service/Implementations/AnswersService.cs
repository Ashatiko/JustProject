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
    public class AnswersService : IAnswersService
    {
        private readonly AnswersRepository _repository;
        public AnswersService(AnswersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Answers>> GetAnswers()
        {            
            return await _repository.GetAll();
        }

        public async Task<bool> GetCorrectChoose(int answersId)
        {
            var answer = (await _repository.GetAll()).FirstOrDefault(x=>x.AnswersId == answersId);
            if (answer.IsCorrect == true) 
                return true;
            return false;
        }
    }
}
