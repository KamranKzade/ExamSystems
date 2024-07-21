using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(bool tracking = true);
        IEnumerable<T> GetWhere(Func<T, bool> expression);

        Task<T?> GetAsync(int id);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression);

        Task<bool> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        bool Update(T entity);
        bool Remove(T entity);
        Task<bool> RemoveAsync(int id);

        Task<int> SaveChangesAsync();
    }
}
