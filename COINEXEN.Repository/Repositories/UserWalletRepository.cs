using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Repositories;
using COINEXEN.Repository.Contexts;

namespace COINEXEN.Repository.Repositories
{
    public class UserWalletRepository : GenericRepository<UserWallet>, IUserWalletRepository
    {
        public UserWalletRepository(AppDbContext context) : base(context){ }
    }
}
