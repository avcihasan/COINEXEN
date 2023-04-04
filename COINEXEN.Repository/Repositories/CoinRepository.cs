using COINEXEN.Core.Entities;
using COINEXEN.Core.Repositories;
using COINEXEN.Repository.Contexts;

namespace COINEXEN.Repository.Repositories
{
    public class CoinRepository : GenericRepository<Coin>, ICoinRepository
    {
        public CoinRepository(AppDbContext context) : base(context){}
    }
}
