using COINEXEN.Core.ViewModels;
using COINEXEN.Core.ViewModels.UserVMs;
using Microsoft.AspNetCore.Http;

namespace COINEXEN.Core.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginVM login);
        Task LogoutAsync(HttpContext httpContext);
    }
}
