using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Web.Controllers
{
    //[Authorize(Roles ="admin")]
    public class OrderController : Controller
    {
        readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
            => View(await _unitOfWork.CoinTransactionRepository.GetCoinTransactions(Core.Enums.Transaction.Buy).ToListAsync());
       
        public async Task<IActionResult> Satis()
            => View(await _unitOfWork.CoinTransactionRepository.GetCoinTransactions(Core.Enums.Transaction.Sell).ToListAsync());
    }
}