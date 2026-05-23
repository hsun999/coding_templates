using Moq;
using Xunit;
using CodingTemplates.DotNet.Templates;

namespace CodingTemplates.DotNet.UnitTestTemplates;

public class ProviderServiceTests
{
    [Fact]
    public void Constructor_Should_Throw_When_OtherService_Is_Null()
    {
        // Arrange
        IOtherService? otherService = null;

        // Act
        var action = () => new ProviderService(otherService!);

        // Assert
        Assert.Throws<ArgumentNullException>(action);
    }

    [Fact]
    public void GetProviderData_Should_Throw_When_ProviderId_Is_Null_Or_Whitespace()
    {
        // Arrange
        var otherServiceMock = new Mock<IOtherService>();
        var service = new ProviderService(otherServiceMock.Object);

        // Act / Assert
        Assert.Throws<ArgumentException>(() => service.GetProviderData(string.Empty));
        Assert.Throws<ArgumentException>(() => service.GetProviderData("   "));
    }

    [Fact]
    public void GetProviderData_Should_Return_Data_From_Dependency()
    {
        // Arrange
        var providerId = "provider-001";
        var expected = new ProviderData
        {
            ProviderId = providerId,
            ProviderName = "Provider Name"
        };

        var otherServiceMock = new Mock<IOtherService>();
        otherServiceMock
            .Setup(x => x.FetchProviderData(providerId))
            .Returns(expected);

        var service = new ProviderService(otherServiceMock.Object);

        // Act
        var result = service.GetProviderData(providerId);

        // Assert
        Assert.Same(expected, result);
    }

    [Fact]
    public void GetProviderViewData_Should_Use_Dependency_Data_And_Return_Mapped_Result()
    {
        // Arrange
        var providerId = "provider-002";
        var dependencyData = new ProviderData
        {
            ProviderId = providerId,
            ProviderName = "  North Health  ",
            ProviderType = "Preferred",
            ProviderUrl = "http://north-health.example",
            ProviderDescription = "Strong regional coverage"
        };

        var expected = ProviderViewDataMapper.MapProviderDataToViewData(dependencyData);

        var otherServiceMock = new Mock<IOtherService>();
        otherServiceMock
            .Setup(x => x.FetchProviderData(providerId))
            .Returns(dependencyData);

        var service = new ProviderService(otherServiceMock.Object);

        // Act
        var result = service.GetProviderViewData(providerId);

        // Assert
        otherServiceMock.Verify(x => x.FetchProviderData(providerId), Times.Once);
        Assert.Equivalent(expected, result);
    }
}
