using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.SemiStaticContent.FreeSql.Tests;
public class SemiStaticContentBuilderExtensionsTests
{
    [Fact]
    public void SemiStaticContentBuillderExtensions_Is_Public_Class()
    {
        //Arrange
        var type = typeof(Olbrasoft.SemiStaticContent.FreeSql.SemiStaticContentBuilderExtensions);

        //Act

        //Assert
        Assert.True(type.IsPublic);
    }

    [Fact]
    public void SemiStaticContentBuilderExtensions_Assembly_Is_Olbrasoft_SemiStaticContent_FreeSql()
    {
        //Arrange
        var type = typeof(Olbrasoft.SemiStaticContent.FreeSql.SemiStaticContentBuilderExtensions);

        //Act
        var result = type.Assembly.GetName().Name;

        //Assert
        Assert.Equal("Olbrasoft.SemiStaticContent.FreeSql", result);
    }

    [Fact]
    public void SemiStaticContentBuilderExtensions_Is_In_Namespace_Olbrasoft_SemiStaticContent_FreeSql()
    {
        //Arrange
        var type = typeof(Olbrasoft.SemiStaticContent.FreeSql.SemiStaticContentBuilderExtensions);

        //Act
        var result = type.Namespace;

        //Assert
        Assert.Equal("Olbrasoft.SemiStaticContent.FreeSql", result);
    }

    [Fact]
    public void SemiStaticContentBuilderExtensions_Is_Static_Class()
    {
        //Arrange
        var type = typeof(Olbrasoft.SemiStaticContent.FreeSql.SemiStaticContentBuilderExtensions);

        //Assert
        Assert.True(type.IsAbstract && type.IsSealed);
    }

        



}
