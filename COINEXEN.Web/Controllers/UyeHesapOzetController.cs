using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Enums;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Web.Controllers
{
    //[Authorize]
    public class UyeHesapOzetController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IUserService _userService;
        readonly IWalletService _walletService;

        public UyeHesapOzetController(IUnitOfWork unitOfWork, IUserService userService, IWalletService walletService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _walletService = walletService;
        }

        public async Task<IActionResult> Index()
        {
            AppUser user = await _userService.GetOnlineUserAsync();

            ViewBag.Uye = user;

            ViewBag.coinler =(await _walletService.GetCoinWalletAsync(user)).CoinWalletLines;

            ViewBag.satislar =await _unitOfWork.CoinTransactionRepository.GetCoinTransactions(Transaction.Sell).Where(i => i.AppUser.UserName == User.Identity.Name).OrderByDescending(x=>x.DateOfTransaction).ToListAsync();

            ViewBag.alimlar = await _unitOfWork.CoinTransactionRepository.GetCoinTransactions(Transaction.Buy).Where(i => i.AppUser.UserName == User.Identity.Name).OrderByDescending(x => x.DateOfTransaction).ToListAsync();
            return View();
        }
    }
}