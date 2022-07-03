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
    public class AlSatController : Controller
    {

        DataContext _context = new DataContext();
      

        // GET: AlSat
        public ActionResult Index(int? id)
        {
            var coinler = _context.Coin.Select(i => new CoinModel()
            {
                Id = i.Id,
                KısaKod = i.KısaKod,
                Name = i.Name,
                Price = i.Price,
                CategoryId=i.CategoryId,
                OldPrice=i.OldPrice
                


            }
            ).AsQueryable();

            if (id!=null)
            {
                coinler = coinler.Where(i => i.CategoryId == id);
            }

            return View(coinler.ToList());
        }

        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());
        }
        public PartialViewResult GetCategoriesMobile()
        {
            return PartialView(_context.Categories.ToList());
        }


      
    }
}