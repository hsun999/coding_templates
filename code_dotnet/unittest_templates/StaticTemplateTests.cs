using Xunit;
using CodingTemplates.DotNet.Templates;

namespace CodingTemplates.DotNet.UnitTestTemplates;

public class StaticHelpersTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void GetProviderTypeDescription_Should_Return_Unknown_When_Input_Is_Null_Or_Empty(string? providerType)
    {
        // Act
        var result = StaticHelpers.GetProviderTypeDescription(providerType!);

        // Assert
        Assert.Equal("Unknown provider type", result);
    }

    [Theory]
    [InlineData("TypeA", "Description for Type A")]
    [InlineData("TypeB", "Description for Type B")]
    [InlineData("TypeC", "Unknown provider type")]
    public void GetProviderTypeDescription_Should_Return_Expected_Description(string providerType, string expectedDescription)
    {
        // Act
        var result = StaticHelpers.GetProviderTypeDescription(providerType);

        // Assert
        Assert.Equal(expectedDescription, result);
    }
}

public class ProviderViewDataMapperTests
{
    [Fact]
    public void MapProviderDataToViewData_Should_Map_And_Normalize_Fields()
    {
        // Arrange
        var providerData = new ProviderData
        {
            ProviderId = "provider-010",
            ProviderName = "  North Health  ",
            ProviderType = " Preferred ",
            ProviderUrl = "http://north.example",
            ProviderDescription = "Regional network"
        };

        // Act
        var result = ProviderViewDataMapper.MapProviderDataToViewData(providerData);

        // Assert
        Assert.Equal("provider-010", result.ProviderId);
        Assert.Equal("NORTH HEALTH", result.DisplayName);
        Assert.Equal("Preferred", result.Category);
        Assert.Equal("http://north.example", result.PublicUrl);
        Assert.Equal("Regional network", result.Summary);
        Assert.True(result.IsFeatured);
    }

    [Fact]
    public void MapProviderDataToViewData_Should_Set_IsFeatured_True_For_Https_Url()
    {
        // Arrange
        var providerData = new ProviderData
        {
            ProviderId = "provider-011",
            ProviderName = "West Care",
            ProviderType = "Standard",
            ProviderUrl = "https://west.example",
            ProviderDescription = "Secure access"
        };

        // Act
        var result = ProviderViewDataMapper.MapProviderDataToViewData(providerData);

        // Assert
        Assert.True(result.IsFeatured);
    }

    [Fact]
    public void MapProviderDataToViewData_Should_Set_IsFeatured_False_For_NonPreferred_And_NonHttps()
    {
        // Arrange
        var providerData = new ProviderData
        {
            ProviderId = "provider-012",
            ProviderName = "East Care",
            ProviderType = "Standard",
            ProviderUrl = "http://east.example",
            ProviderDescription = "Community care"
        };

        // Act
        var result = ProviderViewDataMapper.MapProviderDataToViewData(providerData);

        // Assert
        Assert.False(result.IsFeatured);
    }
}
