using AutoMapper;
using COINEXEN.Core.Entities;
using COINEXEN.Core.Repositories;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Core.ViewModels.CategoryVMs;
using COINEXEN.Service.Services;
using Moq;
using Xunit;

namespace COINEXEN.Service.UnitTest.ServicesUnitTests
{
    public class CategoryServiceTests
    {
        private readonly CategoryService _categoryService;
        private readonly Mock<IGenericRepository<Category>> _repositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IMapper> _mapperMock;

        public CategoryServiceTests()
        {
            _repositoryMock = new Mock<IGenericRepository<Category>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mapperMock = new Mock<IMapper>();

            _categoryService = new CategoryService(
                _repositoryMock.Object,
                _unitOfWorkMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task GetAllCategoriesAsync_ReturnsListOfGetCategoryVM()
        {
            var categories = new List<Category>
            {
                new Category {  },
                new Category {  },
            };

            var expectedViewModels = new List<GetCategoryVM>
            {
                new GetCategoryVM {  },
                new GetCategoryVM { },
            };

            _repositoryMock.Setup(x =>x.GetAll(false)).Returns(categories.AsQueryable());
            _mapperMock.Setup(x=> x.Map<List<GetCategoryVM>>(categories)).Returns(expectedViewModels);

            var result = await _categoryService.GetAllCategoriesAsync();

            Assert.Equal(expectedViewModels, result);
            _repositoryMock.Verify(x => x.GetAll(false), Times.Once);
            _mapperMock.Verify(x => x.Map<List<GetCategoryVM>>(categories), Times.Once);
        }
    }
}
