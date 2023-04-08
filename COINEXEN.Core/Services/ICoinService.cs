using COINEXEN.Core.Entities;
using COINEXEN.Core.ViewModels;

namespace COINEXEN.Core.Services
{
    public interface ICoinService:IGenericService<Coin>
    {
        Task<List<CoinViewModel>> GetCoinsAsync(string id=null);
    }
}
