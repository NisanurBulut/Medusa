using AutoMapper;
using Medusa.Business.Interface;
using Medusa.DataTransferObject;
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
    }
}
