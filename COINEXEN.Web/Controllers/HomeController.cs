using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Services;
using COINEXEN.Core.ViewModels.MessageVMs;
using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly IMessageService _messageService;

        public HomeController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
            => View();
        public IActionResult AboutUs()
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Message(SetMessageVM message)
        {
            if (ModelState.IsValid)
            {
                bool result = await _messageService.CreateMessageAsync(message);
                if (result)
                    return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index","Home", message);
        }


    }
}