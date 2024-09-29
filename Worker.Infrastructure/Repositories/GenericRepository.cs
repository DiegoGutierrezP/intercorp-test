using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Application.Interfaces;
using Worker.Infrastructure.Context;

namespace Worker.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        internal DbSet<T> DbSet { get; set; }
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            DbSet = _context.Set<T>();
        }
        public async Task<T> AddEntity(T entity)
        {
            var result = await DbSet.AddAsync(entity);
            return result.Entity;
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
