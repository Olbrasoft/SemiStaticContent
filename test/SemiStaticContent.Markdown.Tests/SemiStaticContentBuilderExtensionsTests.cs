namespace Olbrasoft.SemiStaticContent.Markdown.Tests;
public class SemiStaticContentBuilderExtensionsTests
{
    [Fact]
    public void SemiStaticContentBuilderExtensions_Is_Public_Class()
    {
        // Arrange
        var type = typeof(Olbrasoft.SemiStaticContent.Markdown.SemiStaticContentBuilderExtensions);

        // Act
        var isPublic = type.IsPublic;

        // Assert
        Assert.True(isPublic);
    }

    [Fact]
    public void SemiStaticContentBuilderExtensions_Is_Static_Class()
    {
        // Arrange
        var type = typeof(Olbrasoft.SemiStaticContent.Markdown.SemiStaticContentBuilderExtensions);

        // Act
        var isStatic = type.IsAbstract && type.IsSealed;

        // Assert
        Assert.True(isStatic);
    }
}
