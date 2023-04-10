using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Enums;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Web.Controllers
{
    public class MembersController : Controller
    {
        readonly IUserService _userService;
        readonly IUnitOfWork _unitOfWork;
        readonly IWalletService _walletService;
        public MembersController(IUserService userService, IUnitOfWork unitOfWork, IWalletService walletService)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _walletService = walletService;
        }
        public async Task<IActionResult> Settings()
            => View(await _userService.GetOnlineUserAsync());

        public async Task<IActionResult> AccountStatement()
        {
            ViewBag.user = await _userService.GetOnlineUserAsync(); ;

            ViewBag.coins = (await _walletService.GetCoinWalletAsync(ViewBag.user)).CoinWalletLines;

            ViewBag.transactions= await _unitOfWork.CoinTransactionRepository.GetCoinTransactions().Where(i => i.AppUser.UserName == User.Identity.Name).OrderByDescending(x => x.DateOfTransaction).ToListAsync();

            return View();
        }
    }
}
