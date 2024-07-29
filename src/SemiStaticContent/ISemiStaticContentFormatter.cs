using Microsoft.AspNetCore.Html;

namespace Olbrasoft.SemiStaticContent;

public interface ISemiStaticContentFormatter
{

    HtmlString GetHtml(string source);

    string GetPlainText(string source);

}
