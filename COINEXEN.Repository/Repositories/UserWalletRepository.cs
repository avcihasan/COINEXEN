using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Repositories;
using COINEXEN.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Repository.Repositories
{
    public class UserWalletRepository : GenericRepository<UserWallet>, IUserWalletRepository
    {
        public UserWalletRepository(AppDbContext context) : base(context) { }

        public async Task<UserWallet> GetUserWallatByUserIdAsync(string id)
            =>await GetAll()
            .Where(x => x.AppUser.Id == Guid.Parse(id))
            .Include(x=>x.AppUser)
            .FirstOrDefaultAsync();
        
    }
}
