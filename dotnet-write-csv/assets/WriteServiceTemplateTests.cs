using System.Text;
using DotnetWriteCsv.Templates;

namespace DotnetWriteCsv.Tests;

public class WriteServiceTemplateTests
{
    [Fact]
    public void WriteEntities_WritesRows_WhenEntitiesAreValid()
    {
        var entities = new List<CsvEntityTemplate>
        {
            new()
            {
                ExternalId = "A-1",
                Name = "Widget",
                Quantity = 3,
                UnitPrice = 10.25m,
                EffectiveDateUtc = new DateTime(2026, 1, 15, 0, 0, 0, DateTimeKind.Utc)
            }
        };

        using var stream = new MemoryStream();

        var service = new CsvEntityWriteService();

        var result = service.WriteEntities(stream, entities);

        stream.Position = 0;
        using var reader = new StreamReader(stream, Encoding.UTF8);
        var csv = reader.ReadToEnd();

        Assert.Equal(1, result.RowsWritten);
        Assert.False(result.HasErrors);
        Assert.Contains("ExternalId,Name,Quantity,UnitPrice,EffectiveDateUtc", csv);
        Assert.Contains("A-1,Widget,3,10.25,2026-01-15T00:00:00.0000000Z", csv);
    }

    [Fact]
    public void WriteEntities_ReturnsError_WhenRequiredFieldIsMissing()
    {
        var entities = new List<CsvEntityTemplate>
        {
            new()
            {
                ExternalId = string.Empty,
                Name = "Widget"
            }
        };

        using var stream = new MemoryStream();

        var service = new CsvEntityWriteService();

        var result = service.WriteEntities(stream, entities);

        Assert.Equal(0, result.RowsWritten);
        Assert.True(result.HasErrors);
        Assert.Single(result.Errors);
        Assert.Equal("ExternalId", result.Errors[0].Field);
    }
}
