using AutoMapper;
using Medusa.Business.Interface;
using Medusa.DataTransferObject;
using Medusa.Entities;
using Medusa.WebAPI.Models;
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
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetBlogById(int id)
        {
            return Ok(_mapper.Map<BlogEntity, BlogDto>(await _blogService.FindByIdAsync(id)));
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromForm] BlogAddModel model)
        {
            var uploadModel = await UploadFile(model.Image, "image/jpeg");
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
        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateBlog([FromForm] BlogUpdateModel model, int id)
        {
            if (model.Id != id) return BadRequest("Geçersiz id bilgisi");
            var uploadModel = await UploadFile(model.Image, "image/jpeg");

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
        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _blogService.RemoveAsync(new BlogEntity() { Id = id });
            return NoContent();
        }
    }
}
