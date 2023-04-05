using COINEXEN.Core.Entities;
using COINEXEN.Core.Repositories;
using COINEXEN.Repository.Contexts;

namespace COINEXEN.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
