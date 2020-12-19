using Medusa.Business.Tools;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Medusa.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : BaseController
    {
        private readonly ICustomLog _customLog;
        public ErrorController(ICustomLog customLog)
        {
            this._customLog = customLog;
        }
        [HttpGet("[action]")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _customLog.LogError($"Hatanın yakalandığı yer : {errorInfo.Path}\n " +
                $"Hata Mesajı : {errorInfo.Error.Message}\n" +
                $"stackstarce : {errorInfo.Error.StackTrace}");
            return Problem(detail: "Bir hata oluştu");
        }
    }
}
