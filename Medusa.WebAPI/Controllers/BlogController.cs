using AutoMapper;
using Medusa.Business.Interface;
using Medusa.DataTransferObject;
using Medusa.Entities;
using Medusa.WebAPI.CustomFilters;
using Medusa.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medusa.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        public BlogController(IBlogService blogService, IMapper mapper)
        {
            this._mapper = mapper;
            this._blogService = blogService;
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            return Ok(_mapper.Map<List<BlogDto>>(await _blogService.GetAllSortedByPostedTimeAsync()));
        }
       
        [HttpGet("[action]")]
        [ServiceFilter(typeof(ValidIdModel<BlogEntity>))]
        public async Task<IActionResult> GetBlogById(int id)
        {
            return Ok(_mapper.Map<BlogEntity, BlogDto>(await _blogService.FindByIdAsync(id)));
        }

        [HttpPost("[action]")]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> CreateBlog([FromForm] BlogAddModel model)
        {
            var uploadModel = await UploadFile(model.Image);
            if (uploadModel.UploadState == Enums.UploadState.success)
            {
                await _blogService.AddAsync(_mapper.Map<BlogAddModel, BlogEntity>(model));
                return Created("", model);
            }
            else if (uploadModel.UploadState == Enums.UploadState.notexists)
            {
                await _blogService.AddAsync(_mapper.Map<BlogAddModel, BlogEntity>(model));
                return Created("", model);
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }


        [HttpPut("[action]")]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> UpdateBlog([FromForm] BlogUpdateModel model)
        {
            
            var uploadModel = await UploadFile(model.Image);

            if (uploadModel.UploadState == Enums.UploadState.success)
            {
                await _blogService.UpdateAsync(_mapper.Map<BlogUpdateModel, BlogEntity>(model));
                return NoContent();
            }
            else if (uploadModel.UploadState == Enums.UploadState.notexists)
            {
                await _blogService.UpdateAsync(_mapper.Map<BlogUpdateModel, BlogEntity>(model));
                return NoContent();
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpDelete("[action]")]
        [Authorize]
        [ServiceFilter(typeof(ValidIdModel<BlogEntity>))]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _blogService.RemoveAsync(new BlogEntity() { Id = id });
            return NoContent();
        }

        [HttpPost("[action]")]
        [Authorize]
        [ValidModel]
        public async Task<IActionResult> AddToCategory(CategoryBlogDto model)
        {
            await _blogService.AddToCategoryAsync(model);
            return Created("", model);
        }

        [HttpDelete("[action]")]
        [Authorize]
        public async Task<IActionResult> RemoveToCategory(CategoryBlogDto model)
        {
            await _blogService.RemoveToCategoryAsync(model);
            return NoContent();
        }
        [HttpGet("[action]")]
        [ServiceFilter(typeof(ValidIdModel<CategoryEntity>))]
        public async Task<IActionResult> GetAllByCategoryId(int id)
        {
            return Ok(await _blogService.GetAllByCategoryIdAsync(id));
        }
        [HttpGet("[action]")]
        [ServiceFilter(typeof(ValidIdModel<BlogEntity>))]
        public async Task<IActionResult> GetCategoriesByBlogIdAsync(int id)
        {
            return Ok(await _blogService.GetAllByCategoryIdAsync(id));
        }
    }
}
