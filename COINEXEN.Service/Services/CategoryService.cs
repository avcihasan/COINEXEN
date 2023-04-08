using COINEXEN.Core.Entities;
using COINEXEN.Core.Repositories;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;

namespace COINEXEN.Service.Services
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
