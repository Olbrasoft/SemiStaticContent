using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.SemiStaticContent.EntityFrameworkCore;
public static class SemiStaticContentBuilderExtensions
{
    public static SemiStaticContentBuilder UseDbStaticContentStore<TContext>(this SemiStaticContentBuilder builder) where TContext : class, ISemiStaticContentContext
    {
        builder.Services.AddTransient<ISemiStaticContentStore, DbSemiStaticContentStore>();
        builder.Services.AddTransient<ISemiStaticContentContext, TContext>();
        return builder;
    }
}