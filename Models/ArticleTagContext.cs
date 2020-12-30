using System;
using Microsoft.EntityFrameworkCore;

namespace blog_backend.Models
{
    public class ArticleTagContext : DbContext
    {
        public ArticleTagContext(DbContextOptions<ArticleTagContext> options)
            : base(options)
        {
        }

        public DbSet<ArticleTag> ArticleTag { get; set; }
    }
}
