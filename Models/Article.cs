using System;
using System.ComponentModel.DataAnnotations;

namespace BlogBackend.Models
{
    public enum Status
    {
        Unpublished,
        Published,
    }

    public class Article
    {
        public Article()
        {
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "タイトルは50文字までです。")]
        public string Title { get; set; }
        [Required]
        public string Contents { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        public int Like { get; set; }
        public int View { get; set; }
    }
}
