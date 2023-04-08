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
