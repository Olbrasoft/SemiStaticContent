using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.SemiStaticContent.Tests;
public class SemiStaticContentBuilderTests
{
    //SemiStaticContentBuilder is public class
    [Fact]
    public void SemiStaticContentBuilder_Is_Public_Class()
    {
        // Arrange
        var type = typeof(SemiStaticContentBuilder);

        // Act
        var isPublic = type.IsPublic;

        // Assert
        Assert.True(isPublic);
    }

    //SemiStaticContentBuilder assembly is Olbrasoft.SemiStaticContent
    [Fact]
    public void SemiStaticContentBuilder_Assembly_Is_Olbrasoft_SemiStaticContent()
    {
        // Arrange
        var type = typeof(SemiStaticContentBuilder);

        // Act
        var assemblyName = type.Assembly.GetName().Name;

        // Assert
        Assert.Equal("Olbrasoft.SemiStaticContent", assemblyName);
    }

    //SemiStaticContentBuilder have constructor with IServiceCollection parameter
    [Fact]
    public void SemiStaticContentBuilder_Have_Constructor_With_IServiceCollection_Parameter()
    {
        // Arrange
        var type = typeof(SemiStaticContentBuilder);
        var constructor = type.GetConstructor(new[] { typeof(IServiceCollection) });

        // Assert
        Assert.NotNull(constructor);
    }

    //SemiStaticContentBuilder have Services property
    [Fact]
    public void SemiStaticContentBuilder_Have_Services_Property()
    {
        // Arrange
        var type = typeof(SemiStaticContentBuilder);
        var property = type.GetProperty("Services");

        // Assert
        Assert.NotNull(property);
    }

    //SemiStaticContentBuilder constructor  Throw_ArgumentNullException_When_IServiceCollection_Parameter_Is_Null
    [Fact]
    public void SemiStaticContentBuilder_Constructor_Throw_ArgumentNullException_When_IServiceCollection_Parameter_Is_Null()
    {
        // Arrange
        IServiceCollection? services = null;

        // Act
#pragma warning disable CS8604 // Possible null reference argument.
        var exception = Record.Exception(() => new SemiStaticContentBuilder(services));
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<ArgumentNullException>(exception);
    }

}
