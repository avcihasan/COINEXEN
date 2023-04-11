using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Enums;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

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
            Basket basket;
            if (httpContext.Session.GetString(httpContext.User.Identity.Name) == null)
            {
                basket = new();
                httpContext.Session.SetString(httpContext.User.Identity.Name, JsonSerializer.Serialize(basket));
            }
            else
                basket = JsonSerializer.Deserialize<Basket>(httpContext.Session.GetString(httpContext.User.Identity.Name));
            return basket;
        }


        public async Task AddCoinToBasketAsync(HttpContext httpContext, string coinId, int alimSayisi)
        {
            Coin coin = await _unitOfWork.CoinRepository.GetByIdAsync(coinId);
            if (coin != null)
            {
                Basket basket = GetBasket(httpContext);
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


        public async Task<bool> SellCoinAsync(string Id, int satisSayisi, string UserName)
        {
            AppUser user = await _unitOfWork.UserRepository.GetUserWithPropertiesAsync(UserName);
            Coin coin = await _unitOfWork.CoinRepository.GetByIdAsync(Id);

            CoinWalletLine coinWalletLine = user.CoinWallet.CoinWalletLines.FirstOrDefault(x => x.Coin.Id ==Guid.Parse(Id));
 
            if (coinWalletLine.Coin==null)
                return false;
            if (coinWalletLine.Quantity < satisSayisi)
                return false;

            CoinTransaction coinTransaction = new()
            {
                AppUserId = user.Id,
                CoinId = coin.Id,
                CoinPrice = coin.Price,
                DateOfTransaction = DateTime.Now,
                Quantity = satisSayisi,
                Transaction = Transaction.Sell
            };
            if (coinWalletLine.Quantity > satisSayisi)
                coinWalletLine.Quantity -= satisSayisi;
            else 
                user.CoinWallet.CoinWalletLines.Remove(coinWalletLine);  

            user.Wallet.Balance += (coin.Price * satisSayisi);
            coin.Stock += satisSayisi;
            await _unitOfWork.CoinTransactionRepository.CreateAsync(coinTransaction);

            await _unitOfWork.CommitAsync();
            return true;
        }


        public async Task BuyCoinAsync(Basket basket, string userName, Transaction transaction)
        {
            AppUser user = await _unitOfWork.UserRepository.GetUserWithPropertiesAsync(userName);
            CoinTransaction coinTransaction = new()
            {
                AppUserId = user.Id,
                CoinId = basket.Coin.Id,
                CoinPrice = basket.Coin.Price,
                DateOfTransaction = DateTime.Now,
                Quantity = basket.Quantity
            };

            if (transaction == Transaction.Buy)
                coinTransaction.Transaction = Transaction.Buy;
            else if (transaction == Transaction.Sell)
                coinTransaction.Transaction = Transaction.Sell;

            //todo iyileştirme
            var cuzdan = user.CoinWallet;
            if (cuzdan.CoinWalletLines == null)
                cuzdan.CoinWalletLines.Add(new() { CoinId = basket.Coin.Id, CoinWalletId = cuzdan.Id, Quantity = basket.Quantity });
            else
            {
                bool temp = false;
                foreach (CoinWalletLine walletLines in user.CoinWallet.CoinWalletLines)
                    if (walletLines.Coin.Id == basket.Coin.Id)
                    {
                        walletLines.Quantity += basket.Quantity;
                        temp = true;
                    }
                if (!temp)
                    cuzdan.CoinWalletLines.Add(new() { CoinId = basket.Coin.Id, CoinWalletId = cuzdan.Id, Quantity = basket.Quantity });
            }
            user.Wallet.Balance -= (basket.Quantity*basket.Coin.Price);
            Coin coin = await _unitOfWork.CoinRepository.GetByIdAsync(basket.Coin.Id.ToString());
            coin.Stock -= basket.Quantity;
            await _unitOfWork.CoinTransactionRepository.CreateAsync(coinTransaction);
            await _unitOfWork.CommitAsync();
        }


    }
}
