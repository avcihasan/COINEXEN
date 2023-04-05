using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.ViewModels;

namespace COINEXEN.Core.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(RegisterViewModel registerViewModel);
        Task<List<AppUser>> GetAllUserAsync();
        Task<AppUser> GetOnlineUserAsync();
    }
}
