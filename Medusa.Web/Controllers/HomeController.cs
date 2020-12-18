using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Medusa.WebUI.ApiServices.Interfaces;
using Medusa.WebUI.Models;

namespace Medusa.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBlogApiService _blogApiService { get; }

        public HomeController(IBlogApiService blogApiService, ILogger<HomeController> logger)
        {
            _blogApiService = blogApiService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? categoryId)
        {
            if (categoryId.HasValue)
            {
                ViewBag.ActiveCategoryId = categoryId.Value;
                return View(await _blogApiService.GetAllByCategoryIdAsync(categoryId.Value));
            }
            return View(await _blogApiService.GetAllAsync());
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
           ViewBag.Comments = await _blogApiService.GetCommentsAsync(id, null);
            return View(await _blogApiService.GetByIdAsync(id));
        }
        public async Task<IActionResult> AddToComment(CommentAddModel model)
        {
            await _blogApiService.AddToCommentAsync(model);
            return RedirectToAction("BlogDetail", new { id = model.BlogId });
        }
    }
}
