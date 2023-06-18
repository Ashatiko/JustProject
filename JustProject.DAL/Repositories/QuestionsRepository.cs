using JustProject.DAL.Interfaces;
using JustProject.Domain.Entity.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.DAL.Repositories
{
    public class QuestionsRepository : IBaseRepository<Questions>
    {
        private readonly ApplicationDBContext _context;
        public QuestionsRepository(ApplicationDBContext context) 
        {
            _context = context;
        }

        public async Task<bool> Create(Questions entity)
        {
            await _context.Questions.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Questions entity)
        {
            _context.Questions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Questions>> GetAll()
        {
            return _context.Questions.AsQueryable();
        }

        public async Task<Questions> Update(Questions entity)
        {
            _context.Questions.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
