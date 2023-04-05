using COINEXEN.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.Controllers
{
    public class AdminPanelUsersController : Controller
    {
        readonly IUserService _userService;

        public AdminPanelUsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
            =>View(await _userService.GetAllUserAsync());
        
    }
}