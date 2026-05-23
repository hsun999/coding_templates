namespace CodingTemplates.DotNet.Templates;

public static class StaticHelpers
{
    public static string GetProviderTypeDescription(string providerType)
    {
        if (string.IsNullOrWhiteSpace(providerType))
        {
            return "Unknown provider type";
        }

        return providerType switch
        {
            "TypeA" => "Description for Type A",
            "TypeB" => "Description for Type B",
            _ => "Unknown provider type"
        };
    }
}


public static class ProviderViewDataMapper
{
    public static ProviderViewData MapProviderDataToViewData(ProviderData providerData)
    {
        var normalizedName = providerData.ProviderName.Trim();
        var normalizedType = providerData.ProviderType.Trim();

        var isFeatured =
            normalizedType.Equals("Preferred", StringComparison.OrdinalIgnoreCase)
            || providerData.ProviderUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase);

        return new ProviderViewData
        {
            ProviderId = providerData.ProviderId,
            DisplayName = normalizedName.ToUpperInvariant(),
            Category = normalizedType,
            PublicUrl = providerData.ProviderUrl,
            Summary = providerData.ProviderDescription,
            IsFeatured = isFeatured
        };
    }
}
