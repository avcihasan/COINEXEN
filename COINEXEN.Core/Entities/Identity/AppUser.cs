using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace COINEXEN.Core.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public City City { get; set; }
        public Gender Gender { get; set; }
        public int Birthday { get; set; }


        public CoinWallet CoinWallet { get; set; }
        public UserWallet Wallet { get; set; }
    }
}
