using COINEXEN.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.Controllers
{
    public class BasketsController : Controller
    {
        readonly IUserService _userService;
        readonly ICoinService _coinService;
        readonly IBasketService _basketService;

        public BasketsController(IUserService userService, ICoinService coinService, IBasketService basketService)
        {
            _userService = userService;
            _coinService = coinService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.user = await _userService.GetOnlineUserAsync();
            return View(_basketService.GetBasket(HttpContext));
        }

        public async Task<IActionResult> BasketDetails(string id)
           => View(await _coinService.GetCoinByIdAsync(id));

        public async Task<IActionResult> AddToBasket(string Id, int Stock)
        {
            await _basketService.AddCoinToBasketAsync(HttpContext, Id, Stock);
            return RedirectToAction("Index", "Baskets");
        } 
    }
}