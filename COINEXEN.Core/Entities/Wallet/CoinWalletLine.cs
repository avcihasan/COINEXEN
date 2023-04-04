namespace COINEXEN.Core.Entities.Wallet
{
    public class CoinWalletLine : BaseEntity
    {
        public int CoinId { get; set; }
        public Coin Coin { get; set; }
        public int Quantity { get; set; }

        public int CoinWalletId { get; set; }
        public CoinWallet CoinWallet { get; set; }


    }
}
