using System;
using System.Collections.Generic;

namespace Medusa.Entities
{
    public class BlogEntity:ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;
        public List<CategoryBlogEntity> CategoryBlogs { get; set; }
        public string ImagePath { get; set; }

        public int AppUserId { get; set; }
        public AppUserEntity AppUser { get; set; }
        public List<CommentEntity> Comments { get; set; }
    }
}
