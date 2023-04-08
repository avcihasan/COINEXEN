using COINEXEN.Core.ViewModels;
using Microsoft.AspNetCore.Http;

namespace COINEXEN.Core.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginViewModel loginViewModel);
    }
}
