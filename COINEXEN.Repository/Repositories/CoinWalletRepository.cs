using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Repositories;
using COINEXEN.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Repository.Repositories
{
    public class CoinWalletRepository : GenericRepository<CoinWallet>, ICoinWalletRepository
    {
        public CoinWalletRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<CoinWallet> GetCoinWallatByUserIdAsync(string id)
            => await GetAll()
            .Where(x => x.AppUser.Id == Guid.Parse(id))
            .Include(x=>x.AppUser)
            .Include(x=>x.CoinWalletLines)
            .FirstOrDefaultAsync();
    }
}
