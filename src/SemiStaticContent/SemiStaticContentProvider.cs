using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Logging;

namespace Olbrasoft.SemiStaticContent;
public class SemiStaticContentProvider
{
    private readonly ISemiStaticContentStore store;
    private readonly ISemiStaticContentFormatter formatter;
    private readonly ILogger<SemiStaticContentProvider> logger;

    public SemiStaticContentProvider(ISemiStaticContentStore store, ISemiStaticContentFormatter formatter, ILogger<SemiStaticContentProvider> logger)
    {
        this.store = store;
        this.formatter = formatter;
        this.logger = logger;
    }

    public async Task<HtmlString> GetHtml(string key)
    {
        logger.LogDebug("Getting HTML for static page {key}.", key);
        return formatter.GetHtml(await store.GetSource(key));
    }

    public async Task<string> GetPlainText(string key)
    {
        logger.LogDebug("Getting plaintext for static page {key}.", key);
        return formatter.GetPlainText(await store.GetSource(key));
    }
}