using Xunit;
using Example.DotNet.CsvLoader;

namespace Example.DotNet.CsvLoader.Tests;

public class FacilityBusinessRulesTests
{
    [Fact]
    public void MapCsvRowToFacilityData_Should_Map_And_Apply_Business_Rules()
    {
        var columns = new[] { "f-100", "  CENTRAL HOSPITAL ", "hospital", "tx", "250" };

        var result = FacilityBusinessRules.MapCsvRowToFacilityData(columns);

        Assert.Equal("f-100", result.FacilityId);
        Assert.Equal("Central hospital", result.FacilityName);
        Assert.Equal("Hospital", result.FacilityType);
        Assert.Equal("TX", result.StateCode);
        Assert.Equal(250, result.BedCount);
        Assert.True(result.IsLargeFacility);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("-1")]
    public void ParseBedCount_Should_Return_Zero_For_Invalid_Inputs(string? rawBedCount)
    {
        var result = FacilityBusinessRules.ParseBedCount(rawBedCount!);

        Assert.Equal(0, result);
    }
}
