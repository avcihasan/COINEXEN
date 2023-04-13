using COINEXEN.Core.Entities;
using COINEXEN.Core.Enums;
using COINEXEN.Core.ViewModels;
using COINEXEN.Core.ViewModels.BasketVMs;
using COINEXEN.Core.ViewModels.CoinVMs;

namespace COINEXEN.Core.Services
{
    public interface ICoinService:IGenericService<Coin>
    {
        Task<GetCoinVM> GetCoinByIdAsync(string id);
        Task<List<GetCoinVM>> GetAllCoinsAsync();

        Task<bool> BuyCoinAsync(BasketVM basket, string userName);
        Task<bool> SellCoinAsync(string Id, int AlimSayisi, string UserName);
    }
}
