using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.ViewModels.WalletVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COINEXEN.Core.Services
{
    public interface IWalletService
    {
        Task CreateWalletsAsync(AppUser user);
        Task<UserWalletVM> GetUserWalletAsync(string userName);
        Task<CoinWalletVM> GetCoinWalletAsync(string userName);
    }
}
