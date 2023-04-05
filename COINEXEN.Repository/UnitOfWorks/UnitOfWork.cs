using COINEXEN.Core.Repositories;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Repository.Contexts;
using COINEXEN.Repository.Repositories;

namespace COINEXEN.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserWalletRepository UserWalletRepository { get; private set; }
        public AppDbContext Context { get; private set; }
        public ICoinWalletRepository CoinWalletRepository { get; private set; }
        public ICoinRepository CoinRepository { get; private set; }

        readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CoinRepository = new CoinRepository(_context);
            UserWalletRepository = new UserWalletRepository(_context);
            CoinWalletRepository =new CoinWalletRepository(_context);
            Context = context;

        }


        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
