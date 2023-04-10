using COINEXEN.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.Areas.AdminPanel.Controllers
{
    [Area("adminPanel")]
    public class UsersController : Controller
    {
        readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
            => View(await _userService.GetAllUserAsync());
    }
}
