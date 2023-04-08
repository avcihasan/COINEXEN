using COINEXEN.Core.Entities;
using COINEXEN.Core.ViewModels;

namespace COINEXEN.Core.Services
{
    public interface ICoinService:IGenericService<Coin>
    {
        Task<CoinViewModel> GetCoinByIdAsync(string id);
        Task<List<CoinViewModel>> GetAllCoinsAsync();
    }
}
