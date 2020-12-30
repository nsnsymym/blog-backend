using System;
namespace blog_backend.Models
{
    public class ArticleTag
    {
        public long Id { get; set; }
        public long ArticleId { get; set; }
        public long TagId { get; set; }

        public ArticleTag()
        {
            
        }
    }
}