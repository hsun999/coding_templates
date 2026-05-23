using ExampleDotnetFacilityLoader;

namespace ExampleDotnetFacilityLoaderTests;

public class FacilityLoaderServiceTests
{
    [Fact]
    public async Task LoadFacilities_WhenDateOlderThanThreeMonths_ThenInsertsFacility()
    {
        var csvReader = new FacilityCsvReaderFake();
        var repository = new FacilityMongoRepositoryFake();
        var service = new FacilityLoaderService(csvReader, repository);

        await service.LoadFacilities("ignored");

        Assert.Single(repository.InsertedFacilities);
        Assert.Equal("F-OLD", repository.InsertedFacilities[0].FacilityId);
    }

    private class FacilityCsvReaderFake : IFacilityCsvReader
    {
        public List<FacilityCsvRow> ReadFacilities(string filePath)
        {
            return
            [
                new FacilityCsvRow { FacilityId = "F-OLD", Name = "Older Facility Name", LastUpdateDate = "2025-01-01", Status = "active" },
                new FacilityCsvRow { FacilityId = "F-NEW", Name = "New Facility", LastUpdateDate = DateTime.UtcNow.ToString("yyyy-MM-dd"), Status = "active" },
            ];
        }
    }

    private class FacilityMongoRepositoryFake : IFacilityMongoRepository
    {
        public List<Facility> InsertedFacilities { get; } = [];

        public Task InsertFacilities(List<Facility> facilities)
        {
            InsertedFacilities.AddRange(facilities);
            return Task.CompletedTask;
        }
    }
}
