using System;
using BlogBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogBackend.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
