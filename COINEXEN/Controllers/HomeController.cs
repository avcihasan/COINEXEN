using COINEXEN.Entity;
using COINEXEN.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COINEXEN.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();
        IdentityDataContext context = new IdentityDataContext();

        // GET: Home
        public ActionResult Index()
        {
          
            return View();
        }



        public ActionResult Message()
        {


            return View();
        }

        // POST: New/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Message(Message message)
        {

            if (Request.IsAuthenticated)
            {
                var user = context.Users.Where(i=>i.UserName==User.Identity.Name).FirstOrDefault();
                if (user!=null)
                {
                    var mesaj = new Message();
                    mesaj.Ad = user.Name;
                    mesaj.SoyAd = user.Surname;
                    mesaj.Eposta = user.Email;
                    mesaj.KullaniciAdi = user.UserName;
                    mesaj.PhoneNumber = user.PhoneNumber;
                    mesaj.KonuBaslik = message.KonuBaslik;
                    mesaj.Detay = message.Detay;
                    mesaj.GonderimTarihi = DateTime.Now;

                    _context.Messages.Add(mesaj);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }




            else
            {


                if (ModelState.IsValid)
                {
                    var mesaj = new Message();
                    mesaj.Ad = message.Ad;
                    mesaj.SoyAd = message.SoyAd;
                    mesaj.Eposta = message.Eposta;
                    mesaj.KullaniciAdi = message.KullaniciAdi;
                    mesaj.PhoneNumber = message.PhoneNumber;
                    mesaj.KonuBaslik = message.KonuBaslik;
                    mesaj.Detay = message.Detay;
                    mesaj.GonderimTarihi = DateTime.Now;
                    mesaj.City = message.City;


                    _context.Messages.Add(mesaj);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }


            return View(message);
        }


    }
}