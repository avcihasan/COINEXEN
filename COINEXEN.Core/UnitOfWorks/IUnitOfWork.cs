using COINEXEN.Core.Repositories;

namespace COINEXEN.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public ICoinWalletRepository CoinWalletRepository { get; }
        public IMessageRepository MessageRepository { get; }
        public IUserWalletRepository UserWalletRepository { get; }
        public ICoinRepository CoinRepository { get; }
        void Commit();
        Task CommitAsync(); 
    }
}
