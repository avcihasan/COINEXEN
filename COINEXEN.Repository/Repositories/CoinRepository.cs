using COINEXEN.Core.Entities;
using COINEXEN.Core.Repositories;
using COINEXEN.Repository.Contexts;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Repository.Repositories
{
    public class CoinRepository : GenericRepository<Coin>, ICoinRepository
    {
        public CoinRepository(AppDbContext context) : base(context){}

        public IQueryable<Coin> GetAllCoinWithCategories()
            => GetAll().Include(x => x.Category);
        public async Task<Coin> GetCoinByIdWithCategoryAsync(string id)
            => await GetAll().Include(x => x.Category).FirstOrDefaultAsync(x=>x.Id==Guid.Parse(id));


    }
}
