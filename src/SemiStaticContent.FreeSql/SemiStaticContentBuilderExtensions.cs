using FreeSql;
using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.SemiStaticContent.FreeSql;

public static class SemiStaticContentBuilderExtensions
{
    public static SemiStaticContentBuilder UseSemiStaticContentStoreFreesql(this SemiStaticContentBuilder builder, Action<FreeSqlBuilder> optionsAction, Action<IFreeSql>? configureAction = null)
    {
        builder.Services.AddTransient<ISemiStaticContentStore, SemiStaticContentStoreFreeSql>();

        builder.Services.AddSingleton(sp =>
        {
            var builder = new FreeSqlBuilder();
            optionsAction(builder);
            var instance = builder.Build();

            if (configureAction != null)
                configureAction?.Invoke(instance);
            else
                instance.CodeFirst.ApplyConfiguration(new SemiStaticContentConfiguration()); 

            return instance;
        });


        return builder;
    }
}