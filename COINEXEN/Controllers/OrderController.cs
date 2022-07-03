using COINEXEN.Entity;
using COINEXEN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COINEXEN.Controllers
{
    [Authorize(Roles ="admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var alimlar = db.CuzdanAlims.ToList().OrderByDescending(i => i.AlimDate);


         
            return View(alimlar);
        }

        public ActionResult Satis()
        {
            var satis = db.CuzdanSatiss.ToList().OrderByDescending(i => i.SatisDate);


            return View(satis);

        }

    }
}