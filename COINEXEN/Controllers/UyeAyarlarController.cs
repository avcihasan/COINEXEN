using COINEXEN.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COINEXEN.Controllers
{
    [Authorize]
    public class UyeAyarlarController : Controller
    {
        IdentityDataContext db = new IdentityDataContext();

        // GET: UyeAyarlar
        public ActionResult Index()
        {
            var user = db.Users.Where(i => i.UserName == User.Identity.Name).FirstOrDefault();

            return View(user);
        }
    }
}