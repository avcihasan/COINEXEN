using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Repositories;
using COINEXEN.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Repository.Repositories
{
    public class UserWalletRepository : GenericRepository<UserWallet>, IUserWalletRepository
    {
        public UserWalletRepository(AppDbContext context) : base(context) { }

        public async Task<UserWallet> GetUserWallatByUserNameAsync(string userName)
            =>await GetAll()
            .Where(x => x.AppUser.Name == userName)
            .Include(x=>x.AppUser)
            .FirstOrDefaultAsync();
        
    }
}
