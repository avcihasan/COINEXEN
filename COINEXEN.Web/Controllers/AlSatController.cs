using COINEXEN.Core.Services;
using COINEXEN.Core.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            =>View(await _coinService.GetCoinsAsync(id)); 

        public async Task<PartialViewResult> GetCategories()
            =>PartialView(await _unitOfWork.CategoryRepository.GetAll().ToListAsync());

        public async Task<PartialViewResult> GetCategoriesMobile()
            => PartialView(await _unitOfWork.CategoryRepository.GetAll().ToListAsync());
    }
}