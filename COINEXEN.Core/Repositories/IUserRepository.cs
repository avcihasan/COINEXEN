using COINEXEN.Core.Entities.Identity;

namespace COINEXEN.Core.Repositories
{
    public interface IUserRepository
    {
        Task<AppUser> GetUserWithPropertiesAsync(string userName);
        Task<List<AppUser>> GetAllUsersWithPropertiesAsync();
    }
}
