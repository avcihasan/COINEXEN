using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Repositories;
using COINEXEN.Repository.Contexts;

namespace COINEXEN.Repository.Repositories
{
    public class CoinWalletRepository : GenericRepository<CoinWallet>, ICoinWalletRepository
    {
        public CoinWalletRepository(AppDbContext context) : base(context)
        {
        }
    }
}
