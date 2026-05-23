namespace Example.DotNet.CsvLoader;

public interface IFacilityMongoRepository
{
    void InsertFacility(FacilityData facilityData);
}

public class FacilityMongoRepository : IFacilityMongoRepository
{
    public void InsertFacility(FacilityData facilityData)
    {
        if (facilityData is null)
        {
            throw new ArgumentNullException(nameof(facilityData));
        }

        // Replace this with a real MongoDB insert into "Facilities" collection.
    }
}
