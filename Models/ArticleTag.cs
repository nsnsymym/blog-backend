﻿using System;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    public class ArticleTag : BaseModel
    {
        [Required]
        public Guid ArticleId { get; set; }

        public Article Article { get; set; }

        [Required]
        public Guid TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
