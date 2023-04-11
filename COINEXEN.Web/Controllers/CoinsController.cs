using COINEXEN.Core.Entities;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace COINEXEN.Web.Controllers
{
    public class CoinsController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ICoinService _coinService;
        readonly IBasketService _basketService;

        public CoinsController(IUnitOfWork unitOfWork, ICoinService coinService, IBasketService basketService)
        {
            _unitOfWork = unitOfWork;
            _coinService = coinService;
            _basketService = basketService;
        }
        public IActionResult CoinPreSale()
                 => View();
        public IActionResult CoinPreSaleDetails()
               => View();

        public async Task<IActionResult> CoinList(string id)
        {
            ViewBag.categories = await _unitOfWork.CategoryRepository.GetAll().ToListAsync();
            return View(await _coinService.GetAllCoinsAsync());
        }

        public async Task<IActionResult> CoinDetails(string id)
        {
            if (id == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            Coin coin = await _unitOfWork.CoinRepository.GetCoinByIdWithCategoryAsync(id);
            if (coin == null)
                return NotFound();
            return View(coin);
        }





        public async Task<IActionResult> SellCoin(string id)
         => View(await _coinService.GetCoinByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> SellCoin(string Id, int Stock, string UserName)
        {
            bool result = await _basketService.SellCoinAsync(Id, Stock, UserName);
            if (!result)
                return RedirectToAction("CoinList", "Coins");
            return View("SellSuccess");

        }

        public ActionResult BuyCoin()
            => View(_basketService.GetBasket(HttpContext));
        [HttpPost]
        public async Task<IActionResult> BuyCoin(string UserName)
        {
            var cart = _basketService.GetBasket(HttpContext);
            if (cart.Coin == null)
                ModelState.AddModelError("coinyok", "Sepette coin yok");
            await _basketService.BuyCoinAsync(cart, UserName, Core.Enums.Transaction.Buy);
            return View("BuySuccess");

        }
    }
}
