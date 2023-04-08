using COINEXEN.Core.Entities;
using COINEXEN.Core.Repositories;

namespace COINEXEN.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public IBasketRepository BasketRepository { get; }
        public ICoinWalletRepository CoinWalletRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IMessageRepository MessageRepository { get; }
        public IUserWalletRepository UserWalletRepository { get; }
        public ICoinRepository CoinRepository { get; }
        void Commit();
        Task CommitAsync(); 
    }
}
