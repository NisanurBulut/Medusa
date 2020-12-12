using Medusa.Entities;

namespace Medusa.DataTransferObject
{
    public class CategoryWithBlogsCountDto
    {
        public int BlogsCount { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
