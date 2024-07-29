using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Olbrasoft.SemiStaticContent;

public partial class FileSemiStaticContentStore(IOptions<FileSemiStaticContentStoreOptions> options, ILogger<FileSemiStaticContentStore> logger) : ISemiStaticContentStore
{
    private readonly IOptions<FileSemiStaticContentStoreOptions> _options = options ?? throw new ArgumentNullException(nameof(options));
    private readonly ILogger<FileSemiStaticContentStore> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<string> GetSource(string key)
    {
        if (!AllowedCharacters().IsMatch(key)) throw new ArgumentException("Invalid characters in key.", nameof(key));
        var fileName = Path.Combine(_options.Value.DataFolder, key + _options.Value.FileExtension);
        try
        {
            return await File.ReadAllTextAsync(fileName);
        }
        catch (IOException ioex)
        {
            _logger.LogError(ioex, "Error while reading contents of file for page {key}.", key);
            return string.Empty;
        }
    }

    [GeneratedRegex("^[a-zA-Z0-9_-]{1,}$")]
    private static partial Regex AllowedCharacters();
}
