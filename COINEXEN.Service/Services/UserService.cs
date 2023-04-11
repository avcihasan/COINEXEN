using AutoMapper;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Core.ViewModels.UserVMs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace COINEXEN.Service.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;
        readonly IMapper _mapper;
        readonly IWalletService _walletService;
        readonly IHttpContextAccessor _httpContextAccesor;
        readonly IUnitOfWork _unitOfWork;


        public UserService(UserManager<AppUser> userManager, IMapper mapper, IWalletService walletService, IHttpContextAccessor httpContextAccesor, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _walletService = walletService;
            _httpContextAccesor = httpContextAccesor;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateUserAsync(RegisterVM register)
        {
            AppUser user = _mapper.Map<AppUser>(register);
            user.Id = Guid.NewGuid();
            IdentityResult result = await _userManager.CreateAsync(user, register.Password);
            if (result.Succeeded)
                await _walletService.CreateWalletsAsync(user);
            return result.Succeeded;
        }

        public async Task<List<GetUserVM>> GetAllUserAsync()
            => _mapper.Map<List<GetUserVM>>(await _unitOfWork.UserRepository.GetAllUsersWithPropertiesAsync());

        public async Task<GetOnlineUserVM> GetOnlineUserAsync()
        {
            
            if (!_httpContextAccesor.HttpContext.User.Identity.IsAuthenticated)
                throw new Exception("hata");
            AppUser user = await _unitOfWork.UserRepository.GetUserWithPropertiesAsync(_httpContextAccesor.HttpContext.User.Identity.Name); 
            if (user==null)
                throw new Exception("hata");
            return _mapper.Map<GetOnlineUserVM>(user);
        }
    }
}
