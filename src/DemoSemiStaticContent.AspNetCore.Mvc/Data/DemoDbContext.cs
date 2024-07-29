using Microsoft.EntityFrameworkCore;
using Olbrasoft.SemiStaticContent;
using Olbrasoft.SemiStaticContent.EntityFrameworkCore;

namespace DemoSemiStaticContent.AspNetCore.Mvc.Data;

public class DemoDbContext : DbContext, ISemiStaticContentContext
{

    public DemoDbContext(DbContextOptions options) : base(options)
    {
    }

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
