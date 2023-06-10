using COINEXEN.Core.ViewModels.UserVMs;
using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.ViewComponents
{
    public class LoginModalViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.CompletedTask;
            return View("_LoginModalPartial",new LoginVM());
        }
    }
}
