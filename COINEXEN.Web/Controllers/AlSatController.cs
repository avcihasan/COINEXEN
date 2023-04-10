using COINEXEN.Core.Entities;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace COINEXEN.Web.Controllers
{
    public class AlSatController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ICoinService _coinService;

        public AlSatController(IUnitOfWork unitOfWork, ICoinService coinService)
        {
            _unitOfWork = unitOfWork;
            _coinService = coinService;
        }
        public async Task<IActionResult> Index(string id)
        {
            ViewBag.kategoriler =_unitOfWork.CategoryRepository.GetAll();
            return View(await _coinService.GetAllCoinsAsync());
        }

        public async Task<IActionResult> GetCategories()
            =>PartialView(await _unitOfWork.CategoryRepository.GetAll().ToListAsync());

        public async Task<IActionResult> GetCategoriesMobile()
            => PartialView(await _unitOfWork.CategoryRepository.GetAll().ToListAsync());


        public async Task<IActionResult> CoinDetails(string id)
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