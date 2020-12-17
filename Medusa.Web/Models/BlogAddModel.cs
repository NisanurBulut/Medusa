using Microsoft.AspNetCore.Http;

namespace Medusa.WebUI.Models
{
    public class BlogAddModel
    {
        public int AppUserId { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImagePath { get; set; }
        public IFormFile Image { get; set; }
    }
}
