using Xunit;

namespace CodingTemplates.DotNet.UnitTestTemplates;

public class ProviderDataTests
{
    [Fact]
    public void ProviderData_Should_Initialize_With_Empty_Strings()
    {
        // Arrange
        var providerData = new CodingTemplates.DotNet.Templates.ProviderData();

        // Assert
        Assert.Equal(string.Empty, providerData.ProviderId);
        Assert.Equal(string.Empty, providerData.ProviderName);
        Assert.Equal(string.Empty, providerData.ProviderType);
        Assert.Equal(string.Empty, providerData.ProviderUrl);
        Assert.Equal(string.Empty, providerData.ProviderDescription);
    }
}
