using System;

namespace Medusa.DataTransferObject
{
    public class CommentAddDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string Description { get; set; }
        public DateTime PostedTime { get; set; }
    }
}
