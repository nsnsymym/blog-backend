using System;
namespace BlogBackend.Models
{
    public class ArticleTag
    {
        public ArticleTag()
        {
        }

        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int TagId { get; set; }
    }
}
