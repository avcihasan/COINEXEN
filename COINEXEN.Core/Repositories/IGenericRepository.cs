using COINEXEN.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Core.Repositories
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        public DbSet<T> Table { get; }
        Task<bool> CreateAsync(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        Task<bool> RemoveByIdAsync(int id);
        Task<T> GetByIdAsync(int id, bool tracking = true);
        IQueryable<T> GetAll(bool tracking= true);

    }
}
