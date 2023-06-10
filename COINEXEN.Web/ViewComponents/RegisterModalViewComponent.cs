using COINEXEN.Core.ViewModels.UserVMs;
using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.ViewComponents
{
    public class RegisterModalViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.CompletedTask;
            return View("_RegisterModalPartial", new RegisterVM());
        }
    }
}
