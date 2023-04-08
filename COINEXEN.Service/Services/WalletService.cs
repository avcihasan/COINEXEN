using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Repositories;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using System.Security.AccessControl;

namespace COINEXEN.Service.Services
{
    public class WalletService : IWalletService
    {
        readonly IUnitOfWork _unitOfWork;

        public WalletService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateWalletsAsync(AppUser user)
        {
            bool userWallet = await CreateUserWalletAsync(user, 1000.0);
            bool coinWallet = await CreateCoinWalletAsync(user);
            if (!(userWallet && coinWallet))
                throw new Exception("Hata");

            await _unitOfWork.CommitAsync();
        }

        private async Task<bool> CreateUserWalletAsync(AppUser user, double balance)
        {
            UserWallet wallet = new() { Id = user.Id, Balance = balance };
            bool result = await _unitOfWork.UserWalletRepository.CreateAsync(wallet);
            return result;
        }
        private async Task<bool> CreateCoinWalletAsync(AppUser user)
        {
            CoinWallet wallet = new() { Id = user.Id };
            bool result = await _unitOfWork.CoinWalletRepository.CreateAsync(wallet);
            return result;
        }

        public async Task<UserWallet> GetUserWalletAsync(AppUser user)
            => await _unitOfWork.UserWalletRepository.GetUserWallatByUserIdAsync(user.Id.ToString());
        

        public async Task<CoinWallet> GetCoinWalletAsync(AppUser user)
            => await _unitOfWork.CoinWalletRepository.GetCoinWallatByUserIdAsync(user.Id.ToString());
        
    }
}
