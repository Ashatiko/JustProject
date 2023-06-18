using JustProject.DAL.Interfaces;
using JustProject.Domain.Entity.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.DAL.Repositories
{
    public class AnswersRepository : IBaseRepository<Answers>
    {
        private readonly ApplicationDBContext _context;
        public AnswersRepository(ApplicationDBContext dBContext) 
        {
            _context = dBContext;
        }

        public async Task<bool> Create(Answers entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Answers entity)
        {
            _context.Answers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Answers>> GetAll()
        {
            return _context.Answers.AsQueryable();
        }

        public async Task<Answers> Update(Answers entity)
        {
            _context.Answers.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
