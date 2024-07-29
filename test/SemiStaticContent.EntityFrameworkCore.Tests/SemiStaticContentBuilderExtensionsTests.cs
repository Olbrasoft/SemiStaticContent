namespace Olbrasoft.SemiStaticContent.EntityFrameworkCore.Tests;
public class SemiStaticContentBuilderExtensionsTests
{
    [Fact]
    public void SemiStaticContentBuilderExtensions_Is_Public_Static_Class()
    {
        // Arrange
        var type = typeof(SemiStaticContentBuilderExtensions);

        // Act
        var isPublic = type.IsPublic;
        var isStatic = type.IsAbstract && type.IsSealed;

        // Assert
        Assert.True(isPublic);
        Assert.True(isStatic);
    }
}
