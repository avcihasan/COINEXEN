using COINEXEN.Core.Entities.Identity;

namespace COINEXEN.Core.Entities.BuyingAndSelling
{
    public class SellCoin : BaseEntity
    {
        public Guid CoinId { get; set; }
        public Coin Coin { get; set; }
        public int Quantity { get; set; }
        public double CoinPrice { get; set; }
        public DateTime DateOfSell { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
