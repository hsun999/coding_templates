namespace ExampleDotnetFacilityLoader;

public class Facility
{
    public string FacilityId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public DateTime LastUpdateDate { get; set; }

    public bool IsActive { get; set; }

    public string FacilityTier { get; set; } = string.Empty;
}
