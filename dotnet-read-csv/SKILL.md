---
name: dotnet-read-csv
description: Use when implementing C#/.NET code to read CSV files and map rows into strongly typed entity classes, including parsing, validation, and unit tests.
---

# dotnet-read-csv

## Purpose

Implement a clean, testable .NET flow that:
1. Reads CSV input from file or stream.
2. Maps each row into an entity class.
3. Validates row-level and field-level data.
4. Surfaces errors without breaking the full import flow when possible.

## When to use

Use this skill when a user asks to:
1. Read CSV data in C#.
2. Map CSV rows into entity/domain objects.
3. Build import pipelines (read → map → validate → save).
4. Add or fix CSV ingestion unit tests.

## Inputs to collect first

1. Entity schema (field names, types, required/optional fields).
2. CSV format details:
   - Delimiter (`,`/`;`/tab).
   - Header presence and header names.
   - Quote/escape behavior.
   - Date/number formats and culture.
3. Error handling rules:
   - Fail-fast vs continue-with-errors.
   - How to report bad rows.
4. Expected output contract:
   - `List<TEntity>`, streaming `IAsyncEnumerable<TEntity>`, or result object with errors.

## Implementation pattern

1. **Define row model**
   - Create a row DTO representing raw CSV columns as strings.
   - Keep it separate from the entity class.

2. **Create CSV reader service**
   - Read rows from `Stream`/path.
   - Convert each CSV record into row DTO.
   - Isolate CSV library usage to this layer.

3. **Create mapper**
   - Map row DTO → entity.
   - Parse values (`int`, `decimal`, `DateTime`, enums).
   - Return either entity or structured validation errors.

4. **Create orchestrator service**
   - Loop through rows.
   - Collect valid entities.
   - Collect row errors with row number + message.
   - Return a result object with both sets.

5. **Write tests**
   - Happy path with multiple rows.
   - Missing required field.
   - Invalid numeric/date value.
   - Empty file/header-only file.
   - Mixed valid/invalid rows.

## Design rules

1. Keep methods single-purpose.
2. Use interfaces for reader/repository dependencies.
3. Keep mapping logic deterministic and side-effect free.
4. Use explicit parsing with clear error messages.
5. Prefer returning structured results over throwing for expected data issues.

## Output shape (recommended)

Use a result object such as:
1. `IReadOnlyList<TEntity> ValidEntities`
2. `IReadOnlyList<RowError> Errors`
3. `int TotalRowsProcessed`

Where `RowError` includes:
1. `int RowNumber`
2. `string Field`
3. `string Message`

## Testing checklist

1. Null/empty inputs.
2. Header mismatch behavior.
3. Type conversion failures.
4. Trimming and whitespace handling.
5. Duplicate key behavior (if applicable).
6. Repository success/failure paths when persistence is included.

## Notes

1. Match project conventions before adding helpers or abstractions.
2. Keep changes surgical and limited to requested behavior.
3. If CSV rules are ambiguous, state assumptions explicitly.
## Included templates

All templates are stored in the `assets` folder for direct reuse.

1. Entity template: `/dotnet-read-csv/assets/EntityTemplate.cs`
2. Read service template: `/dotnet-read-csv/assets/ReadServiceTemplate.cs`
3. Unit test template: `/dotnet-read-csv/assets/ReadServiceTemplateTests.cs`

