using System;
using Microsoft.EntityFrameworkCore;

namespace blog_backend.Models
{
    public class TagContext : DbContext
    {
        public TagContext(DbContextOptions<TagContext> options)
            : base(options)
        {
        }

        public DbSet<Tag> Tag { get; set; }
    }
}
