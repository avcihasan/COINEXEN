using COINEXEN.Core.Entities;
using COINEXEN.Core.Enums;
using COINEXEN.Core.ViewModels.BasketVMs;
using Microsoft.AspNetCore.Http;

namespace COINEXEN.Core.Services
{
    public interface IBasketService
    {
        BasketVM GetBasket(HttpContext httpContext);
        Task AddCoinToBasketAsync(HttpContext httpContext, string coinId, int alimSayisi);

    }
}
