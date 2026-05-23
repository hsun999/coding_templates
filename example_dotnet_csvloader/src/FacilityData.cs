namespace Example.DotNet.CsvLoader;

public class FacilityData
{
    public string FacilityId { get; set; } = string.Empty;
    public string FacilityName { get; set; } = string.Empty;
    public string FacilityType { get; set; } = string.Empty;
    public string StateCode { get; set; } = string.Empty;
    public int BedCount { get; set; }
    public bool IsLargeFacility { get; set; }
}
