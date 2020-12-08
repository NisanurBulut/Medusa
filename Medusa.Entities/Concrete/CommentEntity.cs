using System;
using System.Collections.Generic;
using System.Text;

namespace Medusa.Entities
{
    public class CommentEntity:ITable
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; } = DateTime.Now;
        public int? ParentCommentId { get; set; }
        public CommentEntity ParentComment { get; set; }

        public List<CommentEntity> SubComments { get; set; }
        public int BlogId { get; set; }
        public BlogEntity Blog { get; set; }
    }
}
