using Olbrasoft.SemiStaticContent;
using System.ComponentModel.DataAnnotations;

namespace SemiStaticContent.Tests;
public class SemiStaticContentItemTests
{

    //Add test SemiStaticContentItem is public class
    [Fact]
    public void SemiStaticContentItem_Is_Public_Class()
    {
        // Arrange
        var type = typeof(SemiStaticContentItem);

        // Act
        var isPublic = type.IsPublic;

        // Assert
        Assert.True(isPublic);
    }

    private static bool IsRecord(object obj)
    {
        var type = obj.GetType();
        return type.IsClass && type.GetMethods().Any(m => m.Name == "<Clone>$");
    }

    //Add test SemiStaticContentItem assembly name is Olbrasoft.SemiStaticContent
    [Fact]
    public void SemiStaticContentItem_AssemblyName_Is_Olbrasoft_SemiStaticContent()
    {
        // Arrange
        var item = new SemiStaticContentItem();

        // Act
        var assemblyName = item.GetType().Assembly.GetName().Name;

        // Assert
        Assert.Equal("Olbrasoft.SemiStaticContent", assemblyName);
    }

    
    //Add test SemiStaticContentItem have property Text
    [Fact]
    public void SemiStaticContentItem_Have_Property_Text()
    {
        // Arrange
        var item = new SemiStaticContentItem();

        // Act
        var property = item.GetType().GetProperty("Text");

        // Assert
        Assert.NotNull(property);
    }
    
    //Add test SemiStaticContentItem property Text type is string
    [Fact]
    public void SemiStaticContentItem_Property_Text_Type_Is_String()
    {
        // Arrange
        var item = new SemiStaticContentItem();

        // Act
        var property = item.GetType().GetProperty("Text");

        // Assert
        Assert.Equal(typeof(string), property!.PropertyType);
    }


    //test SemiStaticContentItem property Text have attribute Required
    [Fact]
    public void SemiStaticContentItem_Property_Text_Have_Attribute_Required()
    {
        // Arrange
        var item = new SemiStaticContentItem();

        // Act
        var property = item.GetType().GetProperty("Text");

        // Assert
        Assert.NotNull(property!.GetCustomAttributes(typeof(RequiredAttribute), false).FirstOrDefault());
    }



}
