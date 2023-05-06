using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Enums;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Core.ViewModels.BasketVMs;
using COINEXEN.Core.ViewModels.CoinVMs;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace COINEXEN.Service.Services
{
    public class BasketService : IBasketService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ICoinService _coinService;

        public BasketService(IUnitOfWork unitOfWork, ICoinService coinService)
        {
            _unitOfWork = unitOfWork;
            _coinService = coinService;
        }

        public BasketVM GetBasket(HttpContext httpContext)
        {
            BasketVM basket;
            if (httpContext.Session.GetString(httpContext.User.Identity.Name) == null)
            {
                basket = new();
                httpContext.Session.SetString(httpContext.User.Identity.Name, JsonSerializer.Serialize(basket));
            }
            else
                basket = JsonSerializer.Deserialize<BasketVM>(httpContext.Session.GetString(httpContext.User.Identity.Name));
            return basket;
        }


        public async Task AddCoinToBasketAsync(HttpContext httpContext, int coinId, int alimSayisi)
        {
            GetCoinVM coin = await _coinService.GetCoinByIdAsync(coinId);
            if (coin != null)
            {
                BasketVM basket = GetBasket(httpContext);
                if (basket.Coin == coin)
                    basket.Quantity += alimSayisi;
                else
                {
                    basket.Coin = coin;
                    basket.Quantity = alimSayisi;
                }
                httpContext.Session.SetString(httpContext.User.Identity.Name, JsonSerializer.Serialize(basket));
            }
        }
    }
}
