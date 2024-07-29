using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.SemiStaticContent.EntityFrameworkCore.Tests;
public class DbSemiStaticContentStoreTests
{

    //DbSemiStaticContentStore is public class
    [Fact]
    public void DbSemiStaticContentStore_Is_Public_Class()
    {
        // Arrange
        var type = typeof(DbSemiStaticContentStore);

        // Act
        var isPublic = type.IsPublic;

        // Assert
        Assert.True(isPublic);
    }

    //DbSemiStaticContentStore assembly is Olbrasoft.SemiStaticContentStore.EntityFrameworkCore
    [Fact]
    public void DbSemiStaticContentStore_Assembly_Is_Olbrasoft_SemiStaticContentStore_EntityFrameworkCore()
    {
        // Arrange
        var type = typeof(DbSemiStaticContentStore);

        // Act
        var assemblyName = type.Assembly.GetName().Name;

        // Assert
        Assert.Equal("Olbrasoft.SemiStaticContent.EntityFrameworkCore", assemblyName);
    }
    
    //DbSemiStaticContentStore implement ISemiStaticContentStore
    [Fact]
    public void DbSemiStaticContentStore_Implement_ISemiStaticContentStore()
    {
        // Arrange
        var type = typeof(DbSemiStaticContentStore);

        // Act
        var implementInterface = type.GetInterfaces().Contains(typeof(ISemiStaticContentStore));

        // Assert
        Assert.True(implementInterface);
    }


    //DbSemiStaticContentStore have constructor with ISemiStaticContentContext and ILogger<DbSemiStaticContentStore> parameters
    [Fact]
    public void DbSemiStaticContentStore_Have_Constructor_With_ISemiStaticContentContext_And_ILogger_DbSemiStaticContentStore_Parameters()
    {
        // Arrange
        var type = typeof(DbSemiStaticContentStore);
        var constructor = type.GetConstructors().First();
        var parameters = constructor.GetParameters();

        // Act
        var haveISemiStaticContentContextParameter = parameters.Any(p => p.ParameterType == typeof(ISemiStaticContentContext));
        var haveILoggerParameter = parameters.Any(p => p.ParameterType == typeof(ILogger<DbSemiStaticContentStore>));

        // Assert
        Assert.True(haveISemiStaticContentContextParameter);
        Assert.True(haveILoggerParameter);
    }

    //DbSemiStaticContentStore constructor Throw_ArgumentNullException_When_ISemiStaticContentContext_Is_Null
    [Fact]
    public void DbSemiStaticContentStore_Constructor_Throw_ArgumentNullException_When_ISemiStaticContentContext_Is_Null()
    {
        // Arrange
        ISemiStaticContentContext context = null!;
        var logger = new Mock<ILogger<DbSemiStaticContentStore>>().Object;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => new DbSemiStaticContentStore(context, logger));

        // Assert
        Assert.Equal("context", exception.ParamName);
    }

    //DbSemiStaticContentStore constructor Throw_ArgumentNullException_When_ILogger_Is_Null
    [Fact]
    public void DbSemiStaticContentStore_Constructor_Throw_ArgumentNullException_When_ILogger_Is_Null()
    {
        // Arrange
        var context = new Mock<ISemiStaticContentContext>().Object;
        ILogger<DbSemiStaticContentStore> logger = null!;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => new DbSemiStaticContentStore(context, logger));

        // Assert
        Assert.Equal("logger", exception.ParamName);
    }

    //GetSource input string key asyng method return task of string
    [Fact]
    public void GetSource_Input_String_Key_Async_Method_Return_Task_Of_String()
    {
        // Arrange
        var context = new Mock<ISemiStaticContentContext>().Object;
        var logger = new Mock<ILogger<DbSemiStaticContentStore>>().Object;
        var store = new DbSemiStaticContentStore(context, logger);

        // Act
        var method = store.GetType().GetMethod("GetSource");
        var returnType = method?.ReturnType;

        // Assert
        Assert.Equal(typeof(Task<string>), returnType);
    }

}
