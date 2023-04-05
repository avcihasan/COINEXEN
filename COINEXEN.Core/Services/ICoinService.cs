using COINEXEN.Core.ViewModels;

namespace COINEXEN.Core.Services
{
    public interface ICoinService
    {
        Task<List<CoinViewModel>> GetCoinsAsync(string id=null);
    }
}
