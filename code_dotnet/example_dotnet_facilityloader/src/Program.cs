namespace ExampleDotnetFacilityLoader;

public class Program
{
    public static async Task Main(string[] args)
    {
        var filePath = args[0];
        var csvReader = new FacilityCsvReader();
        var repository = new FacilityMongoRepository();
        var service = new FacilityLoaderService(csvReader, repository);

        await service.LoadFacilities(filePath);
    }
}
