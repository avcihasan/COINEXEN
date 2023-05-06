using COINEXEN.Core.Entities;
using COINEXEN.Core.ViewModels.MessageVMs;

namespace COINEXEN.Core.Services
{
    public interface IMessageService
    {
        Task<List<GetMessageVM>> GetAllMessagesAsync();
        Task<GetMessageVM> GetMessageById(int id);
        Task<bool> CreateMessageAsync(SetMessageVM message);
    }
}
