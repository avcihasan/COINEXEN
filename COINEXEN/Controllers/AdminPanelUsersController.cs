using COINEXEN.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace COINEXEN.Controllers
{
    public class AdminPanelUsersController : Controller
    {
        private IdentityDataContext _db = new IdentityDataContext();

        // GET: AdminPanelUsers
        public ActionResult Index()
        {
            var user = _db.Users.ToList().OrderBy(i => i.Id);
            return View(user);
        }
    }
}