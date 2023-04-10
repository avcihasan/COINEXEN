using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Web.Areas.AdminPanel.Controllers
{
    [Area("adminPanel")]
    public class TransactionsController : Controller
    {

        readonly IUnitOfWork _unitOfWork;

        public TransactionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Purchases()
            => View(await _unitOfWork.CoinTransactionRepository.GetCoinTransactions(Core.Enums.Transaction.Buy).ToListAsync());

        public async Task<IActionResult> Sales()
            => View(await _unitOfWork.CoinTransactionRepository.GetCoinTransactions(Core.Enums.Transaction.Sell).ToListAsync());
    }
}
