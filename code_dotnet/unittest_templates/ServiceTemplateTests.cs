using Moq;
using Xunit;

namespace CodingTemplates.DotNet.UnitTestTemplates;

public class ProviderServiceTests
{
    [Fact]
    public void Constructor_Should_Throw_When_OtherService_Is_Null()
    {
        // Arrange
        CodingTemplates.DotNet.Templates.IOtherService? otherService = null;

        // Act
        var action = () => new CodingTemplates.DotNet.Templates.ProviderService(otherService!);

        // Assert
        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void GetProviderData_Should_Throw_When_ProviderId_Is_Null_Or_Whitespace()
    {
        // Arrange
        var otherServiceMock = new Mock<CodingTemplates.DotNet.Templates.IOtherService>();
        var service = new CodingTemplates.DotNet.Templates.ProviderService(otherServiceMock.Object);

        // Act / Assert
        Assert.Throws<ArgumentException>(() => service.GetProviderData(string.Empty));
        Assert.Throws<ArgumentException>(() => service.GetProviderData("   "));
    }

    [Fact]
    public void GetProviderData_Should_Return_Data_From_Dependency()
    {
        // Arrange
        var providerId = "provider-001";
        var expected = new CodingTemplates.DotNet.Templates.ProviderData
        {
            ProviderId = providerId,
            ProviderName = "Provider Name"
        };

        var otherServiceMock = new Mock<CodingTemplates.DotNet.Templates.IOtherService>();
        otherServiceMock
            .Setup(x => x.FetchProviderData(providerId))
            .Returns(expected);

        var service = new CodingTemplates.DotNet.Templates.ProviderService(otherServiceMock.Object);

        // Act
        var result = service.GetProviderData(providerId);

        // Assert
        Assert.Same(expected, result);
    }
}
