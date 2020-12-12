using AutoMapper;
using Medusa.Business.Interface;
using Medusa.Business.Tools;
using Medusa.DataTransferObject;
using Medusa.WebAPI.CustomFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Medusa.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        public AuthController(IAppUserService appUserService, IJwtService jwtService, IMapper mapper)
        {
            this._appUserService = appUserService;
            this._jwtService = jwtService;
            this._mapper = mapper;
        }
        [HttpPost]
        [ValidModel]
        public async Task<IActionResult> SignIn(AppUserLoginDto appUserLoginDto)
        {
            var user = await _appUserService.CheckUserAsync(appUserLoginDto);
            if (user != null)
            {
                return Created("", _jwtService.GenerateJwt(user));
            }
            else
            {
                return BadRequest("Kullanıcı adı veya şifre hatalı");
            }
        }
        [HttpGet("[action]")]
        [Authorize]
        public async Task<IActionResult> ActiveUser()
        {
            var user = await _appUserService.FindByNameAsync(User.Identity.Name);
           
            return Ok(_mapper.Map<AppUserDto>(user));
        }
    }
}
