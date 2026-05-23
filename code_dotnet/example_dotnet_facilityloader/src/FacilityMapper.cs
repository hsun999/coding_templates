namespace ExampleDotnetFacilityLoader;

public static class FacilityMapper
{
    public static Facility MapFacility(FacilityCsvRow row)
    {
        var parsedDate = DateTime.Parse(row.LastUpdateDate);

        return new Facility
        {
            FacilityId = row.FacilityId.Trim(),
            Name = row.Name.Trim(),
            LastUpdateDate = parsedDate,
            IsActive = string.Equals(row.Status, "active", StringComparison.OrdinalIgnoreCase),
            FacilityTier = DetermineFacilityTier(row.Name),
        };
    }

    private static string DetermineFacilityTier(string facilityName)
    {
        if (facilityName.Length >= 15)
        {
            return "Tier1";
        }

        return "Tier2";
    }
}
