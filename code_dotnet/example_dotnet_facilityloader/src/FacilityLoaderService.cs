namespace ExampleDotnetFacilityLoader;

public class FacilityLoaderService
{
    private readonly IFacilityCsvReader _csvReader;
    private readonly IFacilityMongoRepository _repository;

    public FacilityLoaderService(IFacilityCsvReader csvReader, IFacilityMongoRepository repository)
    {
        _csvReader = csvReader;
        _repository = repository;
    }

    public async Task LoadFacilities(string filePath)
    {
        var facilityRows = _csvReader.ReadFacilities(filePath);

        var facilities = facilityRows
            .Select(FacilityMapper.MapFacility)
            .Where(facility => facility.LastUpdateDate < DateTime.UtcNow.AddMonths(-3))
            .ToList();

        await _repository.InsertFacilities(facilities);
    }
}
