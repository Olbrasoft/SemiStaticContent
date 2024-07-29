using FreeSql.Extensions.EfCoreFluentApi;

namespace Olbrasoft.SemiStaticContent.FreeSql;


public class SemiStaticContentConfiguration : IEntityTypeConfiguration<SemiStaticContentItem>
{
    public void Configure(EfCoreTableFluent<SemiStaticContentItem> model)
    {
        model.ToTable("SemiStaticContentItems");
    }
}