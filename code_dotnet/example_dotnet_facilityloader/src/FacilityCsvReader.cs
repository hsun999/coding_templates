namespace ExampleDotnetFacilityLoader;

public class FacilityCsvReader : IFacilityCsvReader
{
    public List<FacilityCsvRow> ReadFacilities(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var dataLines = lines.Skip(1);
        var rows = new List<FacilityCsvRow>();

        foreach (var line in dataLines)
        {
            var columns = line.Split(',');

            rows.Add(new FacilityCsvRow
            {
                FacilityId = columns[0],
                Name = columns[1],
                LastUpdateDate = columns[2],
                Status = columns[3],
            });
        }

        return rows;
    }
}
