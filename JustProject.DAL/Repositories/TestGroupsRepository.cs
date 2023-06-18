using JustProject.DAL.Interfaces;
using JustProject.Domain.Entity.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.DAL.Repositories
{
    public class TestGroupsRepository : IBaseRepository<TestGroups>
    {
        private readonly ApplicationDBContext _context;
        public TestGroupsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(TestGroups entity)
        {
            await _context.TestGroups.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(TestGroups entity)
        {
            _context.TestGroups.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<TestGroups>> GetAll()
        {
            return _context.TestGroups.AsQueryable();
        }

        public async Task<TestGroups> Update(TestGroups entity)
        {
            _context.TestGroups.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
