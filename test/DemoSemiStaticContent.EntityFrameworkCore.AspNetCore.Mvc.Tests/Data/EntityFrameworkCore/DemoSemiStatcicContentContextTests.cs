using Microsoft.EntityFrameworkCore;
using Olbrasoft.DemoSemiStaticContent.EntityFrameworkCore.AspNetCore.Mvc.Data.EntityFrameworkCore;
using Olbrasoft.SemiStaticContent;
using Olbrasoft.SemiStaticContent.EntityFrameworkCore;

namespace DemoSemiStaticContent.EntityFrameworkCore.AspNetCore.Mvc.Tests.Data.EntityFrameworkCore;
public class DemoSemiStatcicContentContextTests
{
    //DemoSemiStatcicContentContext is public class
    [Fact]  
    public void DemoSemiStaticContentContext_Is_Public_Class()
    {
        //Arrange
        var type = typeof(DemoSemiStaticContentContext);

        //Act
        var isPublic = type.IsPublic;
        
        //Assert
        Assert.True(isPublic);
    }

    //DemoSemiStatcicContentContext assembly is Olbrrasoft.DemoSemiStaticContent.EntityFrameworkCore.AspNetCore.Mvc
    [Fact]
    public void DemoSemiStaticContentContext_Assembly_Is_Olbrasoft_DemoSemiStaticContent_EntityFrameworkCore_AspNetCore_Mvc()
    {
        //Arrange
        var type = typeof(DemoSemiStaticContentContext);

        //Act
        var assembly = type.Assembly.GetName().Name;

        //Assert
        Assert.Equal("Olbrasoft.DemoSemiStaticContent.EntityFrameworkCore.AspNetCore.Mvc", assembly);
    }

    //demoSemiStaticContentContext namespace is Olbrasoft.DemoSemiStaticContent.EntityFrameworkCore.AspNetCore.Mvc.Data.EntityFrameworkCore
    [Fact]
    public void DemoSemiStaticContentContext_Namespace_Is_Olbrasoft_DemoSemiStaticContent_EntityFrameworkCore_AspNetCore_Mvc_Data_EntityFrameworkCore()
    {
        //Arrange
        var type = typeof(DemoSemiStaticContentContext);

        //Act
        var @namespace = type.Namespace;

        //Assert
        Assert.Equal("Olbrasoft.DemoSemiStaticContent.EntityFrameworkCore.AspNetCore.Mvc.Data.EntityFrameworkCore", @namespace);
    }

    //DemoSemiStaticContentContext inherits from DbContext
    [Fact]
    public void DemoSemiStaticContentContext_Inherits_From_DbContext()
    {
        //Arrange
        var type = typeof(DemoSemiStaticContentContext);

        //Act
        var isDbContext = type.IsSubclassOf(typeof(DbContext));

        //Assert
        Assert.True(isDbContext);
    }

    //DemoSemiStaticContentContext implements ISemiStaticContentContext
    [Fact]
    public void DemoSemiStaticContentContext_Implements_ISemiStaticContentContext()
    {
        //Arrange
        var type = typeof(DemoSemiStaticContentContext);

        //Act
        var isISemiStaticContentContext = type.GetInterfaces().Any(i => i == typeof(ISemiStaticContentContext));

        //Assert
        Assert.True(isISemiStaticContentContext);
    }

    //DemoSemiStaticContentContext has ctor with DbContextOptions parameter
    [Fact]
    public void DemoSemiStaticContentContext_Has_Ctor_With_DbContextOptions_Parameter()
    {
        //Arrange
        var type = typeof(DemoSemiStaticContentContext);

        //Act
        var ctor = type.GetConstructors().FirstOrDefault(c => c.GetParameters().Any(p => p.ParameterType == typeof(DbContextOptions)));

        //Assert
        Assert.NotNull(ctor);
    }

    //DemoSemiStaticContentContext has DbSet<SemiStaticContentItem> property
    [Fact]
    public void DemoSemiStaticContentContext_Has_DbSet_SemiStaticContentItem_Property()
    {
        //Arrange
        var type = typeof(DemoSemiStaticContentContext);

        //Act
        var property = type.GetProperty("SemiStaticContentItems");

        //Assert
        Assert.NotNull(property);
        Assert.Equal(typeof(DbSet<SemiStaticContentItem>), property.PropertyType);
    }
}
