using COINEXEN.Core.Entities.Wallet;

namespace COINEXEN.Core.Repositories
{
    public interface IUserWalletRepository:IGenericRepository<UserWallet>
    {
        Task<UserWallet> GetUserWallatByUserNameAsync(string userName);
    }
}
