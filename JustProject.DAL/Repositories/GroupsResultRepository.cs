using JustProject.DAL.Interfaces;
using JustProject.Domain.Entity.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.DAL.Repositories
{
    public class GroupsResultRepository : IBaseRepository<GroupsResult>
    {
        private readonly ApplicationDBContext _context;
        public GroupsResultRepository(ApplicationDBContext context) 
        {
            _context = context;
        }

        public async Task<bool> Create(GroupsResult entity)
        {
            await _context.GroupsResult.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(GroupsResult entity)
        {
            _context.GroupsResult.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<GroupsResult>> GetAll()
        {
            return _context.GroupsResult.AsQueryable();
        }

        public async Task<GroupsResult> Update(GroupsResult entity)
        {
            _context.GroupsResult.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
