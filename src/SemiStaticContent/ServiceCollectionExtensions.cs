using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.SemiStaticContent;

public static class ServiceCollectionExtensions
{
    public static SemiStaticContentBuilder AddStaticContent(this IServiceCollection services)
    {
        services.AddTransient<SemiStaticContentProvider>();
        return new SemiStaticContentBuilder(services);
    }

    public static SemiStaticContentBuilder UseFileStaticContentStore(this SemiStaticContentBuilder builder, string dataFolder, string? fileExtension = null)
    {
        builder.Services.AddTransient<ISemiStaticContentStore, FileSemiStaticContentStore>();
        builder.Services.Configure<FileSemiStaticContentStoreOptions>(options =>
        {
            options.DataFolder = dataFolder;
            if (!string.IsNullOrWhiteSpace(fileExtension)) options.FileExtension = fileExtension;
        });
        return builder;
    }
}