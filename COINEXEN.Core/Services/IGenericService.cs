using COINEXEN.Core.Entities;

namespace COINEXEN.Core.Services
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> RemoveByIdAsync(string id);
    }
}
