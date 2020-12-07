using System;

namespace IBlog.Entities
{
    public class BlogEntity:ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime PostedTime { get; set; }
    }
}
