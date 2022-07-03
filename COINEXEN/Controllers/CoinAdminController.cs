using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COINEXEN.Entity;

namespace COINEXEN.Controllers
{
    [Authorize(Roles ="admin")]
    public class CoinAdminController : Controller
    {
        private DataContext db = new DataContext();

        // GET: CoinAdmin
        public ActionResult Index()
        {
            var coin = db.Coin.Include(c => c.Category);
            return View(coin.ToList());
        }

        // GET: CoinAdmin/Details/5
        public ActionResult Details(int? id)
        {
            var coin = db.Coin.Include(c => c.Category).AsQueryable();
            if (id != null)
            {
                coin = coin.Where(i => i.CategoryId == id);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            if (coin == null)
            {
                return HttpNotFound();
            }
            return View(coin.FirstOrDefault());
        }

        // GET: CoinAdmin/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: CoinAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Photo,Description,Stock,Price,KısaKod,CategoryId")] Coin coin)
        {
            if (ModelState.IsValid)
            {
                db.Coin.Add(coin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", coin.CategoryId);
            return View(coin);
        }

        // GET: CoinAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coin coin = db.Coin.Find(id);
            if (coin == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", coin.CategoryId);
            return View(coin);
        }

        // POST: CoinAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Photo,Description,Stock,Price,KısaKod,CategoryId")] Coin coin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", coin.CategoryId);
            return View(coin);
        }

        // GET: CoinAdmin/Delete/5
        public ActionResult Delete(int? id)
        {

            var coin = db.Coin.Include(c => c.Category).AsQueryable();
            if (id != null)
            {
                coin = coin.Where(i => i.CategoryId == id);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (coin == null)
            {
                return HttpNotFound();
            }
            return View(coin.FirstOrDefault());
        }

        // POST: CoinAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coin coin = db.Coin.Find(id);
            db.Coin.Remove(coin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
