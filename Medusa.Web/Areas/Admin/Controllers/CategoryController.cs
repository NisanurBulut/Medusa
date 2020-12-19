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
        public async Task<IActionResult> CreateCategory(int id)
        {
            if (id == 0)
                return PartialView("PartialCategory", new CategoryUpdateModel());
            else
            {
                var category = await _categoryApiService.GetByIdAsync(id);
                var categoryUpdate = new CategoryUpdateModel
                {
                    Id = category.Id,
                    Name = category.Name
                };
                return PartialView("PartialCategory", categoryUpdate);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryUpdateModel item)
        {
            if (ModelState.IsValid)
            {
                if (item.Id == 0)
                {
                    var categoryAdd = new CategoryAddModel
                    {
                        Name = item.Name
                    };
                    await _categoryApiService.AddAsync(categoryAdd);
                }
                else
                {
                    await _categoryApiService.UpdateAsync(item);
                }

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
