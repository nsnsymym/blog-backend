using System;
using Microsoft.EntityFrameworkCore;

namespace blog_backend.Models
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options)
            : base(options)
        {
        }

        public DbSet<Comment> Comment { get; set; }
    }
}
