using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Services;
using COINEXEN.Core.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace COINEXEN.Web.Controllers
{
    public class AccountController : Controller
    {

        readonly IUserService _userService;
        readonly IAuthService _authService;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public AccountController(IUserService userService, IAuthService authService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userService = userService;
            _authService = authService;
            _userManager = userManager;
            _signInManager = signInManager;
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
            AppUser user = await _userManager.FindByNameAsync(model.UserName);
            await _signInManager.SignOutAsync();

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password,true, false);
                await _userManager.ResetAccessFailedCountAsync(user);
                return RedirectToAction("Index", "Home");
            //if (ModelState.IsValid)
            //{
            //    bool result = await _authService.LoginAsync(model);
            //    if (result)
            //    {
            //        if (!String.IsNullOrEmpty(ReturnUrl))
            //            return Redirect(ReturnUrl);
            //        return RedirectToAction("Index", "Home");
            //    }
            //}
            //return View(model);
        }

        //public ActionResult Logout()
        //{

        //    var authManager = HttpContext.GetOwinContext().Authentication;
        //    authManager.SignOut();

        //    return RedirectToAction("Index","Home");
        //}

    }
}