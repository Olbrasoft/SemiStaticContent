using FreeSql;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.SemiStaticContent.FreeSql.Tests;
public class SemiStaticContentStoreFreeSqlTests
{

    //SemiStaticContentStoreFreeSql is public class
    [Fact]
    public void SemiStaticContentStoreFreeSql_Is_Public_Class()
    {
        // Arrange
        var type = typeof(SemiStaticContentStoreFreeSql);

        // Act
        var isPublic = type.IsPublic;

        // Assert
        Assert.True(isPublic);
    }


    //SemiStaticContentStoreFreeSql assembly is Olbrasoft.SemiStaticContent.FreeSql
    [Fact]
    public void SemiStaticContentStoreFreeSql_Assembly_Is_Olbrasoft_SemiStaticContent_FreeSql()
    {
        // Arrange
        var type = typeof(SemiStaticContentStoreFreeSql);

        // Act
        var assemblyName = type.Assembly.GetName().Name;

        // Assert
        Assert.Equal("Olbrasoft.SemiStaticContent.FreeSql", assemblyName);
    }

    //SemiStaticContentStoreFreeSql is in Namespace Olbrasoft.SemiStaticContent.FreeSql
    [Fact]
    public void SemiStaticContentStoreFreeSql_Is_In_Namespace_Olbrasoft_SemiStaticContent_FreeSql()
    {
        // Arrange
        var type = typeof(SemiStaticContentStoreFreeSql);

        // Act
        var @namespace = type.Namespace;

        // Assert
        Assert.Equal("Olbrasoft.SemiStaticContent.FreeSql", @namespace);
    }

    //SemiStaticContentStoreFreeSql mplements ISemiStaticContentStore
    [Fact]
    public void SemiStaticContentStoreFreeSql_Implements_ISemiStaticContentStore()
    {
        // Arrange
        var type = typeof(SemiStaticContentStoreFreeSql);

        // Act
        var isImplement = typeof(ISemiStaticContentStore).IsAssignableFrom(type);

        // Assert
        Assert.True(isImplement);
    }

    //SemiStaticContentStoreFreeSql have Constructor with pameter IFreeSql and ILogger<SemiStaticContentStoreFreeSql>
    [Fact]
    public void SemiStaticContentStoreFreeSql_Have_Constructor_With_IFreeSql_And_ILogger_SemiStaticContentStoreFreeSql()
    {
        // Arrange
        var type = typeof(SemiStaticContentStoreFreeSql);
        var constructor = type.GetConstructors().First();
        var parameters = constructor.GetParameters();

        // Act
        var haveConstructor = parameters.Any(p => p.ParameterType == typeof(IFreeSql) || p.ParameterType == typeof(ILogger<SemiStaticContentStoreFreeSql>));

        // Assert
        Assert.True(haveConstructor);
    }

    //Constructor Throw_ArgumentNullException_When_IFreeSql_Is_Null
    [Fact]
    public void Constructor_Throw_ArgumentNullException_When_IFreeSql_Is_Null()
    {
        // Arrange
        IFreeSql freeSql = null!;
        var logger = new Mock<ILogger<SemiStaticContentStoreFreeSql>>().Object;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => new SemiStaticContentStoreFreeSql(freeSql, logger));

        // Assert
        Assert.Equal("freeSql", exception.ParamName);
    }

    //Constructor Throw_ArgumentNullException_When_ILogger_Is_Null
    [Fact]
    public void Constructor_Throw_ArgumentNullException_When_ILogger_Is_Null()
    {
        // Arrange
        var freeSql = new Mock<IFreeSql>().Object;
        ILogger<SemiStaticContentStoreFreeSql> logger = null!;

        // Act
        var exception = Assert.Throws<ArgumentNullException>(() => new SemiStaticContentStoreFreeSql(freeSql, logger));

        // Assert
        Assert.Equal("logger", exception.ParamName);
    }

    [Fact]
    public async Task GetSource_returns_AwesomeValue_If_Key_AwesomeKeyAsync()
    {
        //Arrange
        var loggerMock = new Mock<ILogger<SemiStaticContentStoreFreeSql>>();
        var freeSqlMock = new Mock<IFreeSql>();
        var whereSelectMock = new Mock<ISelect<SemiStaticContentItem>>();
        var firstSelectMock = new Mock<ISelect<SemiStaticContentItem>>();

        freeSqlMock.Setup(p => p.Select<SemiStaticContentItem>()).Returns(whereSelectMock.Object);
        whereSelectMock.Setup(m => m.Where(p => p.Key == "AwesomeKey")).Returns(firstSelectMock.Object);
        firstSelectMock.Setup(p => p.FirstAsync(default)).Returns(Task.FromResult(new SemiStaticContentItem
        { Text="AwesomeValue"} ));
        
        var store = new SemiStaticContentStoreFreeSql(freeSqlMock.Object, loggerMock.Object);

        //Act
        var result = await store.GetSource("AwesomeKey");

        ////Assert
        Assert.True(result == "AwesomeValue");
    }
    
    //GetSource_returns_EmptyString_If_Key_Not_Exists
    [Fact]
    public async Task GetSource_returns_EmptyString_If_Key_Not_Exists()
    {
        //Arrange
        var loggerMock = new Mock<ILogger<SemiStaticContentStoreFreeSql>>();
        var freeSqlMock = new Mock<IFreeSql>();
        var whereSelectMock = new Mock<ISelect<SemiStaticContentItem>>();
        var firstSelectMock = new Mock<ISelect<SemiStaticContentItem>>();

        freeSqlMock.Setup(p => p.Select<SemiStaticContentItem>()).Returns(whereSelectMock.Object);
        whereSelectMock.Setup(m => m.Where(p => p.Key == "AwesomeKey")).Returns(firstSelectMock.Object);
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        firstSelectMock.Setup(p => p.FirstAsync(default)).Returns(Task.FromResult<SemiStaticContentItem>(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        var store = new SemiStaticContentStoreFreeSql(freeSqlMock.Object, loggerMock.Object);

        //Act
        var result = await store.GetSource("AwesomeKey");

        ////Assert
        Assert.True(result == string.Empty);
    }

    //GetSource_loger_log_error_If_Key_Not_Exists
    [Fact]
    public async Task GetSource_loger_log_error_If_Key_Not_Exists()
    {
        //Arrange
        var loggerMock = new Mock<ILogger<SemiStaticContentStoreFreeSql>>();
        var freeSqlMock = new Mock<IFreeSql>();
        var whereSelectMock = new Mock<ISelect<SemiStaticContentItem>>();
        var firstSelectMock = new Mock<ISelect<SemiStaticContentItem>>();

        freeSqlMock.Setup(p => p.Select<SemiStaticContentItem>()).Returns(whereSelectMock.Object);
        whereSelectMock.Setup(m => m.Where(p => p.Key == "AwesomeKey")).Returns(firstSelectMock.Object);
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        firstSelectMock.Setup(p => p.FirstAsync(default)).Returns(Task.FromResult<SemiStaticContentItem>(null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        var store = new SemiStaticContentStoreFreeSql(freeSqlMock.Object, loggerMock.Object);

        //Act
        var result = await store.GetSource("AwesomeKey");

        ////Assert
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        loggerMock.Verify(p => p.Log(LogLevel.Error, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), It.IsAny<Exception>(), It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.Once);
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
    }


}
