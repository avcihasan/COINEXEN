using AutoMapper;
using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Services;
using COINEXEN.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace COINEXEN.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccesor;
        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<AppRole> _roleManager;
        readonly IMapper _mapper;

        public UserService(IHttpContextAccessor httpContextAccesor, UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager)
        {
            _httpContextAccesor = httpContextAccesor;
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }
        public async Task<bool> CreateUserAsync(RegisterViewModel registerViewModel)
        {
            AppUser user = _mapper.Map<AppUser>(registerViewModel);
            IdentityResult result = await _userManager.CreateAsync(user, registerViewModel.Password);
            //if (result.Succeeded)
            //    await _userManager.AddToRoleAsync(user, "user");
            return result.Succeeded;
        }
        public async Task SendingMessage(string userName, Message message)
        {
            if (_httpContextAccesor.HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(userName);
                if (user != null)
                {
                    Message mesaj = new()
                    {
                        Name = user.Name,
                        Surname = user.Surname,
                        EMail = user.Email,
                        UserName = user.UserName,
                        PhoneNumber = user.PhoneNumber,
                        TopicTitle = message.TopicTitle,
                        Details = message.Details,
                        SendingDate = DateTime.Now
                    };
                   
                }
            }
            else
            {
                //if (ModelState.IsValid)
                //{
                //    var mesaj = new Message();
                //    mesaj.Name = message.Name;
                //    mesaj.Surname = message.Surname;
                //    mesaj.EMail = message.EMail;
                //    mesaj.UserName = message.UserName;
                //    mesaj.PhoneNumber = message.PhoneNumber;
                //    mesaj.TopicTitle = message.TopicTitle;
                //    mesaj.Details = message.Details;
                //    mesaj.SendingDate = DateTime.Now;
                //    mesaj.City = message.City;
                //}
            }
            //_context.Messages.Add(mesaj);
            //_context.SaveChanges();
            //return RedirectToAction("Index", "Home");

        }
    }
}
