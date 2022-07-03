using COINEXEN.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COINEXEN.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminPanelController : Controller
    {
        DataContext db = new DataContext();


        // GET: AdminPanel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Messages()
        {
            var mesajlar = db.Messages.ToList().OrderByDescending(i => i.GonderimTarihi);

            return View(mesajlar);

        }

        public ActionResult MessageDetails(int Id)
        {
            var mesaj = db.Messages.Where(i => i.Id == Id).FirstOrDefault();


            return View(mesaj);

        }
    }
}