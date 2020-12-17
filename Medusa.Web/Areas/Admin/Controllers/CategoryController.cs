using Medusa.WebUI.ApiServices.Interfaces;
using Medusa.WebUI.Filters;
using Medusa.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace Medusa.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryApiService _categoryApiService;
        public CategoryController(ICategoryApiService categoryApiService)
        {
            this._categoryApiService = categoryApiService;
        }
        [JwtAuthorize]
        public async Task<IActionResult> Index()
        {
            return View(await _categoryApiService.GetAllAsync());
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View(new CategoryAddModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryAddModel item)
        {
            if (ModelState.IsValid)
            {
                await _categoryApiService.AddAsync(item);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Updatecategory(int id)
        {
            var category = await _categoryApiService.GetByIdAsync(id);
            var categoryUpdate = new CategoryUpdateModel
            {
                Id= category.Id,
                Name = category.Name
            };
            return View(categoryUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                await _categoryApiService.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryApiService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
