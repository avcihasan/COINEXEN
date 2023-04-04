using COINEXEN.Core.Repositories;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Repository.Contexts;
using COINEXEN.Repository.Repositories;

namespace COINEXEN.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICoinRepository CoinRepository { get; private set; }

        readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CoinRepository = new CoinRepository(_context);
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
