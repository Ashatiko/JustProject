using JustProject.DAL.Interfaces;
using JustProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.DAL.Repositories
{
    public class UserTestsRepository : IBaseRepository<UserTests>
    {
        private readonly ApplicationDBContext _context;
        public UserTestsRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(UserTests entity)
        {
            await _context.UserTests.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(UserTests entity)
        {
            _context.UserTests.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IQueryable<UserTests>> GetAll()
        {
            return Task.FromResult(_context.UserTests.AsQueryable());
        }

        public async Task<UserTests> Update(UserTests entity)
        {
            _context.UserTests.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
