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
    public class ReviewsRepositoy : IBaseRepository<Reviews>
    {
        private readonly ApplicationDBContext _context;
        public ReviewsRepositoy(ApplicationDBContext dBContext)
        {
            _context = dBContext;
        }
        public async Task<bool> Create(Reviews entity)
        {
            await _context.Reviews.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Reviews entity)
        {
            _context.Reviews.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<Reviews>> GetAll()
        {
            return _context.Reviews.AsQueryable();
        }

        public async Task<Reviews> Update(Reviews entity)
        {
            _context.Reviews.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
