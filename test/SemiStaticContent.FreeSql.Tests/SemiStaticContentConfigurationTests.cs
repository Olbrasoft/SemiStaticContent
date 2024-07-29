using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.SemiStaticContent.FreeSql.Tests;
public class SemiStaticContentConfigurationTests
{
    //SemiStaticContentConfiguration is public class
        [Fact]
        public void SemiStaticContentConfiguration_Is_Public_Class()
        {
        // Arrange
        var type = typeof(SemiStaticContentConfiguration);
    
            // Act
            var isPublic = type.IsPublic;
    
            // Assert
            Assert.True(isPublic);
        }

    //SemiStaticContentConfiguration assembly is Olbrasoft.SemiStaticContent.FreeSql
    
    [Fact]
    public void SemiStaticContentConfiguration_Assembly_Is_Olbrasoft_SemiStaticContent_FreeSql()
    {
        // Arrange
        var type = typeof(SemiStaticContentConfiguration);

        // Act
        var assemblyName = type.Assembly.GetName().Name;

        // Assert
        Assert.Equal("Olbrasoft.SemiStaticContent.FreeSql", assemblyName);
    }

    //SemiStaticContentConfiguration is in Namespace Olbrasoft.SemiStaticContent.FreeSql
    [Fact]
    public void SemiStaticContentConfiguration_Is_In_Namespace_Olbrasoft_SemiStaticContent_FreeSql()
    {
        // Arrange
        var type = typeof(SemiStaticContentConfiguration);

        // Act
        var @namespace = type.Namespace;

        // Assert
        Assert.Equal("Olbrasoft.SemiStaticContent.FreeSql", @namespace);
    }

    //SemiStaticContentConfiguration inplement interface IEntityTypeConfiguration
    [Fact]
    public void SemiStaticContentConfiguration_Implements_Interface_IEntityTypeConfiguration()
    {
        // Arrange
        var type = typeof(SemiStaticContentConfiguration);

        // Act
        var isIEntityTypeConfiguration = type.GetInterfaces().Any(i => i.Name == "IEntityTypeConfiguration`1");

        // Assert
        Assert.True(isIEntityTypeConfiguration);
    }

    //SemiStaticContentConfiguration have method Configure 
    [Fact]
    public void SemiStaticContentConfiguration_Have_Method_Configure_With_Input_EfCoreTableFluent_SemiStaticContentItem_Model()
    {
        // Arrange
        var type = typeof(SemiStaticContentConfiguration);

        // Act
        var method = type.GetMethod("Configure");

        // Assert
        Assert.NotNull(method);
    }
}
