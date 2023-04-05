using COINEXEN.Core.Services;
using COINEXEN.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.Controllers
{
    public class AccountController : Controller
    {

        readonly IUserService _userService;
        readonly IAuthService _authService;

        public AccountController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        public ActionResult Register()
            =>View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
               bool result= await _userService.CreateUserAsync(model);
                if (result)
                    return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        public IActionResult Login()
            => View();
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                bool result = await _authService.LoginAsync(model);
                if (result)
                {
                    if (!String.IsNullOrEmpty(ReturnUrl))
                        return Redirect(ReturnUrl);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        //public ActionResult Logout()
        //{

        //    var authManager = HttpContext.GetOwinContext().Authentication;
        //    authManager.SignOut();

        //    return RedirectToAction("Index","Home");
        //}

    }
}