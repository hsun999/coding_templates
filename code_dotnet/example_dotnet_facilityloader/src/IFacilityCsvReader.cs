namespace ExampleDotnetFacilityLoader;

public interface IFacilityCsvReader
{
    List<FacilityCsvRow> ReadFacilities(string filePath);
}
