using AutoMapper;
using Azure;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Services;
using COINEXEN.Core.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
            await _signInManager.SignOutAsync();
            SignInResult result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, true, false);
            await _userManager.ResetAccessFailedCountAsync(user);
            return result.Succeeded;
        }

        public async Task LogoutAsync(HttpContext httpContext)
        {
            httpContext.Response.Cookies.Delete("MyBlog");
            await _signInManager.SignOutAsync();
        }
    }
}
