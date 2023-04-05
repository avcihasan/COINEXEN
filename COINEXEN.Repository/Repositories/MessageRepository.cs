using COINEXEN.Core.Entities;
using COINEXEN.Core.Repositories;
using COINEXEN.Repository.Contexts;

namespace COINEXEN.Repository.Repositories
{
    public class MessageRepository : GenericRepository<Message>, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context)
        {
        }
    }
}
