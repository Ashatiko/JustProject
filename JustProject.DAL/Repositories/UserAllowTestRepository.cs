using JustProject.DAL.Interfaces;
using JustProject.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.DAL.Repositories
{
    public class UserAllowTestRepository : IBaseRepository<UserAllowTest>
    {
        private readonly ApplicationDBContext _context;
        public UserAllowTestRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(UserAllowTest entity)
        {
            await _context.UserAllowTest.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(UserAllowTest entity)
        {
            _context.UserAllowTest.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<UserAllowTest>> GetAll()
        {
            return _context.UserAllowTest.AsQueryable();
        }

        public async Task<UserAllowTest> Update(UserAllowTest entity)
        {
            _context.UserAllowTest.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
