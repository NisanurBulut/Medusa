using Medusa.WebUI.ApiServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medusa.WebUI.ViewComponents
{
    public class LastSizeBlogList : ViewComponent
    {
        private readonly IBlogApiService _blogApiService;

        public LastSizeBlogList(IBlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }
        public IViewComponentResult Invoke()
        {
            return View(_blogApiService.GetLastSizeBlogAsync(5).Result);
        }
    }
}
