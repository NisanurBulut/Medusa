using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Medusa.WebUI.Models
{
    public class BlogUpdateModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AppUserId { get; set; }
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name = "Özet")]

        public string ShortDescription { get; set; }
        [Display(Name = "Açıklama")]

        public string LongDescription { get; set; }

        [Display(Name = "Resim")]
        public IFormFile Image { get; set; }
    }
}
