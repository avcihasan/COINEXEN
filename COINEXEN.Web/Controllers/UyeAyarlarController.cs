using COINEXEN.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.Controllers
{
    [Authorize]
    public class UyeAyarlarController : Controller
    {
        readonly IUserService _userService;
        public UyeAyarlarController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
            =>View(await _userService.GetOnlineUserAsync());
    }
}