using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        // Modelをセット
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        // タイムスタンプの書き込み(同期処理)
        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        // タイムスタンプの書き込み(非同期処理)
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        // タイムスタンプの書き込み処理
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.Now; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseModel)entity.Entity).CreatedAt = now;
                }
                ((BaseModel)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
