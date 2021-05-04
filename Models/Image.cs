using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    public class Image : BaseModel
    {
        [Display(Name = "ファイル名")]
        [Required]
        public string Name { get; set; }

        public List<ArticleImage> ArticleImages { get; set; }
    }
}
