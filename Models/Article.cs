using System;
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
        public string Title { get; set; }
        public string Contents { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Like { get; set; }
        public int View { get; set; }
    }
}
