namespace Olbrasoft.SemiStaticContent.Markdown.Tests;
public class MarkdownSemiStaticContentFormatterTests
{
    [Fact]
    public void MarkdownSemiStaticContentFormatter_Is_Public_Class()
    {
        // Arrange
        var type = typeof(MarkdownSemiStaticContentFormatter);

        // Act
        var isPublic = type.IsPublic;

        // Assert
        Assert.True(isPublic);
    }
 
    [Fact]
    public void MarkdownSemiStaticContentFormatter_Assembly_Is_Olbrasoft_SemiStaticContent_Markdown()
    {
        // Arrange
        var type = typeof(MarkdownSemiStaticContentFormatter);

        // Act
        var assemblyName = type.Assembly.GetName().Name;

        // Assert
        Assert.Equal("Olbrasoft.SemiStaticContent.Markdown", assemblyName);
    }
}