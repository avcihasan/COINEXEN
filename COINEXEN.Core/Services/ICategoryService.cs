using COINEXEN.Core.Entities;
using COINEXEN.Core.Enums;
using COINEXEN.Core.ViewModels.CategoryVMs;

namespace COINEXEN.Core.Services
{
    public interface ICategoryService:IGenericService<Category>
    {
        Task<List<GetCategoryVM>> GetAllCategoriesAsync();
    }
}
