using COINEXEN.Core.Entities;
using COINEXEN.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace COINEXEN.Web.Controllers
{
    //[Authorize]
    public class CartController : Controller
    {
        readonly IUserService _userService;
        readonly ICoinService _coinService;
        readonly IBasketService _basketService;

        public CartController(IUserService userService, ICoinService coinService, IBasketService basketService)
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

        public async Task<IActionResult> CartDetails(string id)
            => View(await _coinService.GetCoinByIdAsync(id));

        public async Task<IActionResult> CartDetailsDelete(string id)
            => View(await _coinService.GetCoinByIdAsync(id));   

        public async Task<IActionResult> AddToCart(string Id, int Stock)
        { 
            await _basketService.AddCoinToBasketAsync(HttpContext, Id, Stock);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveFromCart(string Id, int Stock, string UserName)
        {
            bool result =await _basketService.SellCoinAsync(Id, Stock, UserName);
            if (!result)
                return RedirectToAction("Index", "AlSat");
            return View("DeleteSuccess");

        }

        public ActionResult Checkout()
            =>View(_basketService.GetBasket(HttpContext));
        

        [HttpPost]
        public async Task<IActionResult> Checkout(string UserName)
        {
            var cart = _basketService.GetBasket(HttpContext);
            if (cart.Coin == null)
                ModelState.AddModelError("coinyok", "Sepette coin yok");
            await _basketService.SaveOrderAsync(cart,UserName,Core.Enums.Transaction.Buy);
            return View("Complated");
        }

    }




  
   



}