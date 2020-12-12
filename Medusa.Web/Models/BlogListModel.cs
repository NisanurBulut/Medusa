using System;

namespace Medusa.WebUI.Models
{
    public class BlogListModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime PostedTime { get; set; }
        public string ImagePath { get; set; }
    }
}
