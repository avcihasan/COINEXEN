using COINEXEN.Core.Entities.Identity;

namespace COINEXEN.Core.Entities
{
    public class Basket:BaseEntity
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Guid CoinId { get; set; }
        public Coin Coin { get; set; }
        public int Quantity { get; set; }
    }
}
