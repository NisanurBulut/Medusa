using Medusa.WebUI.ApiServices.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Medusa.WebUI.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("imgTag")]
    public class ImageTagHelper : TagHelper
    {
        private readonly IImageApiService _imageapiService;

        public ImageTagHelper(IImageApiService imageapiService)
        {
            this._imageapiService = imageapiService;
        }
        public int Id { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var blob = await _imageapiService.GetBlogImageByIdAsync(Id);
            var html = $"<img class='card-img-top' src='{blob}'/>";
            output.Content.SetHtmlContent(html);
        }
    }
}
