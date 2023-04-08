using COINEXEN.Core.Entities;
using COINEXEN.Core.Enums;

namespace COINEXEN.Core.Repositories
{
    public interface ICoinTransactionRepository:IGenericRepository<CoinTransaction>
    {
        IQueryable<CoinTransaction> GetCoinTransactions(Transaction transaction=Transaction.BuyAndSell);

    }
}
