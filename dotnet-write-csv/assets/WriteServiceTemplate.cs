using System.Globalization;
using System.Text;

namespace DotnetWriteCsv.Templates;

public interface ICsvEntityWriteService
{
    CsvWriteResult WriteEntities(Stream csvStream, IReadOnlyList<CsvEntityTemplate> entities);
}

public class CsvEntityWriteService : ICsvEntityWriteService
{
    public CsvWriteResult WriteEntities(Stream csvStream, IReadOnlyList<CsvEntityTemplate> entities)
    {
        var errors = new List<RowError>();

        using var writer = new StreamWriter(csvStream, Encoding.UTF8, leaveOpen: true);

        writer.WriteLine("ExternalId,Name,Quantity,UnitPrice,EffectiveDateUtc");

        var rowsWritten = 0;

        for (var index = 0; index < entities.Count; index++)
        {
            var rowNumber = index + 1;

            if (!TryValidateEntity(entities[index], rowNumber, out var error))
            {
                errors.Add(error!);
                continue;
            }

            writer.WriteLine(BuildCsvLine(entities[index]));
            rowsWritten++;
        }

        writer.Flush();

        return new CsvWriteResult(rowsWritten, errors);
    }

    private static bool TryValidateEntity(CsvEntityTemplate entity, int rowNumber, out RowError? error)
    {
        error = null;

        if (string.IsNullOrWhiteSpace(entity.ExternalId))
        {
            error = new RowError(rowNumber, "ExternalId", "ExternalId is required.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(entity.Name))
        {
            error = new RowError(rowNumber, "Name", "Name is required.");
            return false;
        }

        return true;
    }

    private static string BuildCsvLine(CsvEntityTemplate entity)
    {
        var values = new[]
        {
            Escape(entity.ExternalId),
            Escape(entity.Name),
            entity.Quantity.ToString(CultureInfo.InvariantCulture),
            entity.UnitPrice.ToString(CultureInfo.InvariantCulture),
            entity.EffectiveDateUtc.ToUniversalTime().ToString("O", CultureInfo.InvariantCulture)
        };

        return string.Join(',', values);
    }

    private static string Escape(string value)
    {
        if (value.Contains('"'))
        {
            value = value.Replace("\"", "\"\"");
        }

        if (value.Contains(',') || value.Contains('"') || value.Contains('\n') || value.Contains('\r'))
        {
            return $"\"{value}\"";
        }

        return value;
    }
}

public record RowError(int RowNumber, string Field, string Message);

public record CsvWriteResult(int RowsWritten, IReadOnlyList<RowError> Errors)
{
    public bool HasErrors => Errors.Count > 0;
}
