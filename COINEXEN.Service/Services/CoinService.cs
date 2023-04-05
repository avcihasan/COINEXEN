using AutoMapper;
using COINEXEN.Core.Entities;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Service.Services
{
    public class CoinService : ICoinService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;

        public CoinService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CoinViewModel>> GetCoinsAsync(string id=null)
        {
            List<Coin> coins =await _unitOfWork.CoinRepository.GetAllCoinWithCategories().ToListAsync();
            if (id != null)
                if (coins.FirstOrDefault(x => x.Id == Guid.Parse(id))!=null)
                    return _mapper.Map<List<CoinViewModel>>(coins.FirstOrDefault(x=>x.Id==Guid.Parse(id)));
            return _mapper.Map<List<CoinViewModel>>(coins);
        }
    }
}
