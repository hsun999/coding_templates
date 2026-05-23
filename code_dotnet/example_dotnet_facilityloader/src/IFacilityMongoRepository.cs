namespace ExampleDotnetFacilityLoader;

public interface IFacilityMongoRepository
{
    Task InsertFacilities(List<Facility> facilities);
}
