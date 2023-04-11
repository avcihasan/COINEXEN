using COINEXEN.Core.Entities;
using COINEXEN.Core.Repositories;

namespace COINEXEN.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public ICoinWalletRepository CoinWalletRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IMessageRepository MessageRepository { get; }
        public IUserWalletRepository UserWalletRepository { get; }
        public ICoinRepository CoinRepository { get; }
        public ICoinTransactionRepository CoinTransactionRepository { get; }
        void Commit();
        Task CommitAsync(); 
    }
}
