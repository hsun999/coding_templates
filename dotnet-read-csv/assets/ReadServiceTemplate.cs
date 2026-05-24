using System.Globalization;

namespace DotnetReadCsv.Templates;

public interface ICsvEntityReadService
{
    CsvReadResult<CsvEntityTemplate> ReadEntities(Stream csvStream);
}

public class CsvEntityReadService : ICsvEntityReadService
{
    public CsvReadResult<CsvEntityTemplate> ReadEntities(Stream csvStream)
    {
        var validEntities = new List<CsvEntityTemplate>();

        var errors = new List<RowError>();

        using var reader = new StreamReader(csvStream);

        var lineNumber = 0;

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();

            lineNumber++;

            if (lineNumber == 1)
            {
                continue;
            }

            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            var columns = line.Split(',');

            if (columns.Length < 5)
            {
                errors.Add(new RowError(lineNumber, "Row", "Expected 5 columns."));

                continue;
            }

            if (!TryMapRow(columns, lineNumber, out var entity, out var rowError))
            {
                errors.Add(rowError!);

                continue;
            }

            validEntities.Add(entity!);
        }

        return new CsvReadResult<CsvEntityTemplate>(validEntities, errors, lineNumber - 1);
    }

    private static bool TryMapRow(
        string[] columns,
        int lineNumber,
        out CsvEntityTemplate? entity,
        out RowError? error)
    {
        entity = null;
        error = null;

        var externalId = columns[0].Trim();
        var name = columns[1].Trim();

        if (string.IsNullOrWhiteSpace(externalId))
        {
            error = new RowError(lineNumber, "ExternalId", "ExternalId is required.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            error = new RowError(lineNumber, "Name", "Name is required.");
            return false;
        }

        if (!int.TryParse(columns[2].Trim(), out var quantity))
        {
            error = new RowError(lineNumber, "Quantity", "Quantity must be an integer.");
            return false;
        }

        if (!decimal.TryParse(columns[3].Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out var unitPrice))
        {
            error = new RowError(lineNumber, "UnitPrice", "UnitPrice must be a decimal value.");
            return false;
        }

        if (!DateTime.TryParse(columns[4].Trim(), CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var effectiveDate))
        {
            error = new RowError(lineNumber, "EffectiveDateUtc", "EffectiveDateUtc must be a valid date.");
            return false;
        }

        entity = new CsvEntityTemplate
        {
            ExternalId = externalId,
            Name = name,
            Quantity = quantity,
            UnitPrice = unitPrice,
            EffectiveDateUtc = effectiveDate.ToUniversalTime()
        };

        return true;
    }
}

public record RowError(int RowNumber, string Field, string Message);

public record CsvReadResult<TEntity>(
    IReadOnlyList<TEntity> ValidEntities,
    IReadOnlyList<RowError> Errors,
    int TotalRowsProcessed);
