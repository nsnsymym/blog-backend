using System;
namespace blog_backend.Models
{
    public class Article
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public int Status { get; set; }

        public Article()
        {
        }
    }
}
