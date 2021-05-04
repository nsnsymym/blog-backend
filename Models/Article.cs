using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    public enum ArticleStatus
    {
        Unpublished,
        Published,
    }

    public class Article : BaseModel
    {
        [Display(Name = "タイトル")]
        [Required]
        [StringLength(80, ErrorMessage = "{0}は{1}文字までです。")]
        public string Title { get; set; }

        [Display(Name = "本文")]
        [Required]
        public string Contents { get; set; }

        [Display(Name = "状態")]
        [Required]
        public ArticleStatus Status { get; set; }

        [Display(Name = "いいね")]
        public int LikeCount { get; set; }

        [Display(Name = "投稿者")]
        [Required]
        public Guid AdminId { get; set; }

        public Admin Admin { get; set; }

        public List<ArticleTag> ArticleTags { get; set; }
        public List<ArticleImage> ArticleImages { get; set; }
    }
}
