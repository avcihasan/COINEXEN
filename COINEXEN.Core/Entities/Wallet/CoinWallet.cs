using COINEXEN.Core.Entities.Identity;

namespace COINEXEN.Core.Entities.Wallet
{
    public class CoinWallet : BaseEntity
    {
        public AppUser AppUser { get; set; }

        public List<CoinWalletLine> CoinWalletLines { get; set; } = new();

    }
}
