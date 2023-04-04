using COINEXEN.Core.Entities.Identity;

namespace COINEXEN.Core.Entities.BuyingAndSelling
{
    public class BuyCoin : BaseEntity
    {
        public int CoinId { get; set; }
        public Coin Coin { get; set; }
        public int Quantity { get; set; }
        public double CoinPrice { get; set; }
        public DateTime DateOfBuy { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
