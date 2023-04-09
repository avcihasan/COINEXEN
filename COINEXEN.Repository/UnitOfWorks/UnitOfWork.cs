using COINEXEN.Core.Entities;
using COINEXEN.Core.Repositories;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Repository.Contexts;
using COINEXEN.Repository.Repositories;

namespace COINEXEN.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserWalletRepository UserWalletRepository { get; private set; }
        public IBasketRepository BasketRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public ICoinWalletRepository CoinWalletRepository { get; private set; }
        public ICoinRepository CoinRepository { get; private set; }
        public IMessageRepository MessageRepository { get; private set; }
        public ICoinTransactionRepository CoinTransactionRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CoinRepository = new CoinRepository(_context);
            UserWalletRepository = new UserWalletRepository(_context);
            CoinWalletRepository =new CoinWalletRepository(_context);
            MessageRepository = new MessageRepository(_context);
            CategoryRepository=new CategoryRepository(_context);
            BasketRepository = new BasketRepository(_context);
            CoinTransactionRepository = new CoinTransactionRepository(_context);
            UserRepository = new UserRepository(_context);
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
