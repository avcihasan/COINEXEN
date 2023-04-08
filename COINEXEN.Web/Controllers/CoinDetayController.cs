using COINEXEN.Core.Entities;
using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace COINEXEN.Controllers
{
    public class CoinDetayController : Controller
    {
        readonly IUnitOfWork _unitOfWork;

        public CoinDetayController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index(string id)
        {
            if (id == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            Coin coin = await _unitOfWork.CoinRepository.GetCoinByIdWithCategoryAsync(id);
            if (coin == null)
                return NotFound();
            return View(coin);
        }
    }
}