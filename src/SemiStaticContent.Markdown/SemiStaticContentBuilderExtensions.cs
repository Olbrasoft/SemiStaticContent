using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.SemiStaticContent.Markdown;

public static class SemiStaticContentBuilderExtensions
{
    public static SemiStaticContentBuilder UseMarkdownFormatter(this SemiStaticContentBuilder builder)
    {
        builder.Services.AddTransient<ISemiStaticContentFormatter, MarkdownSemiStaticContentFormatter>();
        return builder;
    }

}