using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            await Task.CompletedTask;
            return View("_FooterPartial");
        }
    }
}
