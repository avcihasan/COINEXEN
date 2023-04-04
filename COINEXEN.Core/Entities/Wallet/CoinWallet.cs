using COINEXEN.Core.Entities.Identity;

namespace COINEXEN.Core.Entities.Wallet
{
    public class CoinWallet : BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public List<CoinWalletLine> CoinWalletLines { get; set; }

    }
}
