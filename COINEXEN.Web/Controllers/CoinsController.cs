using COINEXEN.Core.Entities;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Core.ViewModels.CoinVMs;
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
        readonly ICategoryService _categoryService;

        public CoinsController(IUnitOfWork unitOfWork, ICoinService coinService, IBasketService basketService, ICategoryService categoryService)
        {
            _unitOfWork = unitOfWork;
            _coinService = coinService;
            _basketService = basketService;
            _categoryService = categoryService;
        }
        public IActionResult CoinPreSale()
                 => View();
        public IActionResult CoinPreSaleDetails()
               => View();

        public async Task<IActionResult> CoinList()
        {
            ViewBag.categories = await _categoryService.GetAllCategoriesAsync();
            return View(await _coinService.GetAllCoinsAsync());
        }

        public async Task<IActionResult> CoinDetails(int id)
        {
            if (id == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
           
            GetCoinVM coin = await _coinService.GetCoinByIdAsync(id);
            if (coin == null)
                return NotFound();
            return View(coin);
        }
        public async Task<IActionResult> SellCoin(int id)
         => View(await _coinService.GetCoinByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> SellCoin(int Id, int Stock, string UserName)
        {
            bool result = await _coinService.SellCoinAsync(Id, Stock, UserName);
            if (!result)
                return RedirectToAction("CoinList", "Coins");
            return View("SellSuccess");

        }

        public IActionResult BuyCoin()
            => View(_basketService.GetBasket(HttpContext));
        [HttpPost]
        public async Task<IActionResult> BuyCoin(string UserName)
        {
            var basket = _basketService.GetBasket(HttpContext);
            if (basket.Coin == null)
                ModelState.AddModelError("coinyok", "Sepette coin yok");
            await _coinService.BuyCoinAsync(basket, UserName);
            return View("BuySuccess");

        }
    }
}
