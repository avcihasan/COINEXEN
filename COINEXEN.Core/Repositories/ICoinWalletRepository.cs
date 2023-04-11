using COINEXEN.Core.Entities.Wallet;

namespace COINEXEN.Core.Repositories
{
    public interface ICoinWalletRepository:IGenericRepository<CoinWallet>
    {
        Task<CoinWallet> GetCoinWallatByUserNameAsync(string userName);
    }
}
