using ExampleDotnetFacilityLoader;

namespace ExampleDotnetFacilityLoaderTests;

public class FacilityMapperTests
{
    [Fact]
    public void MapFacility_WhenStatusIsActive_ThenMapsIsActiveTrue()
    {
        var row = new FacilityCsvRow
        {
            FacilityId = " F-1 ",
            Name = "Main Facility Name",
            LastUpdateDate = "2025-01-01",
            Status = "active",
        };

        var result = FacilityMapper.MapFacility(row);

        Assert.Equal("F-1", result.FacilityId);
        Assert.True(result.IsActive);
        Assert.Equal("Tier1", result.FacilityTier);
    }
}
