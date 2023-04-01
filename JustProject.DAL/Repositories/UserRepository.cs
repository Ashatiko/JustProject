using JustProject.DAL.Interfaces;
using JustProject.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.DAL.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(User entity)
        {
            await _context.User.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(User entity)
        {
            _context.User.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<User>> GetAll()
        {
            return _context.User.AsQueryable();            
        }

        public async Task<User> Update(User entity)
        {
            _context.User.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
