using COINEXEN.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace COINEXEN.Core.Services
{
    public interface IBasketService
    {
        Basket GetBasket(HttpContext httpContext);
        Task AddCoinToBasketAsync(HttpContext httpContext, string coinId, int alimSayisi);
    }
}
