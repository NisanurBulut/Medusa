namespace IBlog.Entities
{
    class CategoryBlogEntity : ITable
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int CategoryId { get; set; }
    }
}
