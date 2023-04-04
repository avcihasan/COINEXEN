using COINEXEN.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
            => View();

        public ActionResult Message()
            =>View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Message(Message message)
        {        

            return RedirectToAction("Index", "Home");
        }


    }
}