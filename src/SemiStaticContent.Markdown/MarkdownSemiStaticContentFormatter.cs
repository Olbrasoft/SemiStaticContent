using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Options;
using MarkdigMarkdown = Markdig.Markdown;


namespace Olbrasoft.SemiStaticContent.Markdown;

public class MarkdownSemiStaticContentFormatter(IOptions<MarkdownSemiStaticContentFormatterOptions> options) : ISemiStaticContentFormatter
{
    private readonly IOptions<MarkdownSemiStaticContentFormatterOptions> _options = options;

    public HtmlString GetHtml(string source) => new HtmlString(MarkdigMarkdown.ToHtml(source, _options.Value.CreatePipeline()));

    public string GetPlainText(string source) => MarkdigMarkdown.ToPlainText(source, _options.Value.CreatePipeline());
}
