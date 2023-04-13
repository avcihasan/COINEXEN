using AutoMapper;
using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Enums;
using COINEXEN.Core.Repositories;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Core.ViewModels;
using COINEXEN.Core.ViewModels.BasketVMs;
using COINEXEN.Core.ViewModels.CoinVMs;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Service.Services
{
    public class CoinService : GenericService<Coin>, ICoinService
    {
        readonly IMapper _mapper;

        public CoinService(IGenericRepository<Coin> repo, IUnitOfWork unitOfWork, IMapper mapper) : base(repo, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<GetCoinVM>> GetAllCoinsAsync()
        {
            List<Coin> coins = await _unitOfWork.CoinRepository.GetAllCoinWithCategories().ToListAsync();
            return _mapper.Map<List<GetCoinVM>>(coins);
        }

        public async Task<GetCoinVM> GetCoinByIdAsync(string id)
        {
            Coin coin = await _unitOfWork.CoinRepository.GetCoinByIdWithCategoryAsync(id);
            return _mapper.Map<GetCoinVM>(coin);
        }


        public async Task<bool> SellCoinAsync(string Id, int satisSayisi, string UserName)
        {
            AppUser user = await _unitOfWork.UserRepository.GetUserWithPropertiesAsync(UserName);
            Coin coin = await _unitOfWork.CoinRepository.GetByIdAsync(Id);
            CoinWalletLine coinWalletLine = user.CoinWallet.CoinWalletLines.FirstOrDefault(x => x.Coin.Id == Guid.Parse(Id));
            if (coinWalletLine.Coin == null)
                return false;
            bool result =await UpdateCoinStockAsync(coinWalletLine,Guid.Parse(Id), satisSayisi, Transaction.Sell);
            if (!result)
                return false;
            await CreateSellTransactionAsync(user, coin, satisSayisi);
            UpdateUserWalletBalance(user.Wallet, coin.Price * satisSayisi, Transaction.Sell);
            await _unitOfWork.CommitAsync();
            return true;
        }


        public async Task<bool> BuyCoinAsync(BasketVM basket, string userName)
        {
            AppUser user = await _unitOfWork.UserRepository.GetUserWithPropertiesAsync(userName);

            CoinWallet wallet = user.CoinWallet;
            CoinWalletLine walletLine = new() { CoinId = basket.Coin.Id, CoinWalletId = wallet.Id, Quantity = basket.Quantity };
            bool temp = false;
            if (wallet.CoinWalletLines != null)
                for (int i = 0; i < wallet.CoinWalletLines.Count; i++)
                    if (wallet.CoinWalletLines[i].Coin.Id == basket.Coin.Id)
                    {
                        wallet.CoinWalletLines[i].Quantity += basket.Quantity;
                        temp = true;
                        break;
                    }
            if (!temp)
                wallet.CoinWalletLines.Add(walletLine);

            bool updateWallet = UpdateUserWalletBalance(user.Wallet, (basket.Quantity * basket.Coin.Price),Transaction.Buy);
            bool updateCoinStock =await UpdateCoinStockAsync(walletLine, basket.Coin.Id, basket.Quantity, Transaction.Buy);

            if (!(updateWallet && updateCoinStock))
                return false;

            await CreateBuyTransactionAsync(user, basket);

            await _unitOfWork.CommitAsync();
            return true;
        }
        private async Task<bool> CreateBuyTransactionAsync(AppUser user, BasketVM basket)
        {
            CoinTransaction coinTransaction = new()
            {
                AppUserId = user.Id,
                CoinId = basket.Coin.Id,
                CoinPrice = basket.Coin.Price,
                DateOfTransaction = DateTime.Now,
                Quantity = basket.Quantity,
                Transaction = Transaction.Buy
            };
            return await _unitOfWork.CoinTransactionRepository.CreateAsync(coinTransaction);
        }
        private async Task<bool> CreateSellTransactionAsync(AppUser user, Coin coin, int satisSayisi)
        {
            CoinTransaction coinTransaction = new()
            {
                AppUserId = user.Id,
                CoinId = coin.Id,
                CoinPrice = coin.Price,
                DateOfTransaction = DateTime.Now,
                Quantity = satisSayisi,
                Transaction = Transaction.Sell
            };
            return await _unitOfWork.CoinTransactionRepository.CreateAsync(coinTransaction);
        }
        private async Task<bool> UpdateCoinStockAsync(CoinWalletLine walletLine,Guid coinId, int islemSayisi, Transaction transaction)
        {
            Coin coin = await _unitOfWork.CoinRepository.GetCoinByIdWithCategoryAsync(coinId.ToString()); 
            if (transaction == Transaction.Buy)
            {
                if (coin.Stock < islemSayisi)
                    return false;
                coin.Stock -= islemSayisi;
            }
            else
            {
                if (walletLine.Quantity < islemSayisi)
                    return false;

                walletLine.Quantity -= islemSayisi;
                coin.Stock += islemSayisi;
            }

            return true;
        }
        private bool UpdateUserWalletBalance(UserWallet wallet, double totalPrice, Transaction transaction)
        {
            if (transaction == Transaction.Buy)
            {
                if (wallet.Balance < totalPrice)
                    return false;
                wallet.Balance -= totalPrice;
                return true;
            }
            wallet.Balance += totalPrice;
            return true;

        }
    }
}
