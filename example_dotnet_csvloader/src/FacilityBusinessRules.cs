namespace Example.DotNet.CsvLoader;

public static class FacilityBusinessRules
{
    public static FacilityData MapCsvRowToFacilityData(string[] columns)
    {
        if (columns is null)
        {
            throw new ArgumentNullException(nameof(columns));
        }

        if (columns.Length < 5)
        {
            throw new ArgumentException("CSV row must have 5 columns.", nameof(columns));
        }

        var bedCount = ParseBedCount(columns[4]);

        return new FacilityData
        {
            FacilityId = columns[0].Trim(),
            FacilityName = TitleCase(columns[1]),
            FacilityType = NormalizeFacilityType(columns[2]),
            StateCode = columns[3].Trim().ToUpperInvariant(),
            BedCount = bedCount,
            IsLargeFacility = bedCount >= 200
        };
    }

    public static int ParseBedCount(string rawBedCount)
    {
        if (!int.TryParse(rawBedCount?.Trim(), out var bedCount) || bedCount < 0)
        {
            return 0;
        }

        return bedCount;
    }

    private static string NormalizeFacilityType(string value)
    {
        var trimmed = value?.Trim().ToLowerInvariant() ?? string.Empty;

        return trimmed switch
        {
            "hospital" => "Hospital",
            "clinic" => "Clinic",
            _ => "Other"
        };
    }

    private static string TitleCase(string value)
    {
        var trimmed = value?.Trim() ?? string.Empty;
        if (trimmed.Length == 0)
        {
            return string.Empty;
        }

        return char.ToUpperInvariant(trimmed[0]) + trimmed[1..].ToLowerInvariant();
    }
}
