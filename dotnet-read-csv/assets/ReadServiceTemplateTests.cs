using System.Text;
using DotnetReadCsv.Templates;

namespace DotnetReadCsv.Tests;

public class ReadServiceTemplateTests
{
    [Fact]
    public void ReadEntities_ReturnsEntities_WhenCsvRowsAreValid()
    {
        var csv = "ExternalId,Name,Quantity,UnitPrice,EffectiveDateUtc\nA-1,Widget,3,10.25,2026-01-15\n";

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(csv));

        var service = new CsvEntityReadService();

        var result = service.ReadEntities(stream);

        Assert.Single(result.ValidEntities);
        Assert.Empty(result.Errors);
        Assert.Equal(1, result.TotalRowsProcessed);
    }

    [Fact]
    public void ReadEntities_ReturnsError_WhenRequiredFieldIsMissing()
    {
        var csv = "ExternalId,Name,Quantity,UnitPrice,EffectiveDateUtc\n,Widget,3,10.25,2026-01-15\n";

        using var stream = new MemoryStream(Encoding.UTF8.GetBytes(csv));

        var service = new CsvEntityReadService();

        var result = service.ReadEntities(stream);

        Assert.Empty(result.ValidEntities);
        Assert.Single(result.Errors);
        Assert.Equal("ExternalId", result.Errors[0].Field);
    }
}
