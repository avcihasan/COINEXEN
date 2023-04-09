using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Repositories;
using COINEXEN.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly DbSet<AppUser> _appUsers;
        public UserRepository(AppDbContext context)
        {
            _appUsers=context.Set<AppUser>();
        }
        public async Task<AppUser> GetUserWithPropertiesAsync(string userName)
            =>await _appUsers
            .Include(x => x.Wallet)
            .Include(x => x.CoinWallet).ThenInclude(x=>x.CoinWalletLines).ThenInclude(x=>x.Coin).ThenInclude(x=>x.Category)
            .FirstOrDefaultAsync();
        
    }
}
