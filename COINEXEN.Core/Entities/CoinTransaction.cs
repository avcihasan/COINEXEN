using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Enums;

namespace COINEXEN.Core.Entities
{
    public class CoinTransaction:BaseEntity
    {
        public Transaction Transaction { get; set; }
        public Guid CoinId { get; set; }
        public Coin Coin { get; set; }
        public int Quantity { get; set; }
        public double CoinPrice { get; set; }
        public DateTime DateOfTransaction { get; set; }

        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
