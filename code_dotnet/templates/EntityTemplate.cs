namespace CodingTemplates.DotNet.Templates;

public class ProviderData
{
    public string ProviderId { get; set; } = string.Empty;
    public string ProviderName { get; set; } = string.Empty;
    public string ProviderType { get; set; } = string.Empty;
    public string ProviderUrl { get; set; } = string.Empty;
    public string ProviderDescription { get; set; } = string.Empty;
}

public class ProviderViewData
{
    public string ProviderId { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string PublicUrl { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public bool IsFeatured { get; set; }
}
