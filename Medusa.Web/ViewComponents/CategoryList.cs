using Medusa.WebUI.ApiServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Medusa.WebUI.ViewComponents
{
    public class CategoryList : ViewComponent
    {
        private readonly ICategoryApiService _categoryApiService;

        public CategoryList(ICategoryApiService categoryApiService)
        {
            this._categoryApiService = categoryApiService;
        }
        public IViewComponentResult Invoke()
        {
            // async method kullanılamaz bu sebeple await yazılamaz
            // ilgili sonuc gelene kadar beklemesi için  result kullanılır
            return View(_categoryApiService.GetAllWithBlogsCountAsync().Result);
        }
    }
}
