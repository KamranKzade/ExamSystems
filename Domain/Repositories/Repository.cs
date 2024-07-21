using Domain.Contexts;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context = context;

        protected DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await Table.AddAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public IEnumerable<T> GetAll(bool tracking = true)
        {
            if (tracking)
                return [.. Table];

            return [.. Table.AsNoTracking()];
        }

        public async Task<T?> GetAsync(int id) => await Table.FirstOrDefaultAsync(e => e.Id == id);
        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression) => await Table.FirstOrDefaultAsync(expression);

        public IEnumerable<T> GetWhere(Func<T, bool> expression) => Table.Where(expression);
        public bool Remove(T entity)
        {
            var entry = Table.Remove(entity);
            return entry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T? model = await Table.FindAsync(id);
            if (model != null)
            {
                var entry = Table.Remove(model);
                return entry.State == EntityState.Deleted;
            }
            throw new Exception("Item not found");
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public bool Update(T entity)
        {
            var entry = Table.Update(entity);
            return entry.State == EntityState.Modified;
        }
    }
}
