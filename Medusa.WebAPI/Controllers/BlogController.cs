using AutoMapper;
using Medusa.Business.Interface;
using Medusa.DataTransferObject;
using Medusa.Entities;
using Medusa.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Medusa.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
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
            return Ok(_mapper.Map<BlogEntity,BlogDto>(await _blogService.FindByIdAsync(id)));
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromForm]BlogAddModel model)
        {
            if (model.Image != null)
            {
                if (model.Image.ContentType != "image/jpeg") return BadRequest("Uygunsuz dosya türü");
                var newName = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newName);
                var stream = new FileStream(path, FileMode.Create);

                await model.Image.CopyToAsync(stream);
                model.ImagePath = newName;
            }
            await _blogService.AddAsync(_mapper.Map<BlogAddModel, BlogEntity>(model));
            return Created("", model);
        }
        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> UpdateBlog([FromForm]BlogUpdateModel model, int id)
        {
            if (model.Id != id) return BadRequest("Geçersiz id bilgisi");
            if (model.Image != null)
            {
                if (model.Image.ContentType != "image/jpeg") return BadRequest("Uygunsuz dosya türü");
                var newName = Guid.NewGuid() + Path.GetExtension(model.Image.FileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newName);
                var stream = new FileStream(path, FileMode.Create);

                await model.Image.CopyToAsync(stream);
                model.ImagePath = newName;
            }
            await _blogService.UpdateAsync(_mapper.Map<BlogUpdateModel, BlogEntity>(model));
            return NoContent();
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
