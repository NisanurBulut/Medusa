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
        public AccountController()
        {

        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View(new AppUserLoginModel());
        }

        [HttpPost]
        public IActionResult SignIn(AppUserLoginModel model)
        {
            return View();
        }
    }
}
