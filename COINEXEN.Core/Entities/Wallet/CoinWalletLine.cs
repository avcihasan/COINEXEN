namespace COINEXEN.Core.Entities.Wallet
{
    public class CoinWalletLine : BaseEntity
    {
        public Guid CoinId { get; set; }
        public Coin Coin { get; set; }
        public int Quantity { get; set; }

        public Guid CoinWalletId { get; set; }
        public CoinWallet CoinWallet { get; set; }


    }
}
