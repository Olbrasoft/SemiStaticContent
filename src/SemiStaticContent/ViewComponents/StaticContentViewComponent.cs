using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Options;

namespace Olbrasoft.SemiStaticContent.ViewComponents;

public class StaticContentViewComponent : ViewComponent
{
    private readonly SemiStaticContentProvider staticContentProvider;
    private readonly IOptions<StaticContentViewComponentOptions> options;

    public StaticContentViewComponent(SemiStaticContentProvider staticContentProvider, IOptions<StaticContentViewComponentOptions> options)
    {
        this.staticContentProvider = staticContentProvider;
        this.options = options;
    }

    public async Task<IViewComponentResult> InvokeAsync(string key)
    {
        // Get HTML itself
        var html = await staticContentProvider.GetHtml(key);
        if (string.IsNullOrEmpty(options.Value.SurroundingElementName)) return new HtmlContentViewComponentResult(html);

        // Create surrounding element
        var sb = new StringBuilder();
        sb.Append($"<{options.Value.SurroundingElementName}");
        foreach (var item in options.Value.SurroundingElementAttributes)
        {
            var encodedValue = HtmlEncoder.Default.Encode(item.Value);
            sb.Append($" {item.Key}=\"{encodedValue}\"");
        }
        sb.Append(">");
        sb.Append(html);
        sb.Append($"</{options.Value.SurroundingElementName}>");
        return new HtmlContentViewComponentResult(new HtmlString(sb.ToString()));
    }

}

public class StaticContentViewComponentOptions
{

    public string? SurroundingElementName { get; set; }

    public IDictionary<string, string> SurroundingElementAttributes { get; set; } = new Dictionary<string, string>();

}