using System;
using System.Collections.Generic;
using System.Text;

namespace IBlog.Entities
{
    class CommentEntity:ITable
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; }
        public int? ParentCommentId { get; set; }
        public CommentEntity ParentComment { get; set; }

        public List<CommentEntity> SubComments { get; set; }
    }
}
