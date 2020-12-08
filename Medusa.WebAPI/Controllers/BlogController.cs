using Medusa.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Medusa.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            this._blogService = blogService;
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            return Ok(await _blogService.GetAllSortedByPostedTimeAsync());
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetBlogById(int id)
        {
            return Ok(await _blogService.FindByIdAsync(id));
        }
    }
}
