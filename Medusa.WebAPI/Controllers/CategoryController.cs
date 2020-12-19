using AutoMapper;
using Medusa.Business.Interface;
using Medusa.DataTransferObject;
using Medusa.Entities;
using Medusa.WebAPI.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medusa.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            this._mapper = mapper;
            this._categoryService = categoryService;
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAllSortedById()
        {
            return Ok(_mapper.Map<List<CategoryDto>>(await _categoryService.GetAllSortedById()));
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(ValidIdModel<CategoryEntity>))]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(_mapper.Map<CategoryDto>(await _categoryService.FindByIdAsync(id)));
        }
     
        [HttpPost("[action]")]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> CreateCategory(CategoryAddDto model)
        {
            await _categoryService.AddAsync(_mapper.Map<CategoryAddDto, CategoryEntity>(model));
            return Created("", model);
        }

        [HttpPut("[action]")]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDto model)
        {
            await _categoryService.UpdateAsync(_mapper.Map<CategoryUpdateDto, CategoryEntity>(model));
            return NoContent();
        }

        [HttpDelete("[action]")]
        [Authorize]
        [ServiceFilter(typeof(ValidIdModel<CategoryEntity>))]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.RemoveAsync(await _categoryService.FindByIdAsync(id));
            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetWithBlogsWithCount()
        {
            var categories = await _categoryService.GetAllWithCategoryBlogAsync();
            List<CategoryWithBlogsCountDto> listCategoryBlog = new List<CategoryWithBlogsCountDto>();
            foreach (var item in categories)
            {
                CategoryWithBlogsCountDto categoryWithBlogs = new CategoryWithBlogsCountDto();
                categoryWithBlogs.CategoryId = item.Id;
                categoryWithBlogs.CategoryName = item.Name;
                categoryWithBlogs.BlogsCount = item.CategoryBlogs.Count;
                listCategoryBlog.Add(categoryWithBlogs);
            }

            return Ok(listCategoryBlog);
        }
    }
}