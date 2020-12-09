using AutoMapper;
using Medusa.Business.Interface;
using Medusa.DataTransferObject;
using Medusa.Entities;
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
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(_mapper.Map<CategoryDto>(await _categoryService.FindByIdAsync(id)));
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryAddDto model)
        {
            await _categoryService.AddAsync(_mapper.Map<CategoryAddDto, CategoryEntity>(model));
            return Created("", model);
        }
        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDto model, int id)
        {
            if (model.Id != id) return BadRequest("Geçersiz id bilgisi");
            
            await _categoryService.UpdateAsync(_mapper.Map<CategoryUpdateDto, CategoryEntity>(model));
            return NoContent();
        }
        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.RemoveAsync(new CategoryEntity() { Id = id });
            return NoContent();
        }
    }
}