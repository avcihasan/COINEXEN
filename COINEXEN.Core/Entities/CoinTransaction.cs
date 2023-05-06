using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Enums;

namespace COINEXEN.Core.Entities
{
    public class CoinTransaction:BaseEntity
    {
        public Transaction Transaction { get; set; }
        
        public int Quantity { get; set; }
        public double CoinPrice { get; set; }
        public DateTime DateOfTransaction { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int CoinId { get; set; }
        public Coin Coin { get; set; }
    }
}
