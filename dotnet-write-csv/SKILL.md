---
name: dotnet-write-csv
description: Use when implementing C#/.NET code to write strongly typed entities to CSV files, including formatting, validation, and unit tests.
---

# dotnet-write-csv

## Purpose

Implement a clean, testable .NET flow that:
1. Accepts strongly typed entities.
2. Validates required fields before writing.
3. Formats values into CSV-safe output.
4. Writes header + rows to file or stream.

## When to use

Use this skill when a user asks to:
1. Write CSV data in C#.
2. Export entity/domain objects into CSV rows.
3. Build export pipelines (load → map → format → write).
4. Add or fix CSV export unit tests.

## Inputs to collect first

1. Entity schema (field names, types, required/optional fields).
2. CSV format details:
   - Delimiter (`,`/`;`/tab).
   - Header names and order.
   - Quote/escape behavior.
   - Date/number formats and culture.
3. Error handling rules:
   - Fail-fast vs skip-invalid-row.
   - How to report rejected rows.
4. Expected output contract:
   - `string`, `byte[]`, direct `Stream` write, or result object with errors.

## Implementation pattern

1. **Define output model**
   - Use an entity class for source data.
   - Optionally use a row DTO for CSV-specific projection.

2. **Create CSV formatter**
   - Convert entity/row fields to output-safe strings.
   - Escape commas, quotes, and line breaks.
   - Keep culture-specific formatting explicit.

3. **Create CSV write service**
   - Write header first.
   - Write each formatted row.
   - Isolate stream/path I/O in this layer.

4. **Add validation flow**
   - Validate required fields and type assumptions.
   - Collect row-level errors when skipping invalid rows is allowed.
   - Return a structured write result.

5. **Write tests**
   - Happy path with multiple rows.
   - Required field missing.
   - Escaping for commas/quotes/newlines.
   - Empty input list.
   - Mixed valid/invalid rows when skip logic exists.

## Design rules

1. Keep methods single-purpose.
2. Use interfaces for write/repository dependencies.
3. Keep formatting logic deterministic and side-effect free.
4. Use explicit culture formatting for number/date output.
5. Prefer structured results over throwing for expected validation issues.

## Output shape (recommended)

Use a result object such as:
1. `int RowsWritten`
2. `IReadOnlyList<RowError> Errors`
3. `bool HasErrors`

Where `RowError` includes:
1. `int RowNumber`
2. `string Field`
3. `string Message`

## Testing checklist

1. Null/empty inputs.
2. Header presence and column order.
3. Quote escaping behavior.
4. Invariant formatting for decimal/date values.
5. Invalid row handling behavior.
6. Stream write success/failure paths when persistence is included.

## Notes

1. Match project conventions before adding helpers or abstractions.
2. Keep changes surgical and limited to requested behavior.
3. If CSV rules are ambiguous, state assumptions explicitly.

## Included templates

All templates are stored in the `assets` folder for direct reuse.

1. Entity template: `/dotnet-write-csv/assets/EntityTemplate.cs`
2. Write service template: `/dotnet-write-csv/assets/WriteServiceTemplate.cs`
3. Unit test template: `/dotnet-write-csv/assets/WriteServiceTemplateTests.cs`
