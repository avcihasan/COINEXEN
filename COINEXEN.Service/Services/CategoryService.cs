using AutoMapper;
using COINEXEN.Core.Entities;
using COINEXEN.Core.Repositories;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Core.ViewModels.CategoryVMs;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Service.Services
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<GetCategoryVM>> GetAllCategoriesAsync()
            => _mapper.Map<List<GetCategoryVM>>(await _unitOfWork.CategoryRepository.GetAll().ToListAsync());
        
    }
}
