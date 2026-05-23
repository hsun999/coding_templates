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
