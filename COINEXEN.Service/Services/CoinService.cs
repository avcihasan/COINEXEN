using AutoMapper;
using COINEXEN.Core.Entities;
using COINEXEN.Core.Repositories;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Service.Services
{
    public class CoinService :GenericService<Coin>, ICoinService
    {
        readonly IMapper _mapper;

        public CoinService(IGenericRepository<Coin> repo, IUnitOfWork unitOfWork, IMapper mapper) : base(repo, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<CoinViewModel>> GetAllCoinsAsync()
        {
            List<Coin> coins = await _unitOfWork.CoinRepository.GetAllCoinWithCategories().ToListAsync();
            return _mapper.Map<List<CoinViewModel>>(coins);
        }

        public async Task<CoinViewModel> GetCoinByIdAsync(string id)
        {  
            Coin coin =await _unitOfWork.CoinRepository.GetCoinByIdWithCategoryAsync(id);
            return _mapper.Map<CoinViewModel>(coin);
        }
    }
}
