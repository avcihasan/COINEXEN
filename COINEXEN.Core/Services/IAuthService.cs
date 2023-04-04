using COINEXEN.Core.ViewModels;

namespace COINEXEN.Core.Services
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginViewModel loginViewModel);
    }
}
