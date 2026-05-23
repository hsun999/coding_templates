namespace Example.DotNet.CsvLoader;

public interface IFacilityCsvProvider
{
    int LoadFacilities(string csvFilePath);
}

public class FacilityCsvProvider : IFacilityCsvProvider
{
    private readonly IFacilityMongoRepository _facilityMongoRepository;

    public FacilityCsvProvider(IFacilityMongoRepository facilityMongoRepository)
    {
        _facilityMongoRepository = facilityMongoRepository ?? throw new ArgumentNullException(nameof(facilityMongoRepository));
    }

    public int LoadFacilities(string csvFilePath)
    {
        if (string.IsNullOrWhiteSpace(csvFilePath))
        {
            throw new ArgumentException("csvFilePath is required.", nameof(csvFilePath));
        }

        var lines = File.ReadAllLines(csvFilePath);
        if (lines.Length <= 1)
        {
            return 0;
        }

        var insertedCount = 0;

        foreach (var line in lines.Skip(1))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            var columns = line.Split(',');
            var facilityData = FacilityBusinessRules.MapCsvRowToFacilityData(columns);

            if (string.IsNullOrWhiteSpace(facilityData.FacilityId))
            {
                continue;
            }

            _facilityMongoRepository.InsertFacility(facilityData);
            insertedCount += 1;
        }

        return insertedCount;
    }
}
