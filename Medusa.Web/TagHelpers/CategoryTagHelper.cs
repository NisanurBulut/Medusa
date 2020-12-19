using Medusa.WebUI.ApiServices.Interfaces;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medusa.WebUI.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("categoryDivTag")]
    public class CategoryTagHelper : TagHelper
    {
        private readonly ICategoryApiService _categoryApiService;
        public string SearchString { get; set; }
        public int? Id { get; set; }
        public CategoryTagHelper(ICategoryApiService categoryApiService)
        {
            this._categoryApiService = categoryApiService;
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string html = $"<div class='border border-dark p-3 mb-2'>";
            if (Id.HasValue)
            {
                var categoryItem = await _categoryApiService.GetByIdAsync(Id.Value);
                html = html + $"<strong>Kategori : {categoryItem.Name}</strong> ";
            }
            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                html = html + $"<strong>Aranan ifade : {SearchString}</strong> ";
            }
            html = html + $"<a style='cursor:pointer;' href={"Home/Index"} class='float-right'>Filtreyi Kaldır </a>"
                    + $"</div>";

            output.Content.SetHtmlContent(html);
        }
    }
}
