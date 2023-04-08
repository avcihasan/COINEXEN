using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Entities.Wallet;
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
        Task<UserWallet> GetUserWalletAsync(AppUser user);
        Task<CoinWallet> GetCoinWalletAsync(AppUser user);
    }
}
