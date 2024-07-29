using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.SemiStaticContent.Tests;
public class FileSemiStaticContentStoreOptionsTests
{
    [Fact]
    public void FileSemiStaticContentStoreOptions_Is_Public_Class()
    {
        // Arrange
        var type = typeof(FileSemiStaticContentStoreOptions);

        // Act
        var isPublic = type.IsPublic;

        // Assert
        Assert.True(isPublic);
    }

    [Fact]
    public void FileSemiStaticContentStoreOptions_Assembly_Is_Olbrasoft_SemiStaticContent()
    {
        // Arrange
        var type = typeof(FileSemiStaticContentStoreOptions);

        // Act
        var assemblyName = type.Assembly.GetName().Name;

        // Assert
        Assert.Equal("Olbrasoft.SemiStaticContent", assemblyName);
    }
}
