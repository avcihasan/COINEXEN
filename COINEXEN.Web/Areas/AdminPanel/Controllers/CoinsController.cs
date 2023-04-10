using COINEXEN.Core.Entities;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace COINEXEN.Web.Areas.AdminPanel.Controllers
{
    [Area("adminPanel")]
    public class CoinsController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ICoinService _coinService;
        public CoinsController(IUnitOfWork unitOfWork, ICoinService coinService)
        {
            _unitOfWork = unitOfWork;
            _coinService = coinService;
        }
        public async Task<IActionResult> Index()
            => View(await _unitOfWork.CoinRepository.GetAllCoinWithCategories().ToListAsync());

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            Coin coin = await _unitOfWork.CoinRepository.GetCoinByIdWithCategoryAsync(id);
            if (coin == null)
                return NotFound();
            return View(coin);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _unitOfWork.CategoryRepository.GetAll().ToListAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Coin coin)
        {
            if (ModelState.IsValid)
                if (await _coinService.CreateAsync(coin))
                    return RedirectToAction("Index");
            ViewBag.CategoryId = new SelectList(await _unitOfWork.CategoryRepository.GetAll().ToListAsync(), "Id", "Name", coin.CategoryId);
            return View(coin);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            Coin coin = await _unitOfWork.CoinRepository.GetByIdAsync(id);
            if (coin == null)
                return NotFound();
            ViewBag.CategoryId = new SelectList(_unitOfWork.CategoryRepository.GetAll(), "Id", "Name", coin.CategoryId);
            return View(coin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Coin coin)
        {
            if (ModelState.IsValid)
                if (await _coinService.UpdateAsync(coin))
                    return RedirectToAction("Index");
            ViewBag.CategoryId = new SelectList(_unitOfWork.CategoryRepository.GetAll(), "Id", "Name", coin.CategoryId);
            return View(coin);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            Coin coin = await _unitOfWork.CoinRepository.GetCoinByIdWithCategoryAsync(id);
            if (coin == null)
                return NotFound();
            return View(coin);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            if (await _coinService.RemoveByIdAsync(id))
                return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
