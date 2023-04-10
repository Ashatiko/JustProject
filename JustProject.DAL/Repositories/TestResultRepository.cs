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
    public class TestResultRepository : IBaseRepository<TestResult>
    {
        private readonly ApplicationDBContext _context;
        public TestResultRepository(ApplicationDBContext dBContext)
        {
            _context = dBContext;
        }
        public async Task<bool> Create(TestResult entity)
        {
            await _context.TestResult.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(TestResult entity)
        {
            _context.TestResult.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<TestResult>> GetAll()
        {
            return _context.TestResult.AsQueryable();
        }

        public async Task<TestResult> Update(TestResult entity)
        {
            _context.TestResult.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
