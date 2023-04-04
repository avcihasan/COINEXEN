using AutoMapper;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Services;
using COINEXEN.Core.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace COINEXEN.Service.Services
{
    public class AuthService : IAuthService
    {
        readonly IMapper _mapper;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public AuthService(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
        {
            AppUser user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user == null)
                return false;
            SignInResult result= await _signInManager.CheckPasswordSignInAsync(user, loginViewModel.Password, false);
            return result.Succeeded;
        }

        
    }
}
