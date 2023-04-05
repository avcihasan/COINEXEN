using COINEXEN.Core.Entities;

namespace COINEXEN.Core.Services
{
    public interface IMessageService
    {
        Task<List<Message>> GetAllMessagesAsync();
        Task<Message> GetMessageById(string id);
        Task<bool> CreateMessageAsync(Message message);
    }
}
