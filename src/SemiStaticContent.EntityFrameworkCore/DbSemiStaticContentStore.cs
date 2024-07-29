using Microsoft.Extensions.Logging;

namespace Olbrasoft.SemiStaticContent.EntityFrameworkCore;

public class DbSemiStaticContentStore(ISemiStaticContentContext context, ILogger<DbSemiStaticContentStore> logger) : ISemiStaticContentStore
{
    private readonly ISemiStaticContentContext _context = context ??  throw new ArgumentNullException(nameof(context));
    private readonly ILogger<DbSemiStaticContentStore> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<string> GetSource(string key)
    {
        var item = await _context.SemiStaticContentItems.FindAsync(key);
        if (item == null)
        {
            _logger.LogError("Static page with key {key} was not found in store.", key);
            return string.Empty;
        }
        return item.Text;
    }
}