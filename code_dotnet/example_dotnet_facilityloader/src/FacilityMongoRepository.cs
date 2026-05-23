namespace ExampleDotnetFacilityLoader;

public class FacilityMongoRepository : IFacilityMongoRepository
{
    public Task InsertFacilities(List<Facility> facilities)
    {
        return Task.CompletedTask;
    }
}
