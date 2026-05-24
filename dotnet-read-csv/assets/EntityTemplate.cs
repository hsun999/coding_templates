namespace DotnetReadCsv.Templates;

public class CsvEntityTemplate
{
    public string ExternalId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public DateTime EffectiveDateUtc { get; set; }
}
