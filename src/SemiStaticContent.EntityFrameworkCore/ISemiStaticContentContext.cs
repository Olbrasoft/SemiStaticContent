using Microsoft.EntityFrameworkCore;

namespace Olbrasoft.SemiStaticContent.EntityFrameworkCore;

public interface ISemiStaticContentContext
{
    public DbSet<SemiStaticContentItem> SemiStaticContentItems { get; }
}