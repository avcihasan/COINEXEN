using COINEXEN.Core.Entities;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace COINEXEN.Service.Services
{
    public class BasketService : IBasketService
    {
        readonly IUnitOfWork _unitOfWork;

        public BasketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Basket GetBasket(HttpContext httpContext)
        {
            Basket basket = JsonConvert.DeserializeObject<Basket>(httpContext.Session.GetString("Basket"));
            if (basket == null)
            {
                basket = new Basket();
                httpContext.Session.SetString("Basket", JsonConvert.SerializeObject(basket));
            }
            return basket;
        }


        public async Task AddCoinToBasketAsync(HttpContext httpContext,string coinId, int alimSayisi)
        {
            Coin coin = await _unitOfWork.CoinRepository.GetByIdAsync(coinId);
            if (coin != null)
            {
                Basket basket=GetBasket(httpContext);
                if (basket.Coin == coin)
                    basket.Quantity += alimSayisi;
                else
                {
                    basket.Coin = coin;
                    basket.Quantity = alimSayisi;
                }
                httpContext.Session.SetString("Basket", JsonConvert.SerializeObject(basket));
            }
        }


        //public  bool RemoveCoinFromBasketAsync(HttpContext httpContext, string id, int alimSayisi, string userName)
        //{
        //    return true;
        //}
    }
}
