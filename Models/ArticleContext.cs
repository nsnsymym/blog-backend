using System;
using Microsoft.EntityFrameworkCore;

namespace blog_backend.Models
{
    public class ArticleContext : DbContext
    {
        public ArticleContext(DbContextOptions<ArticleContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Article { get; set; }
    }
}
