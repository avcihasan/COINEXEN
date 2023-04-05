using COINEXEN.Core.Entities;
using COINEXEN.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace COINEXEN.Controllers
{
    [Authorize]
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
            => View(await _coinService.GetCoinsAsync(id));

        public async Task<IActionResult> CartDetailsDelete(string id)
            => View(await _coinService.GetCoinsAsync(id));

        public async Task<IActionResult> AddToCart(string coinId, int alimSayisi)
        {
            await _basketService.AddCoinToBasketAsync(HttpContext, coinId, alimSayisi);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id, int AlimSayisi, string UserName)
        {
           // var uye = _idb.Users.Where(a => a.UserName == UserName).FirstOrDefault();
           // var order = _context.OrderLines.Where(i => i.Coin.Id == Id && i.Username == UserName).FirstOrDefault();
           // var cuzdansatis = new CuzdanSatis();

           // var cuzdanline=_context.CoinCuzdanLines.Where(i => i.Coin.Id == Id && i.UserName == UserName).FirstOrDefault();

           // if (order == null)
           // {
           //     return RedirectToAction("Index", "AlSat");
           // }


           // if (order.Quantity > AlimSayisi)
           // {
           //     cuzdansatis.CoinName = order.Coin.Name;

           //     cuzdansatis.Quantity = AlimSayisi;
           //     cuzdansatis.UserName = UserName;
           //     cuzdansatis.SatisDate = DateTime.Now;
           //     cuzdansatis.CoinPrice = order.Coin.Price;
           //     cuzdansatis.TotalPrice = order.Coin.Price * AlimSayisi;

           //     _context.CuzdanSatiss.Add(cuzdansatis);

           //     cuzdanline.Quantity=cuzdanline.Quantity - AlimSayisi;
           //     order.Quantity = order.Quantity - AlimSayisi;
           //     uye.HesapDeger = uye.HesapDeger - (order.Coin.Price * AlimSayisi);
           //     uye.Bakiye = uye.Bakiye + (order.Coin.Price * AlimSayisi);


           // }
           // else if (order.Quantity == AlimSayisi)
           // {
           //     cuzdansatis.CoinName = order.Coin.Name;
           //     cuzdansatis.Quantity = AlimSayisi;
           //     cuzdansatis.UserName = UserName;
           //     cuzdansatis.SatisDate = DateTime.Now;
           //     cuzdansatis.CoinPrice = order.Coin.Price;
           //     cuzdansatis.TotalPrice = order.Coin.Price * AlimSayisi;


           //     _context.CuzdanSatiss.Add(cuzdansatis);

           //     uye.HesapDeger = uye.HesapDeger - (order.Coin.Price * AlimSayisi);
           //     uye.Bakiye = uye.Bakiye + (order.Coin.Price * AlimSayisi);
           //     _context.OrderLines.Remove(order);
           //     _context.CoinCuzdanLines.Remove(cuzdanline);
           // }
           //else if (order.Quantity < AlimSayisi)
           // {
           //     return RedirectToAction("Index", "AlSat");

           // }
           // var coin = _context.Coin.Where(i => i.Id == Id).FirstOrDefault();
           // coin.Stock = coin.Stock + AlimSayisi;

           // _idb.SaveChanges();
           // _context.SaveChanges();

            return View("DeleteSuccess");

        }

        //public ActionResult Checkout()
        //{
        //    return View(GetCart());
        //}

        //[HttpPost]
        //public ActionResult Checkout(string UserName)
        //{
        //    var cart = GetCart();



        //    if (cart.CartLines.Count == 0)
        //    {
        //        ModelState.AddModelError("coinyok", "Sepette coin yok");
        //    }

        //    SaveOrder(cart, UserName);

        //    cart.Clear();

        //    return View("Complated");
        //}

    }




  
   



}