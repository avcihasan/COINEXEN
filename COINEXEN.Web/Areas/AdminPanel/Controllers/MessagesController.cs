using COINEXEN.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.Areas.AdminPanel.Controllers
{
    [Area("adminPanel")]
    public class MessagesController : Controller
    {
        readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        public async Task<IActionResult> Index()
            => View(await _messageService.GetAllMessagesAsync());

        public async Task<IActionResult> MessageDetails(string id)
            => View(await _messageService.GetMessageById(id));
    }
}
