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
    public class CartController : Controller
    {
        IdentityDataContext _idb = new IdentityDataContext();


        DataContext _context = new DataContext();

        // GET: Cart
        public ActionResult Index()
        {
            ViewBag.user = _idb.Users.Where(i => i.UserName == User.Identity.Name).FirstOrDefault();

            return View(GetCart());
        }

        public ActionResult CartDetails(int Id)
        {

            var coin = _context.Coin.Where(i => i.Id == Id).FirstOrDefault();

            return View(coin);
        }

        public ActionResult CartDetailsDelete(int Id)
        {

            var coin = _context.Coin.Where(i => i.Id == Id).FirstOrDefault();

            return View(coin);
        }

        public ActionResult AddToCart(int Id, int AlimSayisi)
        {
            var coin = _context.Coin.Where(i => i.Id == Id).FirstOrDefault();

            if (coin != null)
            {

                GetCart().AddCoin(coin, AlimSayisi);

            }

            return RedirectToAction("Index");

        }

        public ActionResult RemoveToCart(int Id, int AlimSayisi, string UserName)
        {
            var uye = _idb.Users.Where(a => a.UserName == UserName).FirstOrDefault();
            var order = _context.OrderLines.Where(i => i.Coin.Id == Id && i.Username == UserName).FirstOrDefault();
            var cuzdansatis = new CuzdanSatis();

            var cuzdanline=_context.CoinCuzdanLines.Where(i => i.Coin.Id == Id && i.UserName == UserName).FirstOrDefault();

            if (order == null)
            {
                return RedirectToAction("Index", "AlSat");
            }


            if (order.Quantity > AlimSayisi)
            {
                cuzdansatis.CoinName = order.Coin.Name;

                cuzdansatis.Quantity = AlimSayisi;
                cuzdansatis.UserName = UserName;
                cuzdansatis.SatisDate = DateTime.Now;
                cuzdansatis.CoinPrice = order.Coin.Price;
                cuzdansatis.TotalPrice = order.Coin.Price * AlimSayisi;

                _context.CuzdanSatiss.Add(cuzdansatis);

                cuzdanline.Quantity=cuzdanline.Quantity - AlimSayisi;
                order.Quantity = order.Quantity - AlimSayisi;
                uye.HesapDeger = uye.HesapDeger - (order.Coin.Price * AlimSayisi);
                uye.Bakiye = uye.Bakiye + (order.Coin.Price * AlimSayisi);


            }
            else if (order.Quantity == AlimSayisi)
            {
                cuzdansatis.CoinName = order.Coin.Name;
                cuzdansatis.Quantity = AlimSayisi;
                cuzdansatis.UserName = UserName;
                cuzdansatis.SatisDate = DateTime.Now;
                cuzdansatis.CoinPrice = order.Coin.Price;
                cuzdansatis.TotalPrice = order.Coin.Price * AlimSayisi;


                _context.CuzdanSatiss.Add(cuzdansatis);

                uye.HesapDeger = uye.HesapDeger - (order.Coin.Price * AlimSayisi);
                uye.Bakiye = uye.Bakiye + (order.Coin.Price * AlimSayisi);
                _context.OrderLines.Remove(order);
                _context.CoinCuzdanLines.Remove(cuzdanline);
            }
           else if (order.Quantity < AlimSayisi)
            {
                return RedirectToAction("Index", "AlSat");

            }
            var coin = _context.Coin.Where(i => i.Id == Id).FirstOrDefault();
            coin.Stock = coin.Stock + AlimSayisi;

            _idb.SaveChanges();
            _context.SaveChanges();

            return View("DeleteSuccess");

        }



        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        public ActionResult Checkout()
        {
            return View(GetCart());
        }

        [HttpPost]
        public ActionResult Checkout(string UserName)
        {
            var cart = GetCart();



            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("coinyok", "Sepette coin yok");
            }

            SaveOrder(cart, UserName);

            cart.Clear();

            return View("Complated");
        }

        private void SaveOrder(Cart cart, string UserName)
        {
            var user = _idb.Users.Where(i => i.UserName == User.Identity.Name).FirstOrDefault();



            var alim = new CuzdanAlim();
            var cuzdan = _context.CoinCuzdans.Where(i => i.UserName == UserName).FirstOrDefault();
            if (cuzdan == null)
            {
                cuzdan = new CoinCuzdan();
                cuzdan.UserName = UserName;

                cuzdan.CoinCuzdanLine = new List<CoinCuzdanLine>();
                foreach (var item in cart.CartLines)
                {
                    var coin = _context.Coin.Where(i => i.Id == item.Coin.Id).FirstOrDefault();
                    var cuzdanline = new CoinCuzdanLine();
                    cuzdanline.Quantity = item.Quantity;
                    cuzdanline.CoinId = item.Coin.Id;
                    cuzdanline.UserName = UserName;
                    cuzdan.CoinCuzdanLine.Add(cuzdanline);

                    alim.CoinName = item.Coin.Name;
                    alim.AlimDate = DateTime.Now;
                    alim.CoinPrice = item.Coin.Price;
                    alim.UserName = UserName;
                    alim.Quantity = item.Quantity;
                    alim.TotalPrice =item.Coin.Price*item.Quantity;
                    _context.CuzdanAlims.Add(alim);

                }
                _context.CoinCuzdans.Add(cuzdan);
            }
            else
            {
               
                int temp = 0;

                var a= _context.CoinCuzdanLines.Where(i => i.UserName == UserName).ToList();
                foreach (var y in cart.CartLines)
                {

                    foreach (var item in a)
                    {
                        if (item.Coin.Id == y.Coin.Id)
                        {
                            alim.CoinName = y.Coin.Name;
                            alim.AlimDate = DateTime.Now;
                            alim.CoinPrice = y.Coin.Price;
                            alim.UserName = UserName;
                            alim.Quantity = y.Quantity;
                            alim.TotalPrice = y.Coin.Price * y.Quantity;
                            _context.CuzdanAlims.Add(alim);

                            item.Quantity = item.Quantity + y.Quantity;
                            temp = 1;
                        }
                    }

                   
                }

                if (temp==0)
                {


                    cuzdan = new CoinCuzdan();
                    cuzdan.UserName = UserName;

                    cuzdan.CoinCuzdanLine = new List<CoinCuzdanLine>();
                    foreach (var item in cart.CartLines)
                    {
                        var coin = _context.Coin.Where(i => i.Id == item.Coin.Id).FirstOrDefault();

                        var cuzdanline1 = new CoinCuzdanLine();
                        cuzdanline1.Quantity = item.Quantity;
                        cuzdanline1.CoinId = item.Coin.Id;
                        cuzdanline1.UserName = UserName;
                    

                        cuzdan.CoinCuzdanLine.Add(cuzdanline1);

                        alim.CoinName = item.Coin.Name;
                        alim.AlimDate = DateTime.Now;
                        alim.CoinPrice = item.Coin.Price;
                        alim.UserName = UserName;
                        alim.Quantity = item.Quantity;
                        alim.TotalPrice = item.Coin.Price * item.Quantity;
                        _context.CuzdanAlims.Add(alim);


                    }

                    _context.CoinCuzdans.Add(cuzdan);


                }


            }

           
           
            var orderliness = _context.OrderLines.Where(i => i.Username == UserName).ToList();
            int tempp = 0;
            foreach (var y in cart.CartLines)
            {

                foreach (var item in orderliness)
                {
                    if (item.Coin.Id == y.Coin.Id)
                    {
       
                        item.Quantity = item.Quantity + y.Quantity;
                        _context.SaveChanges();
                        tempp = 1;
                        var order = new Order();
                        order.Total = cart.Total();
                        order.OrderDate = DateTime.Now;
                        order.Username = UserName;

                        foreach (var z in cart.CartLines)
                        {
                            var coin = _context.Coin.Where(i => i.Id == item.Coin.Id).FirstOrDefault();

                            coin.Stock = coin.Stock - z.Quantity;

                            order.Quantity = item.Quantity;
                            order.CoinFiyat = item.Coin.Price;
                            order.CoinName = item.Coin.Name;
                            var x = _idb.Users.Where(a => a.UserName == order.Username).FirstOrDefault();
                            x.Bakiye = x.Bakiye - (item.Quantity * item.Coin.Price);
                        }
                        _context.Orders.Add(order);
                        _context.SaveChanges();

                        _idb.SaveChanges();

                    }
                }

                if (tempp == 0)
                {

                    var order = new Order();
                    order.Total = cart.Total();
                    order.OrderDate = DateTime.Now;
                    order.Username = UserName;
                    order.OrderLines = new List<OrderLine>();
                    foreach (var item in cart.CartLines)
                    {
                        var coin = _context.Coin.Where(i => i.Id == item.Coin.Id).FirstOrDefault();
                        coin.Stock = coin.Stock - item.Quantity;

                        var orderline = new OrderLine();
                        orderline.Quantity = item.Quantity;
                        orderline.Price = item.Quantity * item.Coin.Price;
                        orderline.CoinId = item.Coin.Id;
                        orderline.Username = UserName;

                        order.Quantity = item.Quantity;
                        order.CoinFiyat = item.Coin.Price;
                        order.CoinName = item.Coin.Name;



                        var x = _idb.Users.Where(a => a.UserName == order.Username).FirstOrDefault();
                        x.Bakiye = x.Bakiye - orderline.Price;



                        order.OrderLines.Add(orderline);



                    }

                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    _idb.SaveChanges();
                }

            }








        }


    }




  
   



}