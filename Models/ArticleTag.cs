using System;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    public class ArticleTag : BaseModel
    {
        public ArticleTag()
        {
        }

        public int Id { get; set; }
        [Required]
        public int ArticleId { get; set; }
        [Required]
        public int TagId { get; set; }
    }
}
