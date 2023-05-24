using AutoMapper;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Repositories;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Core.ViewModels.WalletVm;
using Microsoft.AspNetCore.Identity;
using System.Security.AccessControl;

namespace COINEXEN.Service.Services
{
    public class WalletService : IWalletService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IMapper _mapper;
        public WalletService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            UserWallet wallet = new() { Id = user.Id, Balance = balance};
            bool result = await _unitOfWork.UserWalletRepository.CreateAsync(wallet);
            return result;
        }
        private async Task<bool> CreateCoinWalletAsync(AppUser user)
        {
            CoinWallet wallet = new() { Id = user.Id };
            bool result = await _unitOfWork.CoinWalletRepository.CreateAsync(wallet);
            return result;
        }

        public async Task<UserWalletVM> GetUserWalletAsync(string userName)
            =>_mapper.Map<UserWalletVM>(await _unitOfWork.UserWalletRepository.GetUserWallatByUserNameAsync(userName));
        

        public async Task<CoinWalletVM> GetCoinWalletAsync(string userName)
            => _mapper.Map<CoinWalletVM>(await _unitOfWork.CoinWalletRepository.GetCoinWallatByUserNameAsync(userName));
        

    }
}
