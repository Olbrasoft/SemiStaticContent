using Markdig;

namespace Olbrasoft.SemiStaticContent.Markdown;

public class MarkdownSemiStaticContentFormatterOptions
{
    public Func<MarkdownPipeline> CreatePipeline { get; set; } = () => new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
}