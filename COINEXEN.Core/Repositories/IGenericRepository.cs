using COINEXEN.Core.Entities;

namespace COINEXEN.Core.Repositories
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<bool> CreateAsync(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        Task<bool> RemoveByIdAsync(string id);
        Task<T> GetByIdAsync(string id, bool tracking = true);
        IQueryable<T> GetAll(bool tracking= true);

    }
}
