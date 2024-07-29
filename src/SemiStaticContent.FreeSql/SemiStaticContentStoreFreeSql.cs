using Microsoft.Extensions.Logging;

namespace Olbrasoft.SemiStaticContent.FreeSql;

public class SemiStaticContentStoreFreeSql(IFreeSql freeSql, ILogger<SemiStaticContentStoreFreeSql> logger) : ISemiStaticContentStore
{
    private readonly IFreeSql _freeSql = freeSql ?? throw new ArgumentNullException(nameof(freeSql));
    private readonly ILogger<SemiStaticContentStoreFreeSql> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<string> GetSource(string key)
    {
        var item = await _freeSql.Select<SemiStaticContentItem>().Where(p => p.Key == key).FirstAsync();

        if (item is null)
        {
            _logger.LogError("Static page with key {key} was not found in store.", key);
            return string.Empty;
        }

        return item.Text;
    }
}