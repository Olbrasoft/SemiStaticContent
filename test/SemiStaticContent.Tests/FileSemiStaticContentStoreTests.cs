using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.SemiStaticContent.Tests;
public class FileSemiStaticContentStoreTests
{

    [Fact]
    public void FileSemiStaticContentStore_Is_Public_Class()
    {
        // Arrange
        var type = typeof(FileSemiStaticContentStore);

        // Act
        var isPublic = type.IsPublic;

        // Assert
        Assert.True(isPublic);
    }

    [Fact]
    public void FileSemiStaticContentStore_Assembly_Is_Olbrasoft_SemiStaticContent()
    {
        // Arrange
        var type = typeof(FileSemiStaticContentStore);

        // Act
        var assemblyName = type.Assembly.GetName().Name;

        // Assert
        Assert.Equal("Olbrasoft.SemiStaticContent", assemblyName);
    }

    [Fact]
    public void FileSemiStaticContentStore_Implement_ISemiStaticContentStore()
    {
        // Arrange
        var type = typeof(FileSemiStaticContentStore);

        // Act
        var implementInterface = type.GetInterfaces().Contains(typeof(ISemiStaticContentStore));

        // Assert
        Assert.True(implementInterface);
    }

    //FileSemiStaticContentStore constructor throw ArgumentNullException when options is null
    [Fact]
    public void FileSemiStaticContentStore_Constructor_Throw_ArgumentNullException_When_Options_Is_Null()
    {

        // Act
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var exception = Assert.Throws<ArgumentNullException>(() => new FileSemiStaticContentStore(null, new Mock<ILogger<FileSemiStaticContentStore>>().Object));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        // Assert
        Assert.Equal("options", exception.ParamName);
    }


    //FileSemiStaticContentStore constructor throw ArgumentNullException when logger is null
    [Fact]
    public void FileSemiStaticContentStore_Constructor_Throw_ArgumentNullException_When_Logger_Is_Null()
    {
        // Arrange
        var options = new Mock<IOptions<FileSemiStaticContentStoreOptions>>().Object;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => new FileSemiStaticContentStore(options, null!));

        // Assert
        Assert.Equal("logger", exception.ParamName);
    }


}
