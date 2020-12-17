using Medusa.WebUI.ApiServices.Interfaces;
using Medusa.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medusa.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthApiService _authApiService;

        public AccountController(IAuthApiService authApiService)
        {
            this._authApiService = authApiService;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View(new AppUserLoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginModel model)
        {
            if (await _authApiService.SignIn(model))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(new AppUserLoginModel());
        }
    }
}
