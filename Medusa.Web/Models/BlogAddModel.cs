using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Medusa.WebUI.Models
{
    public class BlogAddModel
    {
        public int AppUserId { get; set; }
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name = "Özet")]

        public string ShortDescription { get; set; }
        [Display(Name = "Açıklama")]

        public string LongDescription { get; set; }
        public string ImagePath { get; set; }

        [Display(Name = "Resim Seçiniz :")]
        public IFormFile Image { get; set; }
    }
}
