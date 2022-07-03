using COINEXEN.Entity;
using COINEXEN.Identity;
using COINEXEN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COINEXEN.Controllers
{
    [Authorize]
    public class UyeHesapOzetController : Controller
    {
        private IdentityDataContext _db = new IdentityDataContext();
        private DataContext db = new DataContext();

        // GET: UyeHesapOzet
        public ActionResult Index()
        {

            var orders = db.Orders.Where(a => a.Username == User.Identity.Name).Select(i => new UserOrderModel()
            {
                Id = i.Id,
                OrderDate = i.OrderDate,
                Total = i.Total,

                Quantity = i.Quantity,
                CoinFiyat = i.CoinFiyat,
                CoinName = i.CoinName,
                Username = i.Username,
                OldQuantity = i.Quantity,
              
              
                
                
              
            }
                ).OrderByDescending(i=>i.OrderDate).ToList();

            var uye = _db.Users.Where(i => i.UserName == User.Identity.Name).FirstOrDefault();
            ViewBag.Uye = uye;

     

            var coinler = db.CoinCuzdanLines.Where(i => i.UserName == User.Identity.Name).ToList().OrderBy(a=>a.Coin.Name);
            ViewBag.coinler = coinler;

            var satislar = db.CuzdanSatiss.Where(i => i.UserName == User.Identity.Name).ToList().OrderByDescending(a => a.SatisDate);
            ViewBag.satislar = satislar;

            var alimlar=db.CuzdanAlims.Where(i => i.UserName == User.Identity.Name).ToList().OrderByDescending(a => a.AlimDate);
            ViewBag.alimlar = alimlar;
            return View(orders);
        }
    }
}