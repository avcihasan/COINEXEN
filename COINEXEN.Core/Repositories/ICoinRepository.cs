using COINEXEN.Core.Entities;

namespace COINEXEN.Core.Repositories
{
    public interface ICoinRepository:IGenericRepository<Coin>
    {
        IQueryable<Coin> GetAllCoinWithCategories();
    }
}
