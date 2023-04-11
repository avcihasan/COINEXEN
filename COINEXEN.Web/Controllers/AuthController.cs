using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Services;
using COINEXEN.Core.ViewModels;
using COINEXEN.Core.ViewModels.UserVMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.Controllers
{
    public class AuthController : Controller
    {

        readonly IUserService _userService;
        readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        public ActionResult Register()
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                bool result = await _userService.CreateUserAsync(model);
                if (result)
                    return RedirectToAction("Login", "Auth");
            }
            return View(model);
        }

        public IActionResult Login()
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                bool result = await _authService.LoginAsync(model);
                if (result && ReturnUrl != null)
                    return Redirect(ReturnUrl);
                else if(result)
                    return RedirectToAction("Index", "Home");
            }
           
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync(HttpContext);
            return RedirectToAction("Index", "Home");
        }

    }
}