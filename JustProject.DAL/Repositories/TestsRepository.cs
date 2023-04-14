using JustProject.DAL.Interfaces;
using JustProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.DAL.Repositories
{
    public class TestsRepository : IBaseRepository<Tests>
    {
        private readonly ApplicationDBContext _context;
        public TestsRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Tests entity)
        {
            _context.Tests.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Tests entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Tests>> GetAll()
        {
            return _context.Tests.AsQueryable();
        }

        public async Task<Tests> Update(Tests entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
