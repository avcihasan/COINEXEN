using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace COINEXEN.Core.Entities.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public City City { get; set; }
        //public Gender Gender { get; set; }
        public int Birthday { get; set; }


        public CoinWallet CoinWallet { get; set; }
        public int WalletId { get; set; }
        public UserWallet Wallet { get; set; }
    }
}
