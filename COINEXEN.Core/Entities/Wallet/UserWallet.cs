using COINEXEN.Core.Entities.Identity;

namespace COINEXEN.Core.Entities.Wallet
{
    public class UserWallet : BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public double Balance { get; set; }
    }
}
