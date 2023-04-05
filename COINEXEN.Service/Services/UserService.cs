using AutoMapper;
using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Service.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        readonly IMapper _mapper;
        readonly IWalletService _walletService;
        readonly IHttpContextAccessor _httpContextAccesor;


        public UserService(UserManager<AppUser> userManager, IMapper mapper, IWalletService walletService, IHttpContextAccessor httpContextAccesor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _walletService = walletService;
            _httpContextAccesor = httpContextAccesor;
        }
        public async Task<bool> CreateUserAsync(RegisterViewModel registerViewModel)
        {
            AppUser user = _mapper.Map<AppUser>(registerViewModel);
            user.Id = Guid.NewGuid();
            IdentityResult result = await _userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
                await _walletService.CreateWalletsAsync(user);
            return result.Succeeded;
        }

        public async Task<List<AppUser>> GetAllUserAsync()
            =>await _userManager.Users.OrderBy(i => i.Name).ToListAsync();

        public async Task<AppUser> GetOnlineUserAsync()
        {
            if (!_httpContextAccesor.HttpContext.User.Identity.IsAuthenticated)
                throw new Exception("hata");
            AppUser user= await _userManager.FindByNameAsync(_httpContextAccesor.HttpContext.User.Identity.Name);
            if (user==null)
                throw new Exception("hata");
            return user;
        }
    }
}
