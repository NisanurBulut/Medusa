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
    public class ImageController : BaseController
    {
        private readonly IBlogService _blogService;
        public ImageController(IBlogService blogService)
        {
            this._blogService = blogService;
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetBlogImageById(int id)
        {
            var blog = await _blogService.FindByIdAsync(id);
            if (string.IsNullOrWhiteSpace(blog.ImagePath))
                return NotFound("Resim bulunamadı");
            return File($"/img/{blog.ImagePath}", "image/jpg");
        }
    }
}
