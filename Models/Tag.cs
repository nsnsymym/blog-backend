﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    public class Tag : BaseModel
    {
        [Display(Name = "タグ名")]
        [Required]
        public string Name { get; set; }

        public List<ArticleTag> ArticleTags { get; set; }
    }
}
