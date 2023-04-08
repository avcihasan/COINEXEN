using COINEXEN.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.Controllers
{
    //[Authorize(Roles = "admin")]
    public class AdminPanelController : Controller
    {
        readonly IMessageService _messageService;

        public AdminPanelController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Index()
            => View();

        public async Task<IActionResult> Messages()
            => View(await _messageService.GetAllMessagesAsync());

        public async Task<IActionResult> MessageDetails(string id)
            => View(await _messageService.GetMessageById(id));
    }
}