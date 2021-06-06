using System;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    public class ArticleImage : BaseModel
    {
        [Required]
        public Guid ArticleId { get; set; }

        public Article Article { get; set; }

        [Required]
        public Guid ImageId { get; set; }

        public string Image { get; set; }
    }
}
