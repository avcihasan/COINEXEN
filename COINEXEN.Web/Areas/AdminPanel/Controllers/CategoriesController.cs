using COINEXEN.Core.Entities;
using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace COINEXEN.Web.Areas.AdminPanel.Controllers
{
    [Area("adminPanel")]
    public class CategoriesController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ICategoryService _categoryService;

        public CategoriesController(IUnitOfWork unitOfWork, ICategoryService categoryService)
        {
            _unitOfWork = unitOfWork;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
            => View(await _unitOfWork.CategoryRepository.GetAll().ToListAsync());


        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            Category category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category != null)
                return View(category);
            return NotFound();
        }

        public IActionResult Create()
            => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
                if (await _categoryService.CreateAsync(category))
                    return RedirectToAction("Index");
            return View(category);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
                return BadRequest();
            Category category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category != null)
                return View(category);
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
                if (await _categoryService.UpdateAsync(category))
                    return RedirectToAction("Index");
            return View(category);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            Category category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            if (category != null)
                return View(category);
            return NotFound();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (id == null)
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            if (await _categoryService.RemoveByIdAsync(id))
                return RedirectToAction("Index");
            return BadRequest();
        }
    }
}
