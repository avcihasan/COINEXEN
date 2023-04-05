using COINEXEN.Core.Entities.Identity;

namespace COINEXEN.Core.Entities.Wallet
{
    public class UserWallet : BaseEntity
    {
        
        public AppUser AppUser { get; set; }

        public double Balance { get; set; }
    }
}
