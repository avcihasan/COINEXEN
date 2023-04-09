using COINEXEN.Core.Entities;
using COINEXEN.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace COINEXEN.Core.Services
{
    public interface IBasketService
    {
        Basket GetBasket(HttpContext httpContext);
        Task AddCoinToBasketAsync(HttpContext httpContext, string coinId, int alimSayisi);
        Task SaveOrderAsync(Basket basket, string userName, Transaction transaction);
        Task<bool> SellCoinAsync(string Id, int AlimSayisi, string UserName);
    }
}
