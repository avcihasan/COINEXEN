using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Enums;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Service.Services
{
    public class MessageService : IMessageService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IHttpContextAccessor _httpContextAccesor;
        readonly UserManager<AppUser> _userManager;


        public MessageService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccesor, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccesor = httpContextAccesor;
            _userManager = userManager;
        }

        public async Task<List<Message>> GetAllMessagesAsync()
            => await _unitOfWork.MessageRepository.GetAll().OrderByDescending(i => i.SendingDate).ToListAsync();


        public async Task<Message> GetMessageById(string id)
            => await _unitOfWork.MessageRepository.GetByIdAsync(id);



        public async Task<bool> CreateMessageAsync(Message message)
        {
            bool result;
            if (_httpContextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(_httpContextAccesor.HttpContext.User.Identity.Name);
                if (user != null)
                {
                    result = await _unitOfWork.MessageRepository.CreateAsync(
                        new()
                        {
                            Name = user.Name,
                            Surname = user.Surname,
                            EMail = user.Email,
                            UserName = user.UserName,
                            PhoneNumber = user.PhoneNumber,
                            TopicTitle = message.TopicTitle,
                            Details = message.Details,
                            SendingDate = DateTime.Now,
                            City = user.City
                        });
                }
                else
                    return false;
            }
            else
            {
                result = await _unitOfWork.MessageRepository.CreateAsync(
                    new()
                    {
                        Name = message.Name,
                        Surname = message.Surname,
                        EMail = message.EMail,
                        PhoneNumber = message.PhoneNumber,
                        TopicTitle = message.TopicTitle,
                        Details = message.Details,
                        SendingDate = DateTime.Now,
                        City = message.City
                    });
            }

            if (result)
                await _unitOfWork.CommitAsync();
            return result;
        }

    }
}
