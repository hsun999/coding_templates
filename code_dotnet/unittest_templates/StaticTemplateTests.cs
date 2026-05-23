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
