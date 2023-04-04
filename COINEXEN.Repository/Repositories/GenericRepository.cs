using COINEXEN.Core.Entities;
using COINEXEN.Core.Repositories;
using COINEXEN.Repository.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace COINEXEN.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _dbSet = context.Set<T>();
        }

        public async Task<bool> CreateAsync(T entity)
        {
            EntityEntry<T> entityEntry = await _dbSet.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public bool Remove(T entity)
        {
            EntityEntry entityEntry = _dbSet.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            return Remove(entity);
        }

        public IQueryable<T> GetAll(bool tracking = true)
        {
            IQueryable<T> entities = _dbSet.AsQueryable();
            if (!tracking)
                entities.AsNoTracking();
            return entities;
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
            =>await GetAll(tracking).FirstOrDefaultAsync(x => x.Id == id);          
         
        public bool Update(T entity)
        {
            EntityEntry entityEntry = _dbSet.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
