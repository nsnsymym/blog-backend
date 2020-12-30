using System;
namespace blog_backend.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public string Contents { get; set; }
        public int Status { get; set; }

        public Comment()
        {
        }
    }
}
