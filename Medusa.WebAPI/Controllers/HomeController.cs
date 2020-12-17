using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medusa.Business.Tools;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Medusa.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomLog _customLog;

        public HomeController(ICustomLog customLog)
        {
            this._customLog = customLog;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Error")]
        public IActionResult Error()
        {
            var errorInfo = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _customLog.LogError($"Hatanın yakalandığı yer : {errorInfo.Path}\n " +
                $"Hata Mesajı : {errorInfo.Error.Message}\n" +
                $"stackstarce : {errorInfo.Error.StackTrace}");
            return Problem(detail:"Bir hata oluştu");
        }
    }
}
