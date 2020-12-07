using System.Collections.Generic;

namespace IBlog.Entities
{
    public class CategoryEntity:ITable
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public List<CategoryBlogEntity> CategoryBlogs { get; set; }
        
    }
}
