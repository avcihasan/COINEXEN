using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.ViewModels;
using COINEXEN.Core.ViewModels.UserVMs;

namespace COINEXEN.Core.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(RegisterVM register);
        Task<List<GetUserVM>> GetAllUserAsync();
        Task<GetOnlineUserVM> GetOnlineUserAsync();
    }
}
