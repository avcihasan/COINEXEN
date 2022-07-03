using COINEXEN.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COINEXEN.Controllers
{
    public class CoinDetayController : Controller
    {
        DataContext _context = new DataContext();

        // GET: CoinDetay
        public ActionResult Index(int id)
        {
            return View(_context.Coin.Where(i=> i.Id==id).FirstOrDefault());
        }
    }
}