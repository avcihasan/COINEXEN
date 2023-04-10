using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.Areas.AdminPanel.Controllers
{
    [Area("adminPanel")]
    public class HomeController : Controller
    {
        public IActionResult Index()
             => View();
    }
}
