using COINEXEN.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.ViewComponents
{
    public class BasketModalViewComponent:ViewComponent
    {
        readonly ICoinService _coinService;

        public BasketModalViewComponent(ICoinService coinService)
        {
            _coinService = coinService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
            => View("_BasketModalPartial", await _coinService.GetCoinByIdAsync(id));
    }
}
