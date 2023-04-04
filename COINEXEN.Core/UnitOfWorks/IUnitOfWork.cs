using COINEXEN.Core.Repositories;

namespace COINEXEN.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public ICoinRepository CoinRepository { get; }
        void Commit();
        Task CommitAsync(); 
    }
}
