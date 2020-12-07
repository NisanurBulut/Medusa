namespace IBlog.Entities
{
    public class CategoryBlogEntity : ITable
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
        public BlogEntity Blog { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
