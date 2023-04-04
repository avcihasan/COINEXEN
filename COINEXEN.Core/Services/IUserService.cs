using COINEXEN.Core.ViewModels;

namespace COINEXEN.Core.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(RegisterViewModel registerViewModel);
    }
}
