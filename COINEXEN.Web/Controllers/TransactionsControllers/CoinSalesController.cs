using Microsoft.AspNetCore.Mvc;

namespace COINEXEN.Web.Controllers.TransactionsControllers
{
    public class CoinSalesController : Controller
    {
        public IActionResult PreSale()
               => View();
        public IActionResult PreSaleDetails()
               => View();
    }
}
