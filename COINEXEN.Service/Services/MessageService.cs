using AutoMapper;
using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Enums;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Core.ViewModels.MessageVMs;
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
        readonly IMapper _mapper;


        public MessageService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccesor, UserManager<AppUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccesor = httpContextAccesor;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<List<GetMessageVM>> GetAllMessagesAsync()
            => _mapper.Map<List<GetMessageVM>>(await _unitOfWork.MessageRepository.GetAll().OrderByDescending(i => i.SendingDate).ToListAsync());


        public async Task<GetMessageVM> GetMessageById(string id)
            => _mapper.Map<GetMessageVM>(await _unitOfWork.MessageRepository.GetByIdAsync(id));



        public async Task<bool> CreateMessageAsync(SetMessageVM message)
        {
            bool result;
            if (_httpContextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(_httpContextAccesor.HttpContext.User.Identity.Name);
                if (user != null)
                {
                    //result = await _unitOfWork.MessageRepository.CreateAsync(
                    //    new()
                    //    {
                    //        Name = user.Name,
                    //        Surname = user.Surname,
                    //        EMail = user.Email,
                    //        UserName = user.UserName,
                    //        PhoneNumber = user.PhoneNumber,
                    //        TopicTitle = message.TopicTitle,
                    //        Details = message.Details,
                    //        SendingDate = DateTime.Now,
                    //        City = user.City
                    //    });
                    Message newMessage = _mapper.Map<Message>(message);
                    newMessage.Name = user.Name;
                    newMessage.Surname = user.Surname;
                    newMessage.EMail = user.Email;
                    newMessage.PhoneNumber = user.PhoneNumber;
                    newMessage.SendingDate = DateTime.Now;
                    result = await _unitOfWork.MessageRepository.CreateAsync(newMessage);
                }
                else
                    return false;
            }
            else
            {
                //result = await _unitOfWork.MessageRepository.CreateAsync(
                //    new()
                //    {
                //        Name = message.Name,
                //        Surname = message.Surname,
                //        EMail = message.EMail,
                //        PhoneNumber = message.PhoneNumber,
                //        TopicTitle = message.TopicTitle,
                //        Details = message.Details,
                //        SendingDate = DateTime.Now,
                //        City = message.City
                //    });
                Message newMessage = _mapper.Map<Message>(message);
                newMessage.SendingDate = DateTime.Now;
                result = await _unitOfWork.MessageRepository.CreateAsync(newMessage);

            }

            if (result)
                await _unitOfWork.CommitAsync();
            return result;
        }

    }
}
