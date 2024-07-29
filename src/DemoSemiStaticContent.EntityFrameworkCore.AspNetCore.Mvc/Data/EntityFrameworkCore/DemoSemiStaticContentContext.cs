using Microsoft.EntityFrameworkCore;
using Olbrasoft.SemiStaticContent;
using Olbrasoft.SemiStaticContent.EntityFrameworkCore;

namespace Olbrasoft.DemoSemiStaticContent.EntityFrameworkCore.AspNetCore.Mvc.Data.EntityFrameworkCore
{
    public class DemoSemiStaticContentContext(DbContextOptions options) : DbContext(options), ISemiStaticContentContext
    {
        public DbSet<SemiStaticContentItem> SemiStaticContentItems => Set<SemiStaticContentItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SemiStaticContentItem>().HasData(
                new SemiStaticContentItem { Key = "welcome", Text = "# Welcome" },
                new SemiStaticContentItem { Key = "privacy", Text = "This is my _privacy policy_." }
            );
        }

    }
}