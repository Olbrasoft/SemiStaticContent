using Microsoft.Extensions.DependencyInjection;

namespace Olbrasoft.SemiStaticContent;

public class SemiStaticContentBuilder(IServiceCollection services)
{

    public IServiceCollection Services { get; init; } = services ?? throw new ArgumentNullException(nameof(services));
}