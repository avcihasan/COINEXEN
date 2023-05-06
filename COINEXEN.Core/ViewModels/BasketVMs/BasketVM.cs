using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.ViewModels.CoinVMs;

namespace COINEXEN.Core.ViewModels.BasketVMs
{
    public class BasketVM
    {
        public int AppUserId { get; set; }
        public GetCoinVM Coin { get; set; }
        public int Quantity { get; set; }
       
    }
}
