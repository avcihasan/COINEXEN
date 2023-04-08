using COINEXEN.Core.Entities.Wallet;

namespace COINEXEN.Core.Repositories
{
    public interface IUserWalletRepository:IGenericRepository<UserWallet>
    {
        Task<UserWallet> GetUserWallatByUserIdAsync(string id);
    }
}
