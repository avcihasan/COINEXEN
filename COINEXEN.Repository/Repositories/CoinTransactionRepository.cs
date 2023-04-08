using COINEXEN.Core.Entities;
using COINEXEN.Core.Enums;
using COINEXEN.Core.Repositories;
using COINEXEN.Repository.Contexts;

namespace COINEXEN.Repository.Repositories
{
    public class CoinTransactionRepository : GenericRepository<CoinTransaction>, ICoinTransactionRepository
    {
        public CoinTransactionRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<CoinTransaction> GetCoinTransactions(Transaction transaction)
        {
            if (transaction == Transaction.BuyAndSell)
                return GetAll();
            return GetAll().Where(x => x.Transaction == transaction);
        }
    }
}
