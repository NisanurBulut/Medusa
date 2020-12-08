using System;
using System.Collections.Generic;
using System.Text;

namespace Medusa.DataTransferObject
{
    public class BlogDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;
        public string ImagePath { get; set; }
        public int AppUserId { get; set; }
    }
}
